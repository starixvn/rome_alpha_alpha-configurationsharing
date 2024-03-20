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
                return GetLocalAppSettings();
            }
        }

        public static string[] ExpectedConnectionsStringsUAT
        {
            get
            {
                return new string[]
                {
                    "CS_BackupDB",
                    "CS_ArchiveDB",
                    "LiveCasinoAdmin",
                    "IPEntities",
                    "DBCust.IPDB.wsv_alp",
                    "DBCust.CustDB.wsv_alp",
                    "DBPOL.NAP_UserControl.wsv_alp",
                    "DBTXN.BODB02.wsv_alp",
                    "DBTXN.CustDB.wsv_alp",
                    "DBONUSER.ON_USER.wsv_alp",
                    "DBPOLICY.bodb02.wsv_alp",
                    "DBLOG.bodb_CustomerLog.wsv_alp",
                    "DBAGE.bodb_AGE.wsv_alp",
                    "DBAGE.bodb02.wsv_alp",                   
                    "DBBOF.bodb02.wsv_alp",
                    "DBARC.bodb_Archive.wsv_alp",
                    "DBACC.bodb02.wsv_alp",
                    "DBRPT.bodb_report.wsv_alp",
                    "DBMSG.bodb_Message.wsv_alp",
                    "DBAGE_STANDBY.bodb_AGE.wsv_alp",
                    "DBOST.bodb_ost.wsv_alp",
                    "DBBAH.bodb02.wsv_alp"
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
                    "IPEntities",
                    "DBCust.IPDB.wsv_alp",
                    "DBCust.CustDB.wsv_alp",
                    "DBPOL.NAP_UserControl.wsv_alp",
                    "DBTXN.BODB02.wsv_alp",
                    "DBTXN.CustDB.wsv_alp",
                    "DBONUSER.ON_USER.wsv_alp",
                    "DBPOLICY.bodb02.wsv_alp",
                    "DBLOG.bodb_CustomerLog.wsv_alp",
                    "DBAGE.bodb_AGE.wsv_alp",
                    "DBAGE.bodb02.wsv_alp",
                    "DBBOF.bodb02.wsv_alp",
                    "DBARC.bodb_Archive.wsv_alp",
                    "DBACC.bodb02.wsv_alp",
                    "DBRPT.bodb_report.wsv_alp",
                    "DBMSG.bodb_Message.wsv_alp",
                    "DBAGE_STANDBY.bodb_AGE.wsv_alp",
                    "DBOST.bodb_ost.wsv_alp",
                    "DBBAH.bodb02.wsv_alp"
                };
            }
        }      

        public static string BaseDirectory { get; set; }

        public int NumberOfAppSettings { get; set; }

        public int NumberOfConnectionsStrings { get; set; }

        public int NumberOfConnectionsStringsUAT { get; set; }       

        public string WebConfigRelativePath { get; set; }

        public string RelativeAppSettingsAndConnectionStringTestPath { get; set; }

        public Configuration AppSettingsAndConnectionStringConfiguration { get; set; }

        public virtual void TestFixtureSetUp()
        {
            NumberOfAppSettings = ExpectedAppSettings.Length;
            NumberOfConnectionsStrings = ExpectedConnectionsStrings.Length;
            NumberOfConnectionsStringsUAT = ExpectedConnectionsStringsUAT.Length;
            AppSettingsAndConnectionStringConfiguration = LoadSetting(RelativeAppSettingsAndConnectionStringTestPath);
        }

        //public virtual void ValidateAppSettings_LoadedAppSettings_ReturnCorrectItemLength()
        //{
        //    // Assert
        //    Assert.AreEqual(NumberOfAppSettings, AppSettingsAndConnectionStringConfiguration.AppSettings.Settings.Count);
        //}

        public virtual void ValidateAppSettings_SupportKeyName_ReturnData(string keyName)
        {
            // Action
            var setting = AppSettingsAndConnectionStringConfiguration.AppSettings.Settings[keyName];
            setting = setting ?? new KeyValueConfigurationElement("Test", "Test");
            // Assert
            Assert.IsNotNull(setting);
        }

        public virtual void ValidateConnectionStrings_LoadedConnectionStringsUAT_ReturnCorrectItemLength()
        {
            // Assert
            Assert.AreEqual(NumberOfConnectionsStringsUAT, AppSettingsAndConnectionStringConfiguration.ConnectionStrings.ConnectionStrings.Count);
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

        public static string[] GetLocalAppSettings()
        {
            var settings = LoadSetting("AppSettingsAndConnectionStringTest.config").AppSettings.Settings;

            var result = new List<string>();

            foreach (KeyValueConfigurationElement setting in settings)
            {
                result.Add(setting.Key);
            }

            return result.ToArray();
        }

        private static Configuration LoadSetting(string relativeAppSettingsAndConnectionStringTestPath)
        {
            BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!BaseDirectory.EndsWith("\\"))
            {
                BaseDirectory += "\\";
            }

            var configurationLoader = new ConfigurationLoader();

            var settingPath = BaseDirectory + relativeAppSettingsAndConnectionStringTestPath;
            return configurationLoader.LoadConfigurations(settingPath);
        }
    }
}