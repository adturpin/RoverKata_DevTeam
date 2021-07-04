using System;

namespace kata.rover.test
{
    public class RoverPosition
    {
        private RoverPosition(int x, int y){
            X = x;
            Y = y;
        }

        public readonly int X;
        
        public readonly int Y;

        public static RoverPosition CreatePosition(int x, int y){
            return new RoverPosition(x,y);
        }
        
        public static bool operator ==(RoverPosition rPosition1, RoverPosition rPosition2)
        {
            if (rPosition1 is null) 
            {
                if (rPosition2 is null) 
                {
                    return true;
                }

                // Only the left side is null. 
                return false;
            }
            // Equals handles case of null on right side.
            return rPosition1.Equals(rPosition2);
        }

        public static bool operator !=(RoverPosition rPosition1, RoverPosition rPosition2)
        {
            if (rPosition1 is null)
            {
                if (rPosition2 is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return !rPosition1.Equals(rPosition2);
        }

        public override bool Equals(object obj) => this.Equals(obj as RoverPosition);

        public bool Equals(RoverPosition p)
        {
            if (p is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (!Object.ReferenceEquals(this, p))
            {
                // If run-time types are not exactly the same, return false.
                if (this.GetType() != p.GetType())
                {
                    return false;
                }

                // Return true if the fields match.
                // Note that the base class is not invoked because it is
                // System.Object, which defines Equals as reference equality.
                return (X == p.X) && (Y == p.Y);
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"x = {X} Y ={Y}";
        }
    }
}