namespace kata.rover.test
{
    public class VecteurMovement
    {
        public readonly int X;

        public readonly int Y;
        
        public readonly AngleDirection Angle;

        private VecteurMovement(int x, int y)
        {
            X = x;
            Y = y;
            Angle = AngleDirection.center;
        }
        private VecteurMovement(AngleDirection angle)
        {
            X = 0;
            Y = 0;
            Angle = angle;
        }
        
        public static VecteurMovement Create(int fx, int fy)
        {
            return new VecteurMovement(fx, fy);
        }
        
        public static VecteurMovement Create(AngleDirection angle)
        {
            return new VecteurMovement(angle);
        }
    }

    public enum AngleDirection
    {
        left,
        right,
        center
    }
}