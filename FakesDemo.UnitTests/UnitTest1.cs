using System;
using System.Fakes;
using System.IO.Fakes;
using FakesDemo.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakesDemo;

namespace FakesDemo.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2012, 12, 21);
                ClassB.DoomsDay();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (ShimsContext.Create())
            {
                ShimDirectory.BehaveAsNotImplemented();
                ClassB.DeleteC();
            }
        }



        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            var stubLogger = new StubILogger {ShouldLog = () => true};
            var sut = new ClassA();
            var observer = new StubObserver();
            stubLogger.InstanceObserver = observer;
            
            //Act
            sut.GetName(stubLogger);
            
            var calls = observer.GetCalls();

        }
    }
}
