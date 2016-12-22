namespace Alpha.ConfigurationSharing.Tests
{
    using NUnit.Framework;
    using System;
    using System.IO;

    [TestFixture]
    public class ConfigurationTests
    {
        private string baseDirectory;

        private ConfigurationLoader configurationLoader;

        [SetUp]
        public void SetUp()
        {
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!baseDirectory.EndsWith("\\"))
            {
                baseDirectory += "\\";
            }

            configurationLoader = new ConfigurationLoader();
        }

        [TestCase("Web.config")]
        [TestCase("Web.backupMNLExNap.config")]
        [TestCase("Web.backupMNLI1.config")]
        [TestCase("Web.backupMNLNap.config")]
        [TestCase("Web.napexternal.config")]
        [TestCase("Web.napinternal.config")]
        [TestCase("Web.proi1.config")]
        [TestCase("Web.sit.config")]
        [TestCase("Web.uati1.config")]
        [TestCase("AppSettingsAndConnectionStringTest.config")]
        [TestCase("AppSettingsAndConnectionStringTest.backupMNLExNap.config")]
        [TestCase("AppSettingsAndConnectionStringTest.backupMNLI1.config")]
        [TestCase("AppSettingsAndConnectionStringTest.backupMNLNap.config")]
        [TestCase("AppSettingsAndConnectionStringTest.napexternal.config")]
        [TestCase("AppSettingsAndConnectionStringTest.napinternal.config")]
        [TestCase("AppSettingsAndConnectionStringTest.proi1.config")]
        [TestCase("AppSettingsAndConnectionStringTest.sit.config")]
        [TestCase("AppSettingsAndConnectionStringTest.uati1.config")]
        public void LoadAppSettings_ExistFile_ReturnNotNullConfiguration(string relativeFilePath)
        {
            // Arrange 
            var appSettingPath = baseDirectory + relativeFilePath;

            // Action
            var configuration = configurationLoader.LoadConfigurations(appSettingPath);

            // Assert
            Assert.IsNotNull(configuration);
        }

        [TestCase("")]
        [TestCase("Web.AppSettings.local1.config")]
        public void LoadAppSettings_NotExistFile_ThrowsFileNotFoundException(string fileName)
        {
            // Arrange 
            var appSettingPath = baseDirectory + fileName;

            // Action & Assert
            Assert.Throws<FileNotFoundException>(new TestDelegate(() => configurationLoader.LoadConfigurations(appSettingPath)));
        }
    }
}
