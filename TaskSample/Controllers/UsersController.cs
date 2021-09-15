using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSample.Data;
using TaskSample.Dtos;
using TaskSample.Models;
using TaskSample.Services;
using Microsoft.AspNetCore.SignalR;
using TaskSample.Hubs;

namespace TaskSample.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public UsersController(IUserService userService, IUserRepo repository, IMapper mapper, IHubContext<NotificationHub> notificationHubContext)
        {
            _userService = userService;
            _repository = repository;
            _mapper = mapper;
            _notificationHubContext = notificationHubContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        {

            var users = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreatePlatform(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            if (userCreateDto.GroupName.ToLower() == "Avenger".ToLower())
            {
                await _notificationHubContext.Clients.All.SendAsync("sendNotification", userCreateDto.FullName);
            }
            
            return Ok(userReadDto);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("avengers")]
        public async Task<ActionResult<UserReadDto>> GetAvengerGroupUser()
        {
            var users = _repository.GetUserByGroup("Avenger");

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));


        }
        

       

    }
}