namespace Alpha.ConfigurationSharing.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProI1ConfigurationTests : ConfigurationByEnvironmentTests
    {
        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            RelativeAppSettingsAndConnectionStringTestPath = "AppSettingsAndConnectionStringTest.proi1.config";
            WebConfigRelativePath = "Web.proi1.config";
            base.TestFixtureSetUp();
        }

        [Test]
        public override void ValidateAppSettings_LoadedAppSettings_ReturnCorrectItemLength()
        {
            base.ValidateAppSettings_LoadedAppSettings_ReturnCorrectItemLength();
        }

        [Test, TestCaseSource("ExpectedAppSettings")]
        public override void ValidateAppSettings_SupportKeyName_ReturnData(string keyName)
        {
            base.ValidateAppSettings_SupportKeyName_ReturnData(keyName);
        }

        [Test]
        public override void ValidateConnectionStrings_LoadedConnectionStrings_ReturnCorrectItemLength()
        {
            base.ValidateConnectionStrings_LoadedConnectionStrings_ReturnCorrectItemLength();
        }

        [Test, TestCaseSource("ExpectedConnectionsStrings")]
        public override void ValidateConnectionStrings_SupportConnectionName_ReturnData(string connectionName)
        {
            base.ValidateConnectionStrings_SupportConnectionName_ReturnData(connectionName);
        }

        [Test]
        public override void ValidateWebConfig_LoadedWebConfig_LoadCorrectConfig()
        {
            base.ValidateWebConfig_LoadedWebConfig_LoadCorrectConfig();
        }
    }
}
