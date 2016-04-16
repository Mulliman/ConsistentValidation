using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DateInFutureAttributeTests : AttributeTestBase
    {
        public class DateInFutureModelStringDate
        {
            [ConsistentDateInFuture]
            public string DateToTest { get; set; }
        }

        public class DateInFutureModelDateTimeDate
        {
            [ConsistentDateInFuture]
            public DateTime DateToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateIsInFuture_FromString_ItShouldBeValid()
        {
            var model = new DateInFutureModelStringDate
            {
                DateToTest = DateTime.Now.AddDays(1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateIsInFuture_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInFutureModelDateTimeDate
            {
                DateToTest = DateTime.Now.AddDays(1)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateIsBeforeToday_FromString_ItShouldNotBeValid()
        {
            var model = new DateInFutureModelStringDate
            {
                DateToTest = DateTime.Now.AddDays(-1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateIsBeforeToday_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateInFutureModelDateTimeDate
            {
                DateToTest = DateTime.Now.AddDays(-1)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateIsEqualToTodaysDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateInFutureModelStringDate
            {
                DateToTest = DateTime.Now.Date.ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateIsEqualToTodaysDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateInFutureModelDateTimeDate
            {
                DateToTest = DateTime.Now.Date
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateOneDayInFuture_FromString_ItShouldBeValid()
        {
            var model = new DateInFutureModelStringDate
            {
                DateToTest = DateTime.Now.AddDays(1).ToString()
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInFutureAttributeTests_WhenDateToValidateOneDayInFuture_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInFutureModelDateTimeDate
            {
                DateToTest = DateTime.Now.AddDays(1)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
