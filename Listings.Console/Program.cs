namespace Listings.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var listingService = new ListingService();

            var listing1 = listingService.Create(new FreeListing
            {
                Name = "Restaurante Las Antillas"
            });

            var listing2 = listingService.Create(null);
        }
    }
}
