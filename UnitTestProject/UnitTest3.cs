using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using pr7_regist;
using System.Windows.Controls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var page3 = new AuthPage();
            Assert.IsTrue(page3.Auth("Elizor@gmai,com", "yntiRS"));
            Assert.IsTrue(page3.Auth("Vladlena@gmai.com", "07i7Lb"));
            Assert.IsTrue(page3.Auth("Adam@gmai.com", "7SP9CV"));
            Assert.IsFalse(page3.Auth("Kar@gmai.com", "6QF1WB"));
            Assert.IsTrue(page3.Auth("Yli@gmai.com", "GwffgE"));
            Assert.IsTrue(page3.Auth("Vasilisa@gmai.com", "d7iKKV"));
            Assert.IsTrue(page3.Auth("Galina@gmai.com", "8KC7wJ"));
            Assert.IsTrue(page3.Auth("Miron@@gmai,com", "x58OAN"));
            Assert.IsTrue(page3.Auth("Vseslava@gmai.com", "fhDSBf"));
            Assert.IsFalse(page3.Auth("Victoria@gmai.com", "9mlPQJ"));
            Assert.IsTrue(page3.Auth("Anisa@gmai.com", "Wh4OYm"));
            Assert.IsTrue(page3.Auth("Feafan@@gmai,com", "Kc1PeS"));
        }
    }
}
