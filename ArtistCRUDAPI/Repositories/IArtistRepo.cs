using System;
using System.Collections.Generic;
using ArtistCRUDAPI.DTOs;
using ArtistCRUDAPI.Entities;

namespace ArtistCRUDAPI.Repositories
{
    public interface IArtistRepo
    {
        List<Artist> GetAllArtists();
        Artist GetArtistById(int artistId);
        Artist CreateArtist(CreateArtistDTO artistDTO);
        Artist UpdateArtist(Artist artist);
        void DeleteArtist(int id);

    }
}
