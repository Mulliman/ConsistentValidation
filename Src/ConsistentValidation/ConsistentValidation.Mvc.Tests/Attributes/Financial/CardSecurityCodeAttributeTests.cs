using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Financial;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Financial
{
    [TestClass]
    public class CardSecurityCodeAttributeTests : AttributeTestBase
    {
        public class YearStringModel
        {
            [ConsistentCardSecurityCode]
            public string Code { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void CardSecurityCodeAttributeTests_WhenCscIsValid_FromString_ItShouldBeValid()
        {
            var model = new YearStringModel
            {
                Code = "111"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        #endregion

        #region Invalid Cases

        [TestMethod]
        public void CardSecurityCodeAttributeTests_WhenInvalidCharacterString_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                Code = "NotACode"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        public void CardSecurityCodeAttributeTests_WhenInvalidCharacterStringCorrectLength_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                Code = "XXX"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void CardSecurityCodeAttributeTests_WhenTooFewNumbers_FromString_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                Code = "99"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void CardSecurityCodeAttributeTests_WhenTooManyNumbers_FromInt_ItShouldNotBeValid()
        {
            var model = new YearStringModel
            {
                Code = "9999"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        #endregion

        #region Boundary Cases

        [TestMethod]
        public void CardSecurityCodeAttributeTests_When000_FromString_ItShouldBeValid()
        {
            var model = new YearStringModel
            {
                Code = "000"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CardSecurityCodeAttributeTests_When999_FromInt_ItShouldBeValid()
        {
            var model = new YearStringModel
            {
                Code = "999"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        # endregion
    }
}
