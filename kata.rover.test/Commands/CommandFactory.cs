using System.Collections.Generic;
using System;

namespace kata.rover.test
{
    public static class CommandFactory{

        public static ICommand CreateCommand(ECommand command)
        {
            switch (command)
            {
                case ECommand.Forward:
                    return new ForwardCommand();
                case ECommand.Backward:
                    return new BackwardCommand();
                case ECommand.Left:
                    return new LeftCommand();
                case ECommand.Right:
                    return new RightCommand();                
                default:
                    throw new Exception("Command Not Found");
            }            
        }
        
    }
}
