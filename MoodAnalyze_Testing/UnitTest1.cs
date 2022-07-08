using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTesting_Exceptions;

namespace MoodAnalyze_Testing
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyzer moodAnalyzer;


        [TestMethod]
        public void Given_NULLMood_shouldReturn_MoodAnalyzeCustomeException_NUllMessage() //Test method
        {
            try
            {
                // >> Arrange
                string message = null;  //Expexted Output stored in string varaible
                moodAnalyzer = new MoodAnalyzer(message); //creating object of MOodAnalyzer class with passing param message

                // >> Act
                string Result = moodAnalyzer.AnalyzeMood(); //calling Analyzemood methd and storing returned string in result

            }
            catch (MoodAnalyzer_CustomException e)//cathing the exception thrown by analyzeMood methd
            {
                // >> Assert
                Assert.AreEqual("Message can not be NULL!!", e.Message);
            }
        }

        [TestMethod]
        public void Given_EMptyMood_shouldReturn_MoodAnalyzerCustomeException_EMptyMessage() //Test method
        {
            try
            {
                // >> Arrange
                string message = "";  //Expexted Output stored in string varaible
                moodAnalyzer = new MoodAnalyzer(message); //creating object of MOodAnalyzer class with passing param message

                // >> Act
                string Result = moodAnalyzer.AnalyzeMood(); //calling Analyzemood methd and storing returned string in result

            }
            catch (MoodAnalyzer_CustomException e) //cathing the exception thrown by analyzeMood methd
            {
                // >> Assert
                Assert.AreEqual("Message Should Not Be EMPTY!!", e.Message);
            }

        }
    }
}