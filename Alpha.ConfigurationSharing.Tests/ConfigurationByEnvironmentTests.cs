namespace Alpha.ConfigurationSharing.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using NUnit.Framework;

    [TestFixture]
    public class ConfigurationByEnvironmentTests
    {
        public static string[] ExpectedAppSettings
        {
            get
            {
                return new string[]
                 {
                    "webpages:Version",
                    "vs:EnableBrowserLink",
                    "EnableNumberGroup",
                    "Disabled_NumberGame",
                    "Disabled_NumberCommission",
                    "Disabled_BingoCommission",
                    "Disabled_BingoMaxTransfer",
                    "Disabled_BingoStatus",
                    "Disabled_NumberGameStatus",
                    "EnableP2P",
                    "EnableLiveCasino",
                    "EnableVirtualSports",
                    "EnableKeno",
                    "EnableHRFixedOdds",
                    "EnableBingo",
                    "EnableDoubleCommission",
                    "EnableSessionValidatingService",
                    "EnableMemberWinLimit",
                    "Disable151_31",
                    "DisabledFI",
                    "IsShowTennisOtherBettype",
                    "IsAllowUpdateESportsStatus",
                    "IsShowGoldDeluxeSettingForCredit",
                    "IsShowMyanmarOdds",
                    "IsShowSportsbook2",
                    "IsShowColossusBets",
                    "EnableProduct-19",
                    "EnableProduct-20",
                    "EnableProduct-21",
                    "EnableProduct-22",
                    "EnableProduct-23",
                    "EnableProduct-24",
                    "RemoteRefURL_Msg",
                    "RemoteRefURL",
                    "RemoteCacheUrl",
                    "IsNeutralSite",
                    "LocalTest",
                    "PiwikSiteId",
                    "PiwikUrl",
                    "PiwikScript",
                    "ApplicationName",
                    "aspnet:MaxJsonDeserializerMembers",

                    "ResultSiteVirtualPath",
                    "TotalbetsForecastSiteVirtualPath",
                    "AssetAppPath",
                    "OldMainAppPath",
                    "HowToUseAppPath",
                    "MainAppPath",
                    "NG2SiteVirtualPath",
                    "ReportsAppPath",

                    "Disable151_41",
                    "Disable151_51",
                    "Disable152_41",
                    "Disable152_51",
                    "Disable153_51",

                    "EnableSecurityVerify",
                    "DeadlineEnableSecurity",
                    "DisabledCasino",
                    "LoggingServiceUrl",
                    "AccessDeniedPage",
                    "AssetsApp:StaticResourcesVersion",
                    "DisabledCheckDuplicationLogin"
                 };
            }
        }

        public static string[] ExpectedConnectionsStrings
        {
            get
            {
                return new string[]
                {
                    "CS_BackupDB",
                    "CS_ArchiveDB",
                    "LiveCasinoAdmin",
                    "CS_LBBackupDB",
                    "CS_LBArchiveDB",
                    "CS_Live",
                    "IPEntities",
                    "DBCust.IPDB.BODBDownlineNet",
                    "DBCust.CustDB.BODBDownlineNet",
                    "DBTXN.BODB02.BODBDownlineNet",
                    "DBTXN.CustDB.BODBDownlineNet",
                    "DBONUSER.ON_USER.BODBDownlineNet",
                    "DBPOLICY.bodb02.BODBDownlineNet",
                    "DBLOG.bodb_CustomerLog.BODBDownlineNet",
                    "DBAGE.bodb_AGE.BODBDownlineNet",
                    "DBAGE.bodb02.BODBDownlineNet",
                    "DB054.bodb02.BODBDownlineNet",
                    "DBARC.bodb_Archive.BODBDownlineNet",
                    "DBACC.bodb02.BODBDownlineNet",
                    "DBRPT.bodb_report.BODBDownlineNet",
                    "DBMSG.bodb_Message.BODBDownlineNet"
                };
            }
        }

        public int NumberOfAppSettings { get; set; }

        public int NumberOfConnectionsStrings { get; set; }

        public string BaseDirectory { get; set; }

        public string WebConfigRelativePath { get; set; }

        public string RelativeAppSettingsAndConnectionStringTestPath { get; set; }

        public Configuration AppSettingsAndConnectionStringConfiguration { get; set; }

        public virtual void TestFixtureSetUp()
        {
            NumberOfAppSettings = ExpectedAppSettings.Length;
            NumberOfConnectionsStrings = ExpectedConnectionsStrings.Length;

            BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!BaseDirectory.EndsWith("\\"))
            {
                BaseDirectory += "\\";
            }

            var configurationLoader = new ConfigurationLoader();

            var settingPath = BaseDirectory + RelativeAppSettingsAndConnectionStringTestPath;
            AppSettingsAndConnectionStringConfiguration = configurationLoader.LoadConfigurations(settingPath);
        }

        public virtual void ValidateAppSettings_LoadedAppSettings_ReturnCorrectItemLength()
        {
            // Assert
            Assert.AreEqual(NumberOfAppSettings, AppSettingsAndConnectionStringConfiguration.AppSettings.Settings.Count);
        }

        public virtual void ValidateAppSettings_SupportKeyName_ReturnData(string keyName)
        {
            // Action
            var setting = AppSettingsAndConnectionStringConfiguration.AppSettings.Settings[keyName];

            // Assert
            Assert.IsNotNull(setting);
        }

        public virtual void ValidateConnectionStrings_LoadedConnectionStrings_ReturnCorrectItemLength()
        {
            // Assert
            Assert.AreEqual(NumberOfConnectionsStrings, AppSettingsAndConnectionStringConfiguration.ConnectionStrings.ConnectionStrings.Count);
        }

        public virtual void ValidateConnectionStrings_SupportConnectionName_ReturnData(string connectionName)
        {
            // Action
            var connectionString = AppSettingsAndConnectionStringConfiguration.ConnectionStrings.ConnectionStrings[connectionName];

            // Assert
            Assert.IsNotNull(connectionString);
        }

        public virtual void ValidateWebConfig_LoadedWebConfig_LoadCorrectConfig()
        {
            // Arrange
            var configurationLoader = new ConfigurationLoader();
            var configuration = configurationLoader.LoadConfigurations(BaseDirectory + WebConfigRelativePath);

            // Action
            var sectionKeys = configuration.Sections.Keys;
            var keyList = new List<string>();
            foreach (var sectionKey in sectionKeys)
            {
                keyList.Add(sectionKey.ToString());
            }

            var containEnoughSections = keyList.Contains("Fanex.Logging") &&
                keyList.Contains("AlphaAuthSection") &&
                keyList.Contains("Fanex.Data.DbSettingProvider");

            // Assert
            Assert.IsTrue(containEnoughSections);
        }
    }
}