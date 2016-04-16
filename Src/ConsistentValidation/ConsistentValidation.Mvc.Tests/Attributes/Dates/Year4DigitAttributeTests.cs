using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class Year4DigitAttributeTests : AttributeTestBase
    {
        public class YearStringModel
        {
            [ConsistentYear4Digit]
            public string YearToTest { get; set; }
        }

        public class YearIntModel
        {
            [ConsistentYear4Digit]
            public int? YearToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateIsValid_FromString_ItShouldBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = (DateTime.Now.Year).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateIsValid_FromInt_ItShouldBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = DateTime.Now.Year
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        #endregion

        #region Invalid Cases

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateNotValid_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = "NotAnInt"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateNot4Digits_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = "0"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateNot4Digits_FromInt_ItShouldNotBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = 0
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateIs999_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = "999"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateIs999_FromInt_ItShouldNotBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = 999
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateIs10000_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = "10000"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearAttributeTests_WhenYearToValidateIs10000_FromInt_ItShouldNotBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = 10000
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        # endregion
    }
}
