using DatingApi.Models;
using DatingApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetAllUsers()
        {
            return Ok(_repo.GetAllUsers());
        }
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUserById(int id)
        {
            var user = _repo.GetUserById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }
    }
}
