using System;
using EasyConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleApp.MyKeys;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private ConfigService _unitUnderTest;
        private Mock<IConfigRepository> _configRepository;

        [TestInitialize]
        public void Init()
        {
            _configRepository = new Mock<IConfigRepository>();
            _unitUnderTest = new ConfigService(_configRepository.Object);
        }

        protected void SetupConfigRepo(string getOrCreateKey = null, string saveChangesValue = null)
        {
            _configRepository.Setup(x => x.GetOrCreateKey(It.IsAny<ConfigKey>())).Returns(getOrCreateKey);
            _configRepository.Setup(x => x.SaveChanges(It.IsAny<ConfigKey>(), saveChangesValue));
        }

        [TestMethod]
        public void GetValue()
        {
            var expected = 1;
            SetupConfigRepo(getOrCreateKey: expected.ToString());
            var result = _unitUnderTest.GetValue<NumberOfExecutions>();
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void SetValue()
        {
            SetupConfigRepo(getOrCreateKey: "1",
                saveChangesValue: "2");

            var number = _unitUnderTest.GetValue<NumberOfExecutions>();
            _unitUnderTest.SaveChanges(number.ChangeValue(number.Value + 1));
            _configRepository.Verify(x => x.SaveChanges(It.IsAny<ConfigKey>(), "2"), Times.Once());
        }
    }
}
