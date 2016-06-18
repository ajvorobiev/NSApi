namespace NSApiForge.Test
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class NSApiTestFixture
    {
        [Test]
        public void VerifyStationsResponse()
        {
            var stations = NSApi.GetStations();
            Assert.IsNotEmpty(stations);

            Assert.AreEqual(622, stations.Count);
        }
    }
}
