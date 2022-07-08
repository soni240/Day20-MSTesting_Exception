using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSTesting_Exceptions
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyzerObject(string ClassName, string ConstructorName)
        {
            string x = @"." + ConstructorName + "$";
            Match MatchClassName = Regex.Match(ClassName, x);
            if (MatchClassName.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type MoodAnalyzertype = assembly.GetType(ClassName);
                    var res = Activator.CreateInstance(MoodAnalyzertype);
                    return res;
                }
                catch (Exception e)
                {
                    throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found!!");
                }
            }

            else
            {
                throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor Not Found!!");
            }

        }

        public static object CreateObjectOfPramMoodAnalyzer(string ClassName, string ConstructorName, string message)
        {
            Type type = typeof(MoodAnalyzer); //creating type object of type moodanalyzerclass
            if (type.FullName.Equals(ClassName))//checking type.fullName and class name are equal or not
            {
                if (type.Name.Equals(ConstructorName))//checking type.Name and constructor name are equal or not
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });//creating instamce of  typeof string instance of type moodanalyzer
                    var obj = constructorInfo.Invoke(new object[] { message });//invoking constructor of MoodAnalyzer Class
                    return obj;
                }
                else
                {
                    throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor Not Found!!");//throwing custome exception
                }
            }

            else
            {
                throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found!!");//throwing custome exception
            }
            return default;
        }

        public static object Invoking_MoodAnalyzer_AnalyzeMood_Methd(string message, string methodname)
        {
            try
            {
                if (message != null)
                {
                    Type type = typeof(MoodAnalyzer);//creating instance of type moodanalyzer using reflection
                    MethodInfo methodinfo = type.GetMethod(methodname);
                    object MoodAnalyzerObject = MoodAnalyzerFactory.CreateObjectOfPramMoodAnalyzer("MsTesting_Exceptions.MoodAnalyzer", "MoodAnalyzer", message);
                    object info = methodinfo.Invoke(MoodAnalyzerObject, null);
                    return info.ToString();
                }
                else
                {
                    throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.EMPTY_MESSAGE, "Message should not be null!!");
                }

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_METHOD, "Method Not Found!!");
            }

        }

    }
}

