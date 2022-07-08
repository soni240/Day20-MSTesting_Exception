using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTesting_Exceptions;

namespace MoodAnalyze_Testing
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyzer moodAnalyzer;

        public UnitTest1()
        {
            moodAnalyzer = new MoodAnalyzer();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // >> arrange
            moodAnalyzer = new MoodAnalyzer();
            // >> Act
            var Result = moodAnalyzer.AnalyzeMood("I am in Sad Mood");
            // >> Assert
            Assert.AreEqual(Result, "SAD");


        }
    }
}