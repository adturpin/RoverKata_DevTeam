using System.Collections.Generic;
using System;

namespace kata.rover.test
{
    public class BackwardCommand : DynamicCommand
    {
        private static Dictionary<EDirection,VecteurMovement> _commandExecution = new Dictionary<EDirection, VecteurMovement>(){
            {EDirection.East, VecteurMovement.Create(-1, 0) },
            {EDirection.North, VecteurMovement.Create(0, -1) },
            {EDirection.West, VecteurMovement.Create(1, 0) },
            {EDirection.South, VecteurMovement.Create(0, 1) }
        };

        protected override Dictionary<EDirection, VecteurMovement> CommandExecution { get => _commandExecution; }

    }
}