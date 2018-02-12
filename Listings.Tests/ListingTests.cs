using Listings.Console;
using Moq;
using NUnit.Framework;
using System;

namespace Listings.Tests
{
    [TestFixture]
    public class ListingTests
    {
        private Mock<IListingService> _listingServiceMock;

        [SetUp]
        public void Init()
        {
            _listingServiceMock = new Mock<IListingService>();

            _listingServiceMock.Setup(l => l.Create(null))
                .Throws(new ArgumentNullException("listing"));

            _listingServiceMock.Setup(l => l.Create(It.Is<Listing>(i => i != null 
                && string.IsNullOrEmpty(i.Name))))
                .Returns((Listing l) => l);
        }

        [Test]
        public void Create_Should_Throws_ArgumentNullException_When_It_Is_Null()
        {
            Listing listing = null;

            Assert.Catch<ArgumentNullException>(() => _listingServiceMock.Object.Create(listing));
        }

        [Test]
        public void Create_Should_Create_Listing_When_Name_Is_Not_Null()
        {
            var listing = Mock.Of<Listing>();

            listing.Name = "TEST";

            Assert.IsNotNull(listing.Name);
            Assert.IsNotEmpty(listing.Name);

            var listingCreated = _listingServiceMock.Object.Create(listing);

            Assert.IsNull(listingCreated);
        }
    }
}
