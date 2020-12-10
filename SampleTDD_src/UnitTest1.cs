//ref: https://github.com/carlosschults/string-calculator-kata
using NUnit.Framework;
using System;

namespace SampleTDD.UTest
{
    public class Tests
    {


        [TestCase("not.a.valid.address")]
        [TestCase("test@yprova.it")]
        public void CheckEmail_Valid(string values)
        {
            Assert.AreEqual(true, UserData.CheckEmail(values));
        }

        [TestCase("P@ssw0rd12")] //Valid
        [TestCase("assT123L3444")] //Not valid
        [TestCase("Pa$$wd1")] //Not valid
        public void CheckPwd_Valid(string pwds)
        {
            Assert.AreEqual(true, UserData.CheckPwd(pwds));
        }

        [TestCase("4512111111111111")] //Valid
        [TestCase("5555000000000004")] //Valid
        [TestCase("555500000000000433")] //Not valid
        [TestCase("asrft67jn2y5rg1s")] //Not valid
        public void CheckCC_No_Valid(string numbers)
        {
            Assert.AreEqual(true, UserData.CheckCC_No(numbers));
        }

        [TestCase("10/21")] //valid
        [TestCase("09/2020")] //Not valid
        [TestCase("09/25")] //Not valid
        [TestCase("aa\rrrrrr")] //Not valid
        public void CheckCC_Date_Valid(string dates)
        {
            Assert.AreEqual(true, UserData.CheckCC_Date(dates));
        }

        [TestCase("152")] //Valid
        [TestCase("abc")] //Not valid
        [TestCase("1468")] //Not valid
        public void CheckCC_CVV_Valid(string cvvs)
        {
            Assert.AreEqual(true, UserData.CheckCC_CVV(cvvs));
        }

       
    }
}