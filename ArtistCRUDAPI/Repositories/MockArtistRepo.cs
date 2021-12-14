using System;
using System.Collections.Generic;
using System.Linq;
using ArtistCRUDAPI.DTOs;
using ArtistCRUDAPI.Entities;

namespace ArtistCRUDAPI.Repositories
{
    public class MockArtistRepo : IArtistRepo
    {
        private List<Artist> _artists;
        public MockArtistRepo()
        {
            _artists = PopulateMockData();
        }

        private List<Artist> PopulateMockData()
        {
            return new List<Artist>
            {
                new Artist { ArtistId = 1, ArtistName = "ABBA", CreatedDate=DateTime.Now },
                new Artist { ArtistId = 2, ArtistName = "Sherlock Holmes", CreatedDate=DateTime.Now },
                new Artist { ArtistId = 3, ArtistName = "Edwin Arthur", CreatedDate=DateTime.Now },
                new Artist { ArtistId = 4, ArtistName = "Redwin Mind", CreatedDate=DateTime.Now },
            };
        }

        public Artist CreateArtist(CreateArtistDTO createArtistDTO)
        {
            Artist artist = new Artist();
            artist.CreatedDate = DateTime.Now;
            artist.ArtistId = _artists.Max(x => x.ArtistId) + 1;
            _artists.Add(artist);
            return artist;

        }

        public void DeleteArtist(int artistId)
        {
            _artists.Remove(GetArtistById(artistId));
        }

        public List<Artist> GetAllArtists()
        {
            return _artists;
        }

        public Artist GetArtistById(int artistId)
        {
            Artist artist = _artists.Find(artist => artist.ArtistId == artistId);
            return artist;
        }

        public Artist UpdateArtist(Artist artist)
        {
            Artist existingArtist = _artists.FirstOrDefault(x => x.ArtistId == artist.ArtistId);
            if(existingArtist is not null)
            {
                existingArtist.ArtistId = artist.ArtistId;
                existingArtist.ArtistName = artist.ArtistName;
            }
            return existingArtist;
        }
    }
}
