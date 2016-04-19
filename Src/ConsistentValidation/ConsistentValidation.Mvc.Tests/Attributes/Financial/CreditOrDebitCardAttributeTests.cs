using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Financial;
using System;

namespace ConsistentValidation.Mvc.Tests.Attributes.Financial
{
    [TestClass]
    public class CreditOrDebitCardAttributeTests : AttributeTestBase
    {
        public class CreditCardStringModel
        {
            [ConsistentCreditOrDebitCard]
            public string CardNumber { get; set; }
        }

        private class CreditCardInvalidTypeModel
        {
            [ConsistentCreditOrDebitCard]
            public long CardNumber { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidVisaNumber_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel
            {
                CardNumber = "4111111111111111"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidVisaNumberWithDashes_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel
            {
                CardNumber = "4111-1111-1111-1111"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidVisaNumberWithSpaces_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel
            {
                CardNumber = "4111 1111 1111 1111"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidAmexCardNumber_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel { CardNumber = "378282246310005" };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidDiscoverCardNumber_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel { CardNumber = "6011111111111117" };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidDankortPbsCardNumber2_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel { CardNumber = "5019717010103742" };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidSwitchSoloCardNumber_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel { CardNumber = "6331101999990016" };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenValidDinersCardNumber_FromString_ItShouldBeValid()
        {
            var model = new CreditCardStringModel { CardNumber = "30569309025904" };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        #endregion

        #region Invalid Cases

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenContainsInvalidChars_FromString_ItShouldNotBeValid()
        {
            var model = new CreditCardStringModel
            {
                CardNumber = "41111%11111^1111"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenInvalidCardNumber_FromString_ItShouldNotBeValid()
        {
            var model = new CreditCardStringModel
            {
                CardNumber = "4111101111101111"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void CreditOrDebitCardAttributeTests_WhenInvalidPropertyType_FromString_ItShouldNotBeValid()
        {
            var model = new CreditCardInvalidTypeModel
            {
                CardNumber = 4111101111101111
            };

            var threwCorrectException = false;

            try
            {
                var errors = ValidateModel(model);
            }
            catch (InvalidOperationException)
            {
                threwCorrectException = true;
            }
            
            Assert.IsTrue(threwCorrectException);
        }

        #endregion
    }
}
