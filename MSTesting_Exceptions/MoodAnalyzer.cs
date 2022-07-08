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

        public MoodAnalyzer(string message) // parameterized constructor
        {
            this.message = message;  // initiallizing the instance variable
        }

        public string AnalyzeMood()  //param method to analayze mood
        {
            try
            {
                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch
            {
                return "HAPPY";
            }

        }
    }
}
