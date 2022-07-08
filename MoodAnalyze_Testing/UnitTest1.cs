using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTesting_Exceptions;

namespace MoodAnalyze_Testing
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
                actual = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MSTesting_Exceptions.MoodAnalyzer", "MoodAnalyzer", Message);

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
                actual = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MsTesting_Exceptions.MoodAna", "MoodAnalyzer", message);

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
                object obj = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MsTesting_Exceptions.MoodAnalyzer", "MoodAnaly", "Constructor Not Found!!");

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(e.Message, expected);
            }
        }

        /// <summary>
        /// UC 6.1 => Using Reflection_passingProperMessage_Return_Happy Mood
        /// </summary>

        [TestMethod]
        public void Using_Relection_Paasing_ProperMessage_IaminHappyMood_Return_HAPPY()
        {
            string expected = "HAPPY";

            //Here We have CreateMoodAnalyzerObject static method 
            object actual = MoodAnalyzerFactory.Invoking_MoodAnalyzer_AnalyzeMood_Methd("I am in Happy Mood", "AnalyzeMood");
            Assert.AreEqual(actual, expected);

        }

        /// <summary>
        /// UC 6.2 => Using Reflection_passingImProperMethodNAme_Throw_CustomeException
        /// </summary>

        [TestMethod]
        public void Using_Relection_Paasing_ImProperMethodName_Throw_CustomeException()
        {
            string message = "HAPPY";
            string expected_Exception = "Method Not Found!!";
            try
            {
                //Here We have CreateMoodAnalyzerObject static method 
                object actual = MoodAnalyzerFactory.Invoking_MoodAnalyzer_AnalyzeMood_Methd("I am in Happy Mood", "Fake_AnalyzeMood");
                Assert.AreEqual(actual, message);

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(expected_Exception, e.Message);
            }

        }

        /// <summary>
        /// UC 6.3 => Using Reflection_passingNUllMessage_Throw_CustomeException
        /// </summary>
        [TestMethod]
        public void Using_Relection_Paasing_NullMessage_Throw_CustomeException()
        {
            string message = null;
            string expected_Exception = "Message should not be null!!";
            try
            {
                //Here We have CreateMoodAnalyzerObject static method 
                object actual = MoodAnalyzerFactory.Invoking_MoodAnalyzer_AnalyzeMood_Methd(message, "AnalyzeMood");
                Assert.AreEqual(actual, message);

            }
            catch (MoodAnalyzer_CustomException e)
            {
                Assert.AreEqual(expected_Exception, e.Message);
            }

        }
    }

}
