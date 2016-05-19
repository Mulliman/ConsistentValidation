using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsistentValidation.Mvc.Attributes.Names;

namespace ConsistentValidation.Mvc.Tests.Attributes.Financial
{
    [TestClass]
    public class FirstNameAttributeTests : AttributeTestBase
    {
        public class NameModel
        {
            [ConsistentFirstName]
            public string FirstName { get; set; }
        }

        #region Valid Cases

        [TestMethod]
        public void FirstNameAttributeTests_WhenNameIsValid_ItShouldBeValid()
        {
            var model = new NameModel
            {
                FirstName = "sam"
            };

            var errors = ValidateModel(model);

            Assert.IsTrue(!errors.Any());
        }

        #endregion
    }
}