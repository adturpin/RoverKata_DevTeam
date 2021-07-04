
using System.Collections.Generic;

namespace kata.rover.test
{
    public interface IDetector
    {
        bool Scan(ICommand eCommand);
    }
}