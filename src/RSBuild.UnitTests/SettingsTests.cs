namespace RSBuild.UnitTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using NUnit.Framework;
    using RSBuild.Entities;
    using RSBuild.UnitTests.Properties;

    [TestFixture]
    public class SettingsTests
    {
        #region Instance fields

        private readonly List<string> _tempFilePaths = new List<string>(); 

        #endregion

        #region Test Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _tempFilePaths.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            foreach (string tempFilePath in _tempFilePaths)
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }

        #endregion

        #region Tests

        [Test]
        public void LoadSettingsFromFile()
        {
            string settingsFilePath = CreateSettingsFile(CreateSettingsDocument());
            Settings settings = Settings.Load(settingsFilePath);
            Assert.That(settings, Is.Not.Null);
        }

        [Test]
        public void LoadFailsIfNoReportServerSettings()
        {
            const int RS_COUNT = 0;
            const string RS_NAME_PREFIX = "RS";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleReportServers(RS_NAME_PREFIX, RS_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);

            Assert.Catch<XmlException>(() => Settings.Load(settingsFilePath));
        }

        [Test]
        public void LoadMultipleReportServerSettings()
        {
            const int RS_COUNT = 3;
            const string RS_NAME_PREFIX = "RS";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleReportServers(RS_NAME_PREFIX, RS_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);
            Settings settings = Settings.Load(settingsFilePath);

            Assert.That(settings.ReportServers, Has.Count.EqualTo(RS_COUNT));
            for (int i = 0; i < RS_COUNT; i++)
            {
                Assert.That(settings.ReportServers.ContainsKey(RS_NAME_PREFIX + i));
            }
        }

        private XDocument CreateSettingsDocumentWithMultipleReportServers(
            string reportServerNamePrefix, int reportServerCount)
        {
            const string DS_NAME = "DS1";
            const string RG_NAME = "RG1";
            const string RPT_NAME = "RPT1";

            string reportServerName = reportServerNamePrefix + "0";
            return CreateSettingsDocument(
                CreateReportServers(reportServerNamePrefix, reportServerCount),
                CreateDataSource(DS_NAME, reportServerName),
                CreateReportGroup(RG_NAME, reportServerName, DS_NAME,
                    CreateReport(RPT_NAME)));
        }


        [Test]
        public void LoadFailsIfNoDataSourceSettings()
        {
            const int DS_COUNT = 0;
            const string DS_NAME_PREFIX = "DS";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleDataSources(DS_NAME_PREFIX, DS_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);

            Assert.Catch<XmlException>(() => Settings.Load(settingsFilePath));
        }

        [Test]
        public void LoadMultipleDataSourceSettings()
        {
            const int DS_COUNT = 3;
            const string DS_NAME_PREFIX = "DS";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleDataSources(DS_NAME_PREFIX, DS_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);
            Settings settings = Settings.Load(settingsFilePath);

            Assert.That(settings.DataSources, Has.Count.EqualTo(DS_COUNT));
            for (int i = 0; i < DS_COUNT; i++)
            {
                Assert.That(settings.DataSources.ContainsKey(DS_NAME_PREFIX + i));
            }
        }

        private XDocument CreateSettingsDocumentWithMultipleDataSources(
            string dataSourceNamePrefix, int dataSourceCount)
        {
            const string RS_NAME = "RS1";
            const string RG_NAME = "RG1";
            const string RPT_NAME = "RPT1";

            string dataSourceName = dataSourceNamePrefix + "0";
            return CreateSettingsDocument(
                CreateReportServer(RS_NAME),
                CreateDataSources(dataSourceNamePrefix, dataSourceCount, RS_NAME),
                CreateReportGroup(RG_NAME, RS_NAME, dataSourceName,
                    CreateReport(RPT_NAME)));
        }

        [Test]
        public void LoadFailsIfNoReportGroupSettings()
        {
            const int RG_COUNT = 0;
            const string RG_NAME_PREFIX = "DS";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleReportGroups(RG_NAME_PREFIX, RG_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);

            Assert.Catch<XmlException>(() => Settings.Load(settingsFilePath));
        }

        [Test]
        public void LoadMultipleReportGroups()
        {
            const int RG_COUNT = 3;
            const string RG_NAME_PREFIX = "RG";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleReportGroups(RG_NAME_PREFIX, RG_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);
            Settings settings = Settings.Load(settingsFilePath);

            Assert.That(settings.ReportGroups, Has.Count.EqualTo(RG_COUNT));
            for (int i = 0; i < RG_COUNT; i++)
            {
                string reportGroupName = RG_NAME_PREFIX + i;
                Assert.That(settings.ReportGroups.Count(g => g.Name == reportGroupName), Is.EqualTo(1));
            }
        }

        private XDocument CreateSettingsDocumentWithMultipleReportGroups(
            string reportGroupNamePrefix, int reportGroupCount)
        {
            const string RS_NAME = "RS1";
            const string DS_NAME = "DS1";

            return CreateSettingsDocument(
                CreateReportServer(RS_NAME),
                CreateDataSource(DS_NAME, RS_NAME),
                CreateReportGroups(reportGroupNamePrefix, reportGroupCount, RS_NAME, DS_NAME));
        }

        [Test]
        public void LoadFailsIfNoReportSettings()
        {
            const int RPT_COUNT = 0;
            const string RPT_NAME_PREFIX = "RPT";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleReports(RPT_NAME_PREFIX, RPT_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);

            Assert.Catch<XmlException>(() => Settings.Load(settingsFilePath));
        }

        [Test]
        public void LoadMultipleReports()
        {
            const int RPT_COUNT = 3;
            const string RPT_NAME_PREFIX = "RPT";

            XDocument settingsDocument = CreateSettingsDocumentWithMultipleReports(RPT_NAME_PREFIX, RPT_COUNT);
            string settingsFilePath = CreateSettingsFile(settingsDocument);

            Settings settings = Settings.Load(settingsFilePath);
            ReportGroup reportGroup = settings.ReportGroups[0];
            Assert.That(reportGroup.Reports, Has.Count.EqualTo(RPT_COUNT));
            for (int i = 0; i < RPT_COUNT; i++)
            {
                string reportName = RPT_NAME_PREFIX + i;
                Assert.That(reportGroup.Reports.Count(g => g.Name == reportName), Is.EqualTo(1));
            }
        }

        private XDocument CreateSettingsDocumentWithMultipleReports(
            string reportNamePrefix, int reportCount)
        {
            const string RS_NAME = "RS1";
            const string DS_NAME = "DS1";
            const string RG_NAME = "RG1";

            return CreateSettingsDocument(
                CreateReportServer(RS_NAME),
                CreateDataSource(DS_NAME, RS_NAME),
                CreateReportGroup(RG_NAME, RS_NAME, DS_NAME, 
                    CreateReports(reportNamePrefix, reportCount)));
        }

        #endregion

        #region Factory methods

        private static XElement CreateReportServer(string name)
        {
            return new XElement("ReportServer",
                new XAttribute("Name", name),
                new XAttribute("Host", "localhost")
                );
        }

        private static IEnumerable<XElement> CreateReportServers(string namePrefix, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return CreateReportServer(namePrefix + i);
            }
        }

        private static XElement CreateDataSource(string name, string reportServerName)
        {
            const string DS_TARGET_FOLDER = "MyDataSourceTargetFolder";
            const string DS_CONNECTION_STRING = "Data Source=localhost;Initial Catalog=DB1";

            return new XElement("DataSource",
                new XAttribute("Name", name),
                new XAttribute("ReportServer", reportServerName),
                new XAttribute("TargetFolder", DS_TARGET_FOLDER),
                new XElement("ConnectionString", DS_CONNECTION_STRING),
                new XElement("CredentialRetrieval", "None")
                );
        }

        private static IEnumerable<XElement> CreateDataSources(string namePrefix, int count, string reportServerName)
        {
            for (int i = 0; i < count; i++)
            {
                yield return CreateDataSource(namePrefix + i, reportServerName);
            }
        }

        private static XElement CreateReportGroup(string name, string reportServerName, string dataSourceName, object reports)
        {
            const string RG_TARGET_FOLDER = "MyReportTargetFolder";

            return new XElement("ReportGroup",
                new XAttribute("Name", name),
                new XAttribute("ReportServer", reportServerName),
                new XAttribute("TargetFolder", RG_TARGET_FOLDER),
                new XAttribute("DataSourceName", dataSourceName),
                reports
                );
        }

        private IEnumerable<XElement> CreateReportGroups(string namePrefix, int count, string reportServerName, string dataSourceName)
        {
            const string RPT_NAME_PREFIX = "RPT";

            for (int i = 0; i < count; i++)
            {
                string reportGroupName = namePrefix + i;
                string reportName = RPT_NAME_PREFIX + i;
                yield return CreateReportGroup(reportGroupName, reportServerName, dataSourceName,
                    CreateReport(reportName));
            }
        }

        private XElement CreateReport(string name)
        {
            using (var reportContent = Resources.CompanySales2005)
            {
                return CreateReport(name, reportContent);
            }
        }

        private XElement CreateReport(string name, Stream content)
        {
            return new XElement("Report",
                new XAttribute("Name", name),
                new XElement("FilePath", CreateReportFile(name, content))
                );
        }

        private IEnumerable<XElement> CreateReports(string reportNamePrefix, int reportCount)
        {
            for (int i = 0; i < reportCount; i++)
            {
                string reportName = reportNamePrefix + i;
                yield return CreateReport(reportName);
            }
        }

        private string CreateReportFile(string reportName, Stream reportContent)
        {
            string reportFilePath = Path.Combine(
                Path.GetTempPath(), 
                Path.ChangeExtension(reportName, ".rpt"));
            
            using (var reportFile = File.Create(reportFilePath))
            {
                var chunk = new byte[4096];
                var chunkSize = reportContent.Read(chunk, 0, chunk.Length);
                while (chunkSize > 0)
                {
                    reportFile.Write(chunk, 0, chunkSize);
                    chunkSize = reportContent.Read(chunk, 0, chunk.Length);
                }
                reportFile.Flush();
            }

            _tempFilePaths.Add(reportFilePath);
            return reportFilePath;
        }

        private XDocument CreateSettingsDocument()
        {
            const string RS_NAME = "ReportServer1";
            const string DS_NAME = "DataSource1";
            const string RG_NAME = "ReportGroup1";
            const string RPT_NAME = "Report1";

            return CreateSettingsDocument(
                CreateReportServer(RS_NAME), 
                CreateDataSource(DS_NAME, RS_NAME),
                CreateReportGroup(RG_NAME, RS_NAME, DS_NAME, 
                    CreateReport(RPT_NAME))
                );
        }

        private static XDocument CreateSettingsDocument(object reportServers, object dataSources, object reportGroups)
        {
            return new XDocument(
                new XElement("Settings",
                    new XElement("ReportServers", reportServers),
                    new XElement("DataSources", dataSources),
                    new XElement("Reports", reportGroups)
                    )
                );
        }

        private string CreateSettingsFile(XDocument settingsDocument)
        {
            string settingsFilePath = Path.GetTempFileName();
            using (var writer = File.CreateText(settingsFilePath))
            {
                settingsDocument.Save(writer);
            }

            _tempFilePaths.Add(settingsFilePath);
            return settingsFilePath;
        }

        #endregion
    }
}
