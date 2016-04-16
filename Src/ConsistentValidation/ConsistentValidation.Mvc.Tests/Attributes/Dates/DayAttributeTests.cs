using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class DayAttributeTests : AttributeTestBase
    {
        public class DayStringModel
        {
            [ConsistentDay]
            public string DayToTest { get; set; }
        }

        public class DayIntModel
        {
            [ConsistentDay]
            public int? DayToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateIsValid_FromString_ItShouldBeValid()
        {
            var model = new DayStringModel
            {
                DayToTest = "10"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateIsValid_FromInt_ItShouldBeValid()
        {
            var model = new DayIntModel
            {
                DayToTest = 10
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateTooBig_FromString_ItShouldNotBeValid()
        {
            var model = new DayStringModel
            {
                DayToTest = "32"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateTooBig_FromInt_ItShouldNotBeValid()
        {
            var model = new DayIntModel
            {
                DayToTest = 32
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateTooSmall_FromString_ItShouldNotBeValid()
        {
            var model = new DayStringModel
            {
                DayToTest = "0"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateTooSmall_FromInt_ItShouldNotBeValid()
        {
            var model = new DayIntModel
            {
                DayToTest = 0
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateIs1st_FromString_ItShouldBeValid()
        {
            var model = new DayStringModel
            {
                DayToTest = "1"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateIs1st_FromInt_ItShouldBeValid()
        {
            var model = new DayIntModel
            {
                DayToTest = 1
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateIs31st_FromString_ItShouldBeValid()
        {
            var model = new DayStringModel
            {
                DayToTest = "31"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void DayAttributeTests_WhenDayToValidateIs31st_FromInt_ItShouldBeValid()
        {
            var model = new DayIntModel
            {
                DayToTest = 31
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
