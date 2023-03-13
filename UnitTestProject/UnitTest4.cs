using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using pr7_regist;
using System;
using System.Windows.Controls;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void RegistrationTestSuccess()
        {
            var page4 = new RegPage();
            Assert.IsTrue(page4.Registr("E_enwni@gmail.com", "srewffd", "srewffd", "Комолов Даниил Андреевич"));
            Assert.IsTrue(page4.Registr("Vlssdyeiiooqkjncwsa@gmai.com", "07i7Lbsasas", "07i7Lbsasas", "Циргвава Анастасия Васильевна"));
            Assert.IsTrue(page4.Registr("hwhqudsdasdsfassa@gmai.com", "11111111", "11111111", "Скоблюк Мария Александровна"));
        }
    }
}
