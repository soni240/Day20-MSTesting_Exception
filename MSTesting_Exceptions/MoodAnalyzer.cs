using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTesting_Exceptions
{
    public class MoodAnalyzer
    {
        private string message; //declaring the private string type instance/global variable

        public MoodAnalyzer()
        {
            //Default constructor
        }
        public MoodAnalyzer(string message) // parameterized constructor
        {
            this.message = message;  // initiallizing the instance variable
        }

        public string AnalyzeMood()  //param method to analayze mood
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.EMPTY_MESSAGE, "Message Should Not Be EMPTY!!");
                }

                if (this.message.ToLower().Equals("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NUll_MESSAGE, "Message can not be NULL!!");
            }

        }

    }
}
