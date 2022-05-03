using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjektReader;
using System;
using System.Dynamic;

namespace DynamicObjectTests
{
    [TestClass]
    public class UnitTest1
    {
        string path = @"C:\tmp\treubuch\Data\TestData.txt";

        [TestMethod]
        public void IsPropertyAccesWorking()
        {
            dynamic rofReader = new ReadOnlyFileReader(path);

            // TryGetMember
            foreach (string item in rofReader.Customer)
            {
                Console.WriteLine(item);
            }

        }

        [TestMethod]
        public void IsParameterizedAccessWorking()
        {
            dynamic rofReader = new ReadOnlyFileReader(path);

            // using TryInvokeMember
            foreach (string item in rofReader.Customer(StringSearchOption.Contains, true))
            {
                Console.WriteLine(item);
            }

        }

    }
}
