using System.Collections.Generic;
using System;

namespace kata.rover.test
{
    public class Coordinates {
        public readonly RoverPosition Position;
        
        public readonly EDirection Direction;

        public Coordinates(int x, int y, char direction){
            Position = RoverPosition.CreatePosition(x, y);
            Direction = ConvertDirection(direction);
        }

        public Coordinates(RoverPosition position, EDirection direction){
            Position = position;
            Direction = direction;
        }

        static Dictionary<char,EDirection > convertion = new Dictionary<char, EDirection>(){
            {'N', EDirection.North},
            {'S', EDirection.South},
            {'E', EDirection.East},
            {'W', EDirection.West}
        };

        private static EDirection ConvertDirection(char direction){
            if(convertion.ContainsKey(direction))
                return convertion[direction];

            throw new Exception("Direction Not found");
        }

        public override string ToString()
        {
            return $"x = {Position.X} Y ={Position.Y} Direction={Direction}";
        }
    }
}