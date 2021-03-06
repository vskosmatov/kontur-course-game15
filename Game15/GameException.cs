﻿using System;

namespace Game15
{
    public class GameException : Exception
    {
        public GameException() 
            : base()
        {
        }

        public GameException(string message)
            : base(message)
        {
        }

        public GameException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
