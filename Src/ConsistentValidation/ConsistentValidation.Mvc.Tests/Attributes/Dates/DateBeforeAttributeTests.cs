using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DateBeforeAttributeTests : AttributeTestBase
    {
        public class DateBeforeModelStringDate
        {
            [ConsistentDateBefore("2000-01-01")]
            public string DateToTest { get; set; }
        }

        public class DateBeforeModelDateTimeDate
        {
            [ConsistentDateBefore("2000-01-01")]
            public DateTime DateToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateIsBeforeSetDate_FromString_ItShouldBeValid()
        {
            var model = new DateBeforeModelStringDate
            {
                DateToTest = "1999-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateIsBeforeSetDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateBeforeModelDateTimeDate
            {
                DateToTest = new DateTime(1999,01,01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateIsBeforeSetDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateBeforeModelStringDate
            {
                DateToTest = "2001-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateIsBeforeSetDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateBeforeModelDateTimeDate
            {
                DateToTest = new DateTime(2001, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateIsEqualToSetDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateBeforeModelStringDate
            {
                DateToTest = "2000-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateIsEqualToSetDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateBeforeModelDateTimeDate
            {
                DateToTest = new DateTime(2000, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateOneDayBeforeSetDate_FromString_ItShouldBeValid()
        {
            var model = new DateBeforeModelStringDate
            {
                DateToTest = "1999-12-31"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateBeforeAttributeTests_WhenDateToValidateOneDayBeforeSetDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateBeforeModelDateTimeDate
            {
                DateToTest = new DateTime(1999, 12, 31)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
