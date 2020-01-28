﻿using AutoFixture;
using Dispatching.Cabs;
using Dispatching.Framework;
using Dispatching.TestFixtures.DomainObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dispatching.Tests.UnitTests.Cabs.CabTests
{
    [TestClass]
    public class InequalityTest
    {
        private readonly Fixture _fixture = new Fixture();

        private Id<Cab> _id;
        private Location _location;

        [TestInitialize]
        public void Initialize()
        {
            _fixture.Customize(new LocationCustomization());


            _id = _fixture.Create<Id<Cab>>();
            _location = _fixture.Create<Location>();
        }

        [TestMethod]
        public void WhenSame_ComparisonShouldBeFalse()
        {
            // Arrange
            var cab = new Cab(_id, _location);
            var sameCab = new Cab(_id, _location);

            // Act
            var actual = cab != sameCab;

            // Assert
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void WhenNotSame_ComparisonShouldBeTrue()
        {
            // Arrange
            var cab = _fixture.Create<Cab>();
            var otherCab = _fixture.Create<Cab>();

            // Act
            var actual = cab != otherCab;

            // Assert
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void WhenReferenceToSameObject_ComparisonShouldBeTrue()
        {
            // Arrange
            var cab = _fixture.Create<Cab>();

            // Act
            var actual = cab != cab;

            // Assert
            actual.Should().BeFalse();
        }
    }
}