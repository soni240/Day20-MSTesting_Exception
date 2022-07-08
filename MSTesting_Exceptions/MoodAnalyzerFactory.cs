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
            Type type = typeof(MoodAnalyzer);
            if (type.FullName.Equals(ClassName))
            {
                if (type.Name.Equals(ConstructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return Convert.ToString(obj);
                }
                else
                {
                    throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor Not Found!!");
                }
            }

            else
            {
                throw new MoodAnalyzer_CustomException(MoodAnalyzer_CustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found!!");
            }
            return default;
        }
    }
}
