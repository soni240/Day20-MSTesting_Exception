using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTesting_Exceptions
{
    public class MoodAnalyzer_CustomException : Exception
    {
        private ExceptionType Type;
        public enum ExceptionType
        {
            //   enum for excpetion type
            NUll_MESSAGE, EMPTY_MESSAGE,
            NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ERROR

        }

        //creating param constructor for init
        ///<param name="type"></param>
        ///<param name="messgae"></param>
        public MoodAnalyzer_CustomException(ExceptionType Type, string message) : base(message)
        {
            this.Type = Type;
        }

    }
}
