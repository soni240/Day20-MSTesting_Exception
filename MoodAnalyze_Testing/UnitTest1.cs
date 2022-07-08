using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTesting_Exceptions;

namespace MoodAnalyze_Testing
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyzer moodAnalyzer;

        [TestMethod]
        [DataRow(null)]
        public void Given_NULLMood_shouldReturn_HAPPY(string message) //Test method
        {
            // >> Arrange
            string expected = "HAPPY";  //Expexted Output stored in string varaible
            moodAnalyzer = new MoodAnalyzer(message); //creating object of MOodAnalyzer class with passing param message

            // >> Act
            string Result = moodAnalyzer.AnalyzeMood(); //calling Analyzemood methd and storing returned string in result

            // >> Assert
            Assert.AreEqual(expected, Result); //Comparing our expected output with result returned from analyzeMood methd

        }

    }
}