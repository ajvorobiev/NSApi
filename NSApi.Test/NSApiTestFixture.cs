namespace NSApiForge.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using NUnit.Framework;

    [TestFixture]
    public class NSApiTestFixture
    {
        private Stopwatch watch;

        [SetUp]
        public void SetUp()
        {
            this.watch = new Stopwatch();
            this.watch.Start();
        }

        [TearDown]
        public void TearDown()
        {
            this.watch.Stop();
            Console.WriteLine("Query elapsed in " + this.watch.ElapsedMilliseconds + "ms");
        }

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
            Assert.IsNotEmpty(times);
        }

        [Test]
        public void VerifyGetDisruptionsWorks()
        {
            var times = NSApi.GetDisruptions("amsterdam");
            Assert.IsNotNull(times);
            Assert.IsNotNull(times.Planned);
            Assert.IsNotNull(times.Unplanned);
        }

        [Test]
        public void VerifyGetDepartureTimesByDestinationWorks()
        {
            var times = NSApi.GetDepartureTimesByDestination("Delft", new List<string> {"Dordrecht", "Vlissingen"});
            Assert.IsNotEmpty(times);
        }
    }
}
