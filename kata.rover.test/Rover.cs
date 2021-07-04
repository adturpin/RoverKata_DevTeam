using System.Collections.Generic;
using System;
using System.Linq;

namespace kata.rover.test
{
    public class Rover {
        private Coordinates _coordinates;

        private GPSMarsRover _gps;

        private IDetector _detector;

        public event EventHandler ObstacleDetected;

        public Rover(Coordinates coordinates){
            _coordinates = coordinates;
            _gps = new GPSMarsRover();
            _detector = new DefaultDetector();
        }
         public Rover(Coordinates coordinates, IDetector detector)
            :this(coordinates)
         {
             _detector = detector;
         }
       
        public void ReceiveCommand(char[] commands){         
            
            IEnumerable<ECommand> _commands = commands.Select(x => CommandConvertor.ConvertCommand(x));
            bool IsObstacle = false;

            _coordinates =_commands.Aggregate(_coordinates, (coordinates, command)=> {

                var commande = CommandFactory.CreateCommand(command);  
                
                IsObstacle = _detector.Scan(commande);
                
                var movement = commande.Execute(coordinates.Direction);
                var newCoordinates = _gps.Move(coordinates, movement);

                if(IsObstacle){
                    ObstacleDetected?.Invoke(this, EventArgs.Empty);
                    return coordinates;
                }

                return newCoordinates;
            });          
        }

        public int GetX(){
            return _coordinates.Position.X;
        }
        
        public int GetY(){
            return _coordinates.Position.Y;
        }

        public EDirection GetCurrentDirection(){
            return _coordinates.Direction;
        }
    }
}