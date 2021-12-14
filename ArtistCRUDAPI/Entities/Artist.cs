using System;
namespace ArtistCRUDAPI.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
