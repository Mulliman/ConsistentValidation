using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DateInPastAttributeTests : AttributeTestBase
    {
        public class DateInPastModelStringDate
        {
            [ConsistentDateInPast]
            public string DateToTest { get; set; }
        }

        public class DateInPastModelDateTimeDate
        {
            [ConsistentDateInPast]
            public DateTime DateToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateIsInPast_FromString_ItShouldBeValid()
        {
            var model = new DateInPastModelStringDate
            {
                DateToTest = DateTime.Now.AddDays(-1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateIsInPast_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInPastModelDateTimeDate
            {
                DateToTest = DateTime.Now.AddDays(-1)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateIsBeforeNow_FromString_ItShouldNotBeValid()
        {
            var model = new DateInPastModelStringDate
            {
                DateToTest = DateTime.Now.AddDays(1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateIsBeforeNow_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateInPastModelDateTimeDate
            {
                DateToTest = DateTime.Now.AddDays(1)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateIsEqualToTodaysDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateInPastModelStringDate
            {
                DateToTest = DateTime.Now.Date.ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateIsEqualToTodaysDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateInPastModelDateTimeDate
            {
                DateToTest = DateTime.Now.Date
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateOneDayInPast_FromString_ItShouldBeValid()
        {
            var model = new DateInPastModelStringDate
            {
                DateToTest = DateTime.Now.AddDays(-1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInPastAttributeTests_WhenDateToValidateOneDayInPast_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInPastModelDateTimeDate
            {
                DateToTest = DateTime.Now.AddDays(-1)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
