using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Dates;

namespace ConsistentValidation.Mvc.Tests.Attributes.Dates
{
    [TestClass]
    public class MonthAttributeTests : AttributeTestBase
    {
        public class MonthStringModel
        {
            [ConsistentMonth]
            public string MonthToTest { get; set; }
        }

        public class MonthIntModel
        {
            [ConsistentMonth]
            public int? MonthToTest { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateIsValid_FromString_ItShouldBeValid()
        {
            var model = new MonthStringModel
            {
                MonthToTest = "6"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateIsValid_FromInt_ItShouldBeValid()
        {
            var model = new MonthIntModel
            {
                MonthToTest = 6
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion

        #region Invalid Cases

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateTooBig_FromString_ItShouldNotBeValid()
        {
            var model = new MonthStringModel
            {
                MonthToTest = "13"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateTooBig_FromInt_ItShouldNotBeValid()
        {
            var model = new MonthIntModel
            {
                MonthToTest = 13
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateTooSmall_FromString_ItShouldNotBeValid()
        {
            var model = new MonthStringModel
            {
                MonthToTest = "0"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateTooSmall_FromInt_ItShouldNotBeValid()
        {
            var model = new MonthIntModel
            {
                MonthToTest = 0
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateIsJan_FromString_ItShouldBeValid()
        {
            var model = new MonthStringModel
            {
                MonthToTest = "1"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateIsJan_FromInt_ItShouldBeValid()
        {
            var model = new MonthIntModel
            {
                MonthToTest = 1
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateIsDec_FromString_ItShouldBeValid()
        {
            var model = new MonthStringModel
            {
                MonthToTest = "12"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void MonthAttributeTests_WhenMonthToValidateIsDec_FromInt_ItShouldBeValid()
        {
            var model = new MonthIntModel
            {
                MonthToTest = 12
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
