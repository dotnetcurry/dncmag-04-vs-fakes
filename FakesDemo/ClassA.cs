using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesDemo
{
    public interface ILogger{
        bool ShouldLog();
        void Log(string message);
    }

    public class ClassA
    {
        public string GetName(ILogger logger)
        {
            if (logger.ShouldLog()){
                logger.Log("log something");
                return "some name";
            }

            return string.Empty;
        }
    }


    public class ClassB
    {
        public static void DoomsDay()
        {
            if (DateTime.Now == new DateTime(2012, 12, 21))
                throw new Exception("Boom!");
        }


        //Do not try to delete C:\ in real life
        //For example we've pointed it to a 
        //relatively harmless C:\temp folder
        //which may or maynot exist on your 
        //machine. However since we are 
        //testing Shim Not Impletemented 
        //exception we will never hit this code
        public static void DeleteC()
        {
            Directory.Delete(@"c:\temp", true);
        }

    }
}
