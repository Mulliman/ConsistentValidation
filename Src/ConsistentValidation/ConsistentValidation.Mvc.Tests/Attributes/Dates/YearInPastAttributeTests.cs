using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class YearInPastAttributeTests : AttributeTestBase
    {
        public class YearStringModel
        {
            [ConsistentYearInPast]
            public string YearToTest { get; set; }
        }

        public class YearIntModel
        {
            [ConsistentYearInPast]
            public int? YearToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void YearInPastAttributeTests_WhenYearToValidateIsValid_FromString_ItShouldBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = (DateTime.Now.Year - 1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void YearInPastAttributeTests_WhenYearToValidateIsValid_FromInt_ItShouldBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = DateTime.Now.Year - 1
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        #endregion

        #region Invalid Cases

        [TestMethod]
        public void YearInPastAttributeTests_WhenYearToValidateInPast_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = "3000"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearInPastAttributeTests_WhenYearToValidateInPast_FromInt_ItShouldNotBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = 3000
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void YearInPastAttributeTests_WhenYearToValidateIsThisYear_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                YearToTest = (DateTime.Now.Year).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void YearInPastAttributeTests_WhenYearToValidateIsThisYear_FromInt_ItShouldNotBeValid()
        {
            var model = new YearIntModel
            {
                YearToTest = DateTime.Now.Year
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        # endregion
    }
}
