using System.Collections.Generic;
using System;

namespace kata.rover.test
{
    public abstract class StaticCommand : ICommand
    {
        protected abstract VecteurMovement movement {get;}
        
       
        public VecteurMovement Execute(EDirection direction)
        {
            return movement;
        }
    }
}