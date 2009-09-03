namespace RSBuild.UnitTests.Entities
{
    using System;
    using System.IO;
    using System.Xml;
    using NUnit.Framework;
    using RSBuild.Entities;
    using RSBuild.UnitTests.Properties;

    [TestFixture]
    public class ReportTests2005 : ReportTests
    {
        protected override Stream CreateReportDefinition()
        {
            return Resources.CompanySales2005;
        }
    }

    [TestFixture]
    public class ReportTests2008 : ReportTests
    {
        protected override Stream CreateReportDefinition()
        {
            return Resources.CompanySales2008;
        }
    }

    public abstract class ReportTests
    {
        #region Tests

        [Test]
        public void ReportNameIsRequired()
        {
            const string NAME = "MyReport";
            const string TARGET_FOLDER = "/My/Report/Dir";

            Assert.That(CreateReport(NAME, TARGET_FOLDER).Name, Is.EqualTo(NAME), "Name");
            Assert.Catch<ArgumentException>(() => CreateReport(null, TARGET_FOLDER), "<null>");
            Assert.Catch<ArgumentException>(() => CreateReport(string.Empty, TARGET_FOLDER), "<empty>");
        }

        [Test]
        public void TargetFolderIsRequired()
        {
            const string NAME = "MyReport";
            const string TARGET_FOLDER = "/My/Report/Dir";

            Assert.That(CreateReport(NAME, TARGET_FOLDER).TargetFolder, Is.EqualTo(TARGET_FOLDER), "Name");
            Assert.Catch<ArgumentException>(() => CreateReport(NAME, null), "<null>");
            Assert.Catch<ArgumentException>(() => CreateReport(NAME, string.Empty), "<empty>");
        }

        [Test]
        public void ReportIsNotCacheableByDefault()
        {
            Assert.That(CreateReport().CacheOption, Is.Null);
        }

        [Test]
        public void MarkReportAsCacheable()
        {
            const int CACHE_EXPIRATION_IN_MINUTES = 10;

            Report report = CreateReport();
            report.CacheOption = new CacheOption(CACHE_EXPIRATION_IN_MINUTES);
            Assert.That(report.CacheOption, Is.Not.Null, "CacheOption");
            Assert.That(report.CacheOption.CacheReport, Is.True, "CacheOption.CacheReport");
            Assert.That(report.CacheOption.ExpirationMinutes, Is.EqualTo(CACHE_EXPIRATION_IN_MINUTES), "CacheOption.ExpirationMinutes");
        }

        [Test]
        public void OverrideReportBodyHeight()
        {
            const string COLLAPSED_HEIGHT = "0.5in";

            Report report = CreateReport();
            report.BodyHeight = COLLAPSED_HEIGHT;
            Assert.That(report.BodyHeight, Is.EqualTo(COLLAPSED_HEIGHT));
        }

        [Test]
        public void BodyHeightMustBeSpecifiedInInches()
        {
            const string COLLAPSED_HEIGHT = "0.5cm";
            Report report = CreateReport();
            Assert.Throws<ArgumentException>(() => report.BodyHeight = COLLAPSED_HEIGHT);
        }

        [Test]
        public void ReplaceSingleDataSourceInReportDefinition()
        {
            const string TARGET_FOLDER = @"/MyReports";

            Report report = CreateReport();
            ReportServerInfo reportServerInfo = new ReportServerInfo("RS1", "http", "localhost", null, null, null, null);
            DataSource dataSource = new DataSource("DS1", null, null, null, true, null, null, true, false, TARGET_FOLDER, reportServerInfo);
            
            report.SetDataSourceReference(dataSource);
        }

        #endregion

        #region Factory methods

        private Report CreateReport()
        {
            const string NAME = "MyReport";
            const string TARGET_FOLDER = "/My/Report/Dir";

            return CreateReport(NAME, TARGET_FOLDER);
        }

        private RSBuild.Entities.Report CreateReport(string name, string targetFolder)
        {
            using (XmlReader reportDefinition = XmlReader.Create(CreateReportDefinition()))
            {
                return new Report(name, targetFolder, reportDefinition);
            }
        }

        protected abstract Stream CreateReportDefinition();

        #endregion
    }
}
