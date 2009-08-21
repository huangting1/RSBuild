namespace RSBuild.UnitTests
{
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class SettingsTests
    {
        [Test]
        public void LoadSettingsFromFile()
        {
            string settingsFilePath = Path.GetTempFileName();
            using (var writer = File.CreateText(settingsFilePath))
            {
                writer.Write("<Settings />");
            }
            
            Settings settings = Settings.Load(settingsFilePath);
            Assert.That(settings, Is.Not.Null);
        }
    }
}
