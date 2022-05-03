using EierfamBl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsPrintOutOfListWorking()
        {
            List<Huhn> huehner = new List<Huhn>();

            huehner.Add(new Huhn("Huhn1"));
            huehner.Add(new Huhn("Huhn2"));
            huehner.Add(new Huhn("Huhn3"));
            huehner.Add(new Huhn("Huhn4"));
            huehner.Add(new Huhn("Huhn5"));

            huehner.PrintOut();

        }
    }
}
