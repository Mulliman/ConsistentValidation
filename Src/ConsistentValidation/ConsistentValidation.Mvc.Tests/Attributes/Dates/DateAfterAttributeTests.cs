using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DateAfterAttributeTests : AttributeTestBase
    {
        public class DateAfterModelStringDate
        {
            [ConsistentDateAfter("2000-01-01")]
            public string DateToTest { get; set; }
        }

        public class DateAfterModelDateTimeDate
        {
            [ConsistentDateAfter("2000-01-01")]
            public DateTime DateToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void WhenDateToValidateIsAfterSetDate_FromString_ItShouldBeValid()
        {
            var model = new DateAfterModelStringDate
            {
                DateToTest = "2001-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void WhenDateToValidateIsAfterSetDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateAfterModelDateTimeDate
            {
                DateToTest = new DateTime(2001,01,01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void WhenDateToValidateIsBeforeSetDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateAfterModelStringDate
            {
                DateToTest = "1999-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void WhenDateToValidateIsBeforeSetDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateAfterModelDateTimeDate
            {
                DateToTest = new DateTime(1999, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void WhenDateToValidateIsEqualToSetDate_FromString_ItShouldNotBeValid()
        {
            var model = new DateAfterModelStringDate
            {
                DateToTest = "2000-01-01"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void WhenDateToValidateIsEqualToSetDate_FromDateTime_ItShouldNotBeValid()
        {
            var model = new DateAfterModelDateTimeDate
            {
                DateToTest = new DateTime(2000, 01, 01)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void WhenDateToValidateOneDayAfterSetDate_FromString_ItShouldBeValid()
        {
            var model = new DateAfterModelStringDate
            {
                DateToTest = "2000-01-02"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void WhenDateToValidateOneDayAfterSetDate_FromDateTime_ItShouldBeValid()
        {
            var model = new DateAfterModelDateTimeDate
            {
                DateToTest = new DateTime(2000, 01, 02)
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
