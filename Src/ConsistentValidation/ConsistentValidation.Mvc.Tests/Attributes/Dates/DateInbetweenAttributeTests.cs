using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DateInbetweenAttributeTests : AttributeTestBase
    {
        public class DateInbetweenModelStringDate
        {
            [ConsistentDateInbetween("2000-01-01", "2001-01-01")]
            public string DateToTest { get; set; }
        }

        public class DateInbetweenModelDateTimeDate
        {
            [ConsistentDateInbetween("2000-01-01", "2001-01-01")]
            public DateTime DateToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsInbetweenSetDate_FromString_ItShouldBeValid()
        {
            var model = new DateInbetweenModelStringDate
            {
                DateToTest = "2000-06-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsInbetweenSetDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInbetweenModelDateTimeDate
            {
                DateToTest = new DateTime(2000,06,01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsBeforeSetDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateInbetweenModelStringDate
            {
                DateToTest = "1999-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsBeforeSetDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateInbetweenModelDateTimeDate
            {
                DateToTest = new DateTime(1999, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        public void DateInbetweenAttributeTests_WhenDateToValidateIsAfterSetDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateInbetweenModelStringDate
            {
                DateToTest = "2002-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsAfterSetDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateInbetweenModelDateTimeDate
            {
                DateToTest = new DateTime(2002, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsEqualToSetStartDate_FromString_ItShouldBeValid()
        {
            var model = new DateInbetweenModelStringDate
            {
                DateToTest = "2000-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsEqualToSetStartDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInbetweenModelDateTimeDate
            {
                DateToTest = new DateTime(2000, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsEqualToSetEndDate_FromString_ItShouldBeValid()
        {
            var model = new DateInbetweenModelStringDate
            {
                DateToTest = "2001-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DateInbetweenAttributeTests_WhenDateToValidateIsEqualToSetEndDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateInbetweenModelDateTimeDate
            {
                DateToTest = new DateTime(2001, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
