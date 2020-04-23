using System;
using System.Collections.Generic;
using System.Text;

namespace stateCensusAnaliser
{
        /// <summary>
        /// create customarised enum class for handle customarised exception
        /// </summary>
        public class StateCensusException : Exception
        {
            public enum ExceptionType
            {
                FILE_NOT_FOUND,
                WRONG_FILE,
                WRONG_DELIMETER,
                HEADER_IS_NOT_PROPER,
                HEADER_NAME_NOT_SAME,
                HEADER_LENGTH_NOT_SAME,
            FILE_HAS_NO_DATA
        }
            public  ExceptionType type;
            public StateCensusException(ExceptionType type, string message) : base(message)
            {
                this.type = type;
            }

        }
    }
