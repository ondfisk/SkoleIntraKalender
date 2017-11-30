using System;
using Xunit;
using SkoleIntraKalender.Models;

namespace SkoleIntraKalender.Tests.Models
{
    public class ExtensionsTests
    {
        [Fact]
        public void ToDateTime()
        {
            var millisecondsSinceEpoch = 1511248200000;

            var output = millisecondsSinceEpoch.ToDateTime();

            Assert.Equal(DateTime.Parse("2017-11-21T08:10:00.0000000"), output);
        }

        [Fact]
        public void ToMillisecondsSinceEpoch()
        {
            var dateTime = DateTime.Parse("2017-11-21T08:10:00.0000000");

            var output = dateTime.ToMillisecondsSinceEpoch();

            Assert.Equal(1511248200000, output);
        }

        [Fact]
        public void ToSecondsSinceEpoch()
        {
            var dateTime = DateTime.Parse("2017-11-21T08:10:00.0000000");

            var output = dateTime.ToSecondsSinceEpoch();

            Assert.Equal(1511248200, output);
        }

        [Fact]
        public void ToDateTime_given_seconds()
        {
            var sSinceEpoch = 1511248200;

            var output = sSinceEpoch.ToDateTime();

            Assert.Equal(DateTime.Parse("2017-11-21T08:10:00.0000000"), output);
        }
    }
}
