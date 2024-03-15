namespace Alpha.ConfigurationSharing.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class NapInternal2ConfigurationTests : ConfigurationByEnvironmentTests
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
            RelativeAppSettingsAndConnectionStringTestPath = "AppSettingsAndConnectionStringTest.napinternal2.config";
            WebConfigRelativePath = "Web.napinternal2.config";
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

        [TestCase("CS_BackupDB")]
        [TestCase("CS_ArchiveDB")]
        [TestCase("LiveCasinoAdmin")]
        [TestCase("IPEntities")]
        [TestCase("DBCust.IPDB.wsv_alp")]
        [TestCase("DBCust.CustDB.wsv_alpv")]
        [TestCase("DBTXN.BODB02.wsv_alpv")]
        [TestCase("DBTXN.CustDB.wsv_alpv")]
        [TestCase("DBONUSER.ON_USER.wsv_alpv")]
        [TestCase("DBPOLICY.bodb02.wsv_alpv")]
        [TestCase("DBLOG.bodb_CustomerLog.wsv_alpv")]
        [TestCase("DBAGE.bodb_AGE.wsv_alpv")]
        [TestCase("DBAGE.bodb02.wsv_alpv")]       
        [TestCase("DBARC.bodb_Archive.wsv_alpv")]
        [TestCase("DBACC.bodb02.wsv_alpv")]
        [TestCase("DBRPT.bodb_report.wsv_alpv")]
        [TestCase("DBMSG.bodb_Message.wsv_alpv")]
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
