using System.Collections.Specialized;
using System.Collections.Generic;
using System;

namespace kata.rover.test
{
    public class GPSMarsRover
    {
        public static int XMax = 15;

        public static int YMax = 15;

        private static Dictionary<EDirection, EDirection> rightMapping = new Dictionary<EDirection, EDirection>(){
            {EDirection.North, EDirection.East },
            {EDirection.West, EDirection.North },
            {EDirection.South, EDirection.West },
            {EDirection.East, EDirection.South }
        };

        private static Dictionary<EDirection, EDirection> leftMapping = new Dictionary<EDirection, EDirection>(){
            {EDirection.North, EDirection.West },
            {EDirection.West, EDirection.South },
            {EDirection.South, EDirection.East },
            {EDirection.East,  EDirection.North }
        };

        private static Dictionary<AngleDirection, Dictionary<EDirection, EDirection>> mapping = new Dictionary<AngleDirection, Dictionary<EDirection, EDirection>>{
            {AngleDirection.left, leftMapping},
            {AngleDirection.right, rightMapping}
        };
        
        public Coordinates Move(Coordinates roverInitialCoordinates, VecteurMovement movement)
        {
            EDirection direction = roverInitialCoordinates.Direction;
            if(movement.Angle != AngleDirection.center)
            {     
                direction = mapping[movement.Angle][direction]; 
            }

            if((roverInitialCoordinates.Position.Y == YMax && movement.Y > 0) || 
                (roverInitialCoordinates.Position.Y == 0 && movement.Y < 0) ||
                (roverInitialCoordinates.Position.X == XMax && movement.X > 0) || 
                (roverInitialCoordinates.Position.X == 0 && movement.X < 0))
                return new Coordinates(
                    RoverPosition.CreatePosition(
                        Math.Abs(roverInitialCoordinates.Position.X - XMax),
                        roverInitialCoordinates.Position.Y),
                        direction);

            return new Coordinates(
                RoverPosition.CreatePosition(
                    roverInitialCoordinates.Position.X + movement.X,
                    roverInitialCoordinates.Position.Y + movement.Y), 
                    direction);
        }
    }
}