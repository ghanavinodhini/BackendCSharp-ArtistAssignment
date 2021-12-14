using System;
using System.Collections.Generic;
using System.Linq;
using ArtistCRUDAPI.DTOs;
using ArtistCRUDAPI.Entities;
using ArtistCRUDAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArtistCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepo _artistRepo;

        public ArtistsController(IArtistRepo artistRepo)
        {
            _artistRepo = artistRepo;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllArtists()
        {
            IOrderedEnumerable<ArtistDTO> artists = _artistRepo
                .GetAllArtists()
                .Select(a =>new ArtistDTO
                {
                ArtistId = a.ArtistId,
                ArtistName = a.ArtistName
            }).OrderBy(x=>x.ArtistName);
            return Ok(artists);
        }

        [HttpGet]
        [Route("{artistId}")]
        public IActionResult GetArtistById(int artistId)
        {
            Artist artist = _artistRepo.GetArtistById(artistId);
            //Console.Write("Artist returned id,artist:" + artistId,artist);

            if(artist is null)
            {
                return NotFound($"Artist with id {artistId} is not Found");
            }

            ArtistDTO artistDTO = MapArtistToArtistDTO(artist);
            return Ok(artistDTO);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateArtist([FromBody] CreateArtistDTO createArtistDTO)
        {
            Artist newArtist = _artistRepo.CreateArtist(createArtistDTO);
            newArtist.ArtistName = createArtistDTO.ArtistName;

            ArtistDTO artistDTO = MapArtistToArtistDTO(newArtist);
            return CreatedAtAction(nameof(GetArtistById), new { ArtistId = artistDTO.ArtistId }, artistDTO);
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateArtist([FromBody] Artist artist)
        {
            Artist updatedArtist = _artistRepo.UpdateArtist(artist);
            ArtistDTO updatedArtistDTO = MapArtistToArtistDTO(updatedArtist);
            return Ok(updatedArtistDTO);
        }

        [HttpDelete]
        [Route("{artistId}")]
        public IActionResult DeleteArtist(int artistId)
        {
            _artistRepo.DeleteArtist(artistId);
            return NoContent();
        }

        private ArtistDTO MapArtistToArtistDTO(Artist artist)
        {
            return new ArtistDTO
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.ArtistName
            };
        }
    }
}
