namespace Alpha.ConfigurationSharing.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Real2ConfigurationTests : ConfigurationByEnvironmentTests
    {
        // We must use this property because NUnit can't load ExpectedAppSettings from base class
        public static string[] ExpectedAppSettingsChild
        {
            get
            {
                return ExpectedAppSettings;
            }
        }

        [OneTimeSetUp]
        public override void TestFixtureSetUp()
        {
            RelativeAppSettingsAndConnectionStringTestPath = "AppSettingsAndConnectionStringTest.local2.config";
            WebConfigRelativePath = "Web.local2.config";
            base.TestFixtureSetUp();
        }

        //[Test]
        //public override void ValidateAppSettings_LoadedAppSettings_ReturnCorrectItemLength()
        //{
        //    base.ValidateAppSettings_LoadedAppSettings_ReturnCorrectItemLength();
        //}

        [Test, TestCaseSource("ExpectedAppSettingsChild")]
        public override void ValidateAppSettings_SupportKeyName_ReturnData(string keyName)
        {
            base.ValidateAppSettings_SupportKeyName_ReturnData(keyName);
        }

        [Test]
        public override void ValidateConnectionStrings_LoadedConnectionStrings_ReturnCorrectItemLength()
        {
            base.ValidateConnectionStrings_LoadedConnectionStrings_ReturnCorrectItemLength();
        }

        [TestCase("CS_BackupDB")]
        [TestCase("CS_ArchiveDB")]
        [TestCase("LiveCasinoAdmin")]
        [TestCase("IPEntities")]
        [TestCase("DBCust.IPDB.wsv_alp")]
        [TestCase("DBCust.CustDB.wsv_alp")]
        [TestCase("DBTXN.BODB02.wsv_alp")]
        [TestCase("DBTXN.CustDB.wsv_alp")]
        [TestCase("DBONUSER.ON_USER.wsv_alp")]
        [TestCase("DBPOLICY.bodb02.wsv_alp")]
        [TestCase("DBLOG.bodb_CustomerLog.wsv_alp")]
        [TestCase("DBAGE.bodb_AGE.wsv_alp")]
        [TestCase("DBAGE.bodb02.wsv_alp")]
        [TestCase("DBARC.bodb_Archive.wsv_alp")]
        [TestCase("DBACC.bodb02.wsv_alp")]
        [TestCase("DBRPT.bodb_report.wsv_alp")]
        [TestCase("DBMSG.bodb_Message.wsv_alp")]
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
