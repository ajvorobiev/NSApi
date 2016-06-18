namespace NSApiForge.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class SettingsManagerTestFixture
    {
        [Test]
        public void VerifyThatSettingsLoad()
        {
            Assert.DoesNotThrow(() => { var settings = SettingsManager.Instance.Settings; });

            Assert.AreEqual("http://webservices.ns.nl", SettingsManager.Instance.Settings.ApiBaseUrl);
            Assert.AreEqual("ns-api-stations-v2", SettingsManager.Instance.Settings.ApiStationsService);
            Assert.IsFalse(string.IsNullOrEmpty(SettingsManager.Instance.Settings.ApiUsername));
            Assert.IsFalse(string.IsNullOrEmpty(SettingsManager.Instance.Settings.ApiPassword));
        }
    }
}
