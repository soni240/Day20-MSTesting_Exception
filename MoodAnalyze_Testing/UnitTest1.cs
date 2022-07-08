using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTesting_Exceptions;

namespace MoodAnalyze_Testing_uc5
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyzer moodAnalyzer;

        /// <summary>
        /// UC5.1 => Using Reflection return moodanalyzer object
        /// </summary>
        [TestMethod]
        public void Reflection_withCorrectclassName_CorrectConstrutorName_ReturnsMoodAnalyzerObj()
        {
            string Message = "I am in Sad Mood";
            MoodAnalyzer expected = new MoodAnalyzer(Message);
            object actual = null;
            try
            {

                //Here We have CreateMoodAnalyzerObject static method 
                actual = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MsTesting_Exceptions.MoodAnalyzer", "MoodAnalyzer", Message);

            }
            catch (MoodAnalyzer_CustomException e)
            {
                throw new System.Exception(e.Message); //throwing Exception
            }
            actual.Equals(expected);
        }

        /// <summary>
        /// UC 5.2 => Using Reflection_passsing Wrong class NAme_throw Custome Exception
        /// </summary>

        [TestMethod]
        public void Using_Relection_Paasing_WrongClassName_Throws_Exception_ClassNOtFound()
        {
            string message = "Class Not Found!!";
            object actual = null;
            try
            {
                actual = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MsTesting_Exceptions.MoodAnalyzer", "MoodAnalyzer", message);

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(message, e.Message);
            }
        }

        /// <summary>
        /// UC 5.3 => Using Reflection_passingWrongContructorName_throw Custome Exception
        /// </summary>

        [TestMethod]
        public void Using_Relection_Paasing_WrongConstructorName_Throws_Exception_ConstructorNOtFound()
        {
            object expected = "Constructor Not Found!!";

            try
            {
                //Here We have CreateMoodAnalyzerObject static method 
                object obj = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MSTesting_Exceptions.MoodAnalyzer", "MoodAnaly", "Constructor Not Found!!");

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(e.Message, expected);
            }
        }
    }
}