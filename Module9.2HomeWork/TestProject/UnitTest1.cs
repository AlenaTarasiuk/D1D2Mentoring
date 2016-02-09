using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersFibonacci;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        Fibonacci objNumberFibonacci;
        Fibonacci objNumberRedis;

        [TestInitialize]
        public void Initialize()
        {
            objNumberFibonacci = new Fibonacci(new CacheNumbers());
            objNumberRedis = new Fibonacci(new CacheNumbersRedis());
        }

        [TestMethod]
        public void TestFibonacciForNumber2()
        {
            int expected = 2;

            Assert.AreEqual(expected, objNumberFibonacci.GetNumber(2));
        }

        [TestMethod]
        public void TestFibonacciForNumber7()
        {
            int expected = 7;

            Assert.AreEqual(expected, objNumberFibonacci.GetNumber(7));
        }


        [TestMethod]
        public void TestFibonacciRedisForNumber2()
        {
            int expected = 2;

            Assert.AreEqual(expected, objNumberRedis.GetNumber(2));
        }

        [TestMethod]
        public void TestFibonacciRedisForNumber7()
        {
            int expected = 7;

            Assert.AreEqual(expected, objNumberRedis.GetNumber(7));
        }
    }
}
