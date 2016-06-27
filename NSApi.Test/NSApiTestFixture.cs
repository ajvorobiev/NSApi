namespace NSApiForge.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

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

            Assert.Throws<ArgumentNullException>(() => NSApi.GetStationsByName(string.Empty));
        }

        [Test]
        public void VerifyGetDepartureTimesWorks()
        {
            var times = NSApi.GetDepartureTimes("Delft");
            Assert.IsNotEmpty(times);

            Assert.Throws<ArgumentNullException>(() => NSApi.GetDepartureTimes(string.Empty));
        }

        [Test]
        public void VerifyGetDisruptionsWorks()
        {
            var times = NSApi.GetDisruptions("amsterdam");
            Assert.IsNotNull(times);
            Assert.IsNotNull(times.Planned);
            Assert.IsNotNull(times.Unplanned);

            Assert.Throws<ArgumentNullException>(() => NSApi.GetDisruptions(string.Empty));
        }

        [Test]
        public void VerifyGetDepartureTimesByDestinationWorks()
        {
            var times = NSApi.GetDepartureTimesByDestination("Delft", new List<string> {"Dordrecht", "Vlissingen"});
            Assert.IsNotEmpty(times);

            Assert.Throws<ArgumentNullException>(() => NSApi.GetDepartureTimesByDestination(string.Empty, null));
        }

        [Test]
        public void VerifyGetFullStationInfoWorks()
        {
            var stations = NSApi.GetFullStationInformationByName(
                "Delft",
                new List<string> { "Dordrecht", "Vlissingen" });

            Assert.IsNotEmpty(stations);

            var firstStation = stations.First();

            Assert.IsNotNull(firstStation.Departures);
            Assert.IsNotNull(firstStation.Disruptions);

            Assert.Throws<ArgumentNullException>(() => NSApi.GetFullStationInformationByName(string.Empty));

            var stations2 = NSApi.GetFullStationInformationByName(
                "Delft", null);

            Assert.IsNotEmpty(stations2);

            var firstStation2 = stations.First();

            Assert.IsNotNull(firstStation2.Departures);
            Assert.IsNotNull(firstStation2.Disruptions);

        }
    }
}
