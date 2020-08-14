using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Loginet.TestTask.Core.Entities.User.Manager;
using Loginet.TestTask.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.TestTask.User.Controller
{
    /// <summary>
    /// Контроллер для получения пользователей
    /// </summary>
    [Route("api/users")]
    [FormatFilter, Produces(MediaTypeNames.Application.Xml, MediaTypeNames.Application.Json)]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="userManager">Менеджер пользователей</param>
        /// <param name="mapper">Маппер объектов</param>
        public UserController(UserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        [HttpGet("{format?}")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userManager.GetAllUsersAsync();
            
            return Ok(users?.Select(u => _mapper.Map<UserDto>(u)).ToArray() ?? Enumerable.Empty<UserDto>());
        }
        
        /// <summary>
        /// Получение пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        [HttpGet("{userId}/{format?}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound();
            
            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}