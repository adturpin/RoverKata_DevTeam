
namespace kata.rover.test
{
    public class DefaultDetector : IDetector
    {
        public bool Scan(ICommand eCommand)
        {
            return false;
        }
    }
}