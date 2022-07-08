using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTesting_Exceptions;

namespace MoodAnalyze_Testing
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyzer moodAnalyzer;

        /// <summary>
        /// UC4.1 => Using Reflection Return Object or throw Custome Exception
        /// </summary>
        [TestMethod]
        public void Relection_ReturnDefaultConstructor()
        {
            object obj = null;
            MoodAnalyzer expected = new MoodAnalyzer();
            try
            {
                //Here We have CreateMoodAnalyzerObject static method 
                obj = MoodAnalyzerFactory.CreateMoodAnalyzerObject("MsTesting_Exceptions.MoodAnalyzer", "MoodAnalyzer");

            }
            catch (MoodAnalyzer_CustomException e)
            {
                throw new System.Exception(e.Message); //throwing Exception
            }
        }

        /// <summary>
        /// UC 4.2 => Using Reflection Return Object or throw Custome Exception
        /// </summary>

        [TestMethod]
        public void Using_Relection_CheckingOBJects_Throws_Exception_ClassNOtFound()
        {
            object expected = "Class Not Found!!";
            try
            {
                //Here We have CreateMoodAnalyzerObject static method 
                object obj = MoodAnalyzerFactory.CreateMoodAnalyzerObject("MsTesting_Exceptions1.MoodAnalyzer", "MoodAnalyzer");

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(e.Message, expected);//Here weare comparing message from the customeexception and our expected message
            }
        }

        /// <summary>
        /// UC 4.3 => Using Reflection Return Object or throw Custome Exception
        /// </summary>

        [TestMethod]
        public void Using_Relection_CheckingOBJects_Throws_Exception_ConstructorNotFound()
        {
            object expected = "Constructor Not Found!!";

            try
            {
                //Here We have CreateMoodAnalyzerObject static method 
                object obj = MoodAnalyzerFactory.CreateMoodAnalyzerObject("MsTesting_Exceptions.MoodAnalyzer", "MoodAnaly");

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(e.Message, expected);
            }
        }
    }
}