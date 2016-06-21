﻿namespace NSApiForge.Test
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class NSApiTestFixture
    {
        [Test]
        public void VerifyGetStationsWorks()
        {
            var stations = NSApi.GetStations();
            Assert.IsNotEmpty(stations);

            Assert.AreEqual(622, stations.Count);
        }

        [Test]
        public void VerifyGetStationsByNameWorks()
        {
            var stations = NSApi.GetStationsByName("Delft");
            Assert.IsNotEmpty(stations);

            Assert.AreEqual(3, stations.Count);
        }

        [Test]
        public void VerifyGetDepartureTimesWorks()
        {
            var times = NSApi.GetDepartureTimes("Delft");
            Assert.IsNotNull(times);
        }
    }
}
