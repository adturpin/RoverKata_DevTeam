using System;
using System.Collections.Generic;

namespace kata.rover.test
{
    public class LeftCommand : StaticCommand
    {
        protected override  VecteurMovement movement => VecteurMovement.Create(AngleDirection.left);
    }
}