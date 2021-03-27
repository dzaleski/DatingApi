using AutoMapper;
using DatingApi.Dtos;
using DatingApi.Models;
using DatingApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/user
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<AppUser>> GetAllUsers()
        {
            return Ok(_repo.GetAllUsers());
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<AppUser> GetUserById(int id)
        {
            var user = _repo.GetUserById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }
    }
}
