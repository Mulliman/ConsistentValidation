using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DayOfWeekAttributeTests : AttributeTestBase
    {
        public class DayOfWeekStringModel
        {
            [ConsistentDayOfWeek]
            public string DayToTest { get; set; }
        }

        public class DayOfWeekIntModel
        {
            [ConsistentDayOfWeek]
            public int? DayToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateIsValid_FromString_ItShouldBeValid()
        {
            var model = new DayOfWeekStringModel
            {
                DayToTest = "5"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateIsValid_FromInt_ItShouldBeValid()
        {
            var model = new DayOfWeekIntModel
            {
                DayToTest = 5
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateTooBig_FromString_ItShouldNotBeValid()
        {
            var model = new DayOfWeekStringModel
            {
                DayToTest = "10"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateTooBig_FromInt_ItShouldNotBeValid()
        {
            var model = new DayOfWeekIntModel
            {
                DayToTest = 10
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateIsSunday_FromString_ItShouldBeValid()
        {
            var model = new DayOfWeekStringModel
            {
                DayToTest = "0"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateIsSunday_FromInt_ItShouldBeValid()
        {
            var model = new DayOfWeekIntModel
            {
                DayToTest = 0
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateIsSaturday_FromString_ItShouldBeValid()
        {
            var model = new DayOfWeekStringModel
            {
                DayToTest = "6"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayOfWeekAttributeTests_WhenDayOfWeekToValidateIsSaturday_FromInt_ItShouldBeValid()
        {
            var model = new DayOfWeekIntModel
            {
                DayToTest = 6
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
