using System;

namespace Listings.Console
{
    public class ListingService : IListingService
    {
        public Listing Create(Listing listing)
        {
            Listing listingCreated = null;

            if (listing == null) throw new ArgumentNullException("listing");

            if (!string.IsNullOrEmpty(listing.Name))
            {
                if (listing.GetType() == typeof(FreeListing))
                {
                    listingCreated = new FreeListing
                    {
                        Name = listing.Name
                    };
                }
            }

            return listingCreated;
        }
    }
}
