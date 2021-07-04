using System;
using System.Collections.Generic;

namespace kata.rover.test
{
    public class RightCommand : StaticCommand
    {
        protected override VecteurMovement movement => VecteurMovement.Create(AngleDirection.right);
    }
}