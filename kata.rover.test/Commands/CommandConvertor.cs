using System;
using System.Collections.Generic;

namespace kata.rover.test
{
    public static class CommandConvertor
    {
        static Dictionary<char, ECommand> convertion = new Dictionary<char, ECommand>(){
            {'f', ECommand.Forward},
            {'b', ECommand.Backward},
            {'l', ECommand.Left},
            {'r', ECommand.Right}
        };

        public static ECommand ConvertCommand(char command)
        {
            if (convertion.ContainsKey(command))
                return convertion[command];

            throw new Exception("Command Not found");
        }
    }
}