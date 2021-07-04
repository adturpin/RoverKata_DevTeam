using System.Collections.Generic;
using System;

namespace kata.rover.test
{
    public abstract class DynamicCommand : ICommand
    {
        protected abstract Dictionary<EDirection, VecteurMovement> CommandExecution {get;}
        
        public VecteurMovement Execute(EDirection direction)
        {
            VecteurMovement movement = CommandExecution[direction];
            return movement;
        }
    }
}