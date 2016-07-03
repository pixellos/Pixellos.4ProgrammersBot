﻿namespace CoreBot.Mask
{
    public class Argument
    {
        public readonly ArgumentOptions ArgumentOptions;
        public readonly string ArgumentName;

        public Argument(ArgumentOptions argumentOptions, string argumentName)
        {
            ArgumentOptions = argumentOptions;
            ArgumentName = argumentName;
        }
    }
}