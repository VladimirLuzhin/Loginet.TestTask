using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Loginet.TestTask.Album.Dto;
using Loginet.TestTask.Core.Entities.Album.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.TestTask.Album.Controller
{
    /// <summary>
    /// Контроллер для получения альбомов
    /// </summary>
    [Route("api/albums")]
    [FormatFilter, Produces(MediaTypeNames.Application.Xml, MediaTypeNames.Application.Json)]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumsManager _albumManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="albumManager">Менеджер альбомов</param>
        /// <param name="mapper">Маппер объектов</param>
        public AlbumController(AlbumsManager albumManager, IMapper mapper)
        {
            _albumManager = albumManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка всех альбомов
        /// </summary>
        /// <returns></returns>
        [HttpGet("{format?}")]
        public async Task<IActionResult> GetAllAlbumsAsync()
        {
            var albums = await _albumManager.GetAllAlbumsAsync();
            
            return Ok(albums?.Select(a => _mapper.Map<AlbumDto>(a)).ToArray() ?? Array.Empty<AlbumDto>());
        }
        
        /// <summary>
        /// Получения альбома по идентификатору пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        [HttpGet("user/{userId}/{format?}")]
        public async Task<IActionResult> GetAlbumsByUserIdAsync(int userId)
        {
            var albums = (await _albumManager.GetAlbumsByUserId(userId))
                ?.Select(a => _mapper.Map<AlbumDto>(a)).ToArray() ?? Array.Empty<AlbumDto>();

            return Ok(albums);
        }
        
        /// <summary>
        /// Получение альбома по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор альбома</param>
        [HttpGet("{id}/{format?}")]
        public async Task<IActionResult> GetAlbumsByIdAsync(int id)
        {
            var album = await _albumManager.GetAlbumByIdAsync(id);
            if (album == null)
                return NotFound();
            
            return Ok(_mapper.Map<AlbumDto>(album));
        }
    }
}