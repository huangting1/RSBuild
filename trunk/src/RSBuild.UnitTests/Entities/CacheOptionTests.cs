namespace RSBuild.UnitTests.Entities
{
    using System;
    using NUnit.Framework;
    using RSBuild.Entities;

    [TestFixture]
    public class CacheOptionTests
    {
        [Test]
        public void CanDisableCaching()
        {
            var cacheOption = new CacheOption();
            Assert.That(cacheOption.CacheReport, Is.False, "CacheReport");
            Assert.That(cacheOption.ExpirationMinutes, Is.Null, "ExpirationMinutes");
        }

        [Test]
        public void CanSpecifyCacheDurationInMinutes()
        {
            const int CACHE_MINUTES = 20;

            var cacheOption = new CacheOption(CACHE_MINUTES);
            Assert.That(cacheOption.CacheReport, Is.True, "CacheReport");
            Assert.That(cacheOption.ExpirationMinutes, Is.EqualTo(CACHE_MINUTES), "ExpirationMinutes");
        }

        [Test]
        public void CacheDurationMustBeGreaterThanOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new CacheOption(-1));
        }
    }
}
