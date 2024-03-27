using ApiGotadevida.DbContexts;
using ApiGotadevida.DTOS;
using ApiGotadevida.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGotadevida.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly GotaAGotaContext context;
        private readonly IMapper mapper;

        public UserController(GotaAGotaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> getUser(LoginDTO loginDTO)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            if (user == null)
            {
                return Unauthorized(); 
            }

            var userMapper = mapper.Map<UserDTO>(user);
            return Ok(userMapper);
        }
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<IEnumerable<UserListProfileDTO>>> getUserProfile(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID debe ser mayor que cero.");
            }
            var userProfileFound = await context.Profiles.Where(u => u.Id == id).Select(u => mapper.Map<UserListProfileDTO>(u)).FirstOrDefaultAsync();

            if (userProfileFound == null)
            {
                return NotFound();
            }
            return Ok(userProfileFound);
        }
        [HttpPost]
        [Route("api/CrearUser")]
        public async Task<ActionResult> CrearUser(UserCreateDTO userCreateDTO)
        {
            var createUser = mapper.Map<Users>(userCreateDTO);
            context.Add(createUser);
            await context.SaveChangesAsync();

            var profile = new UserProfile
            {
                Id = createUser.Id
            };
            context.Add(profile);
            await context.SaveChangesAsync();

            return StatusCode(201);
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserListProfileDTO userListProfileDTO)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var userprofile = await context.Profiles.FirstOrDefaultAsync(u => u.Id == id);

            if (userprofile == null)
            {
                return NotFound();
            }

            mapper.Map(userListProfileDTO, userprofile);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el perfil de usuario: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

            return Ok(userprofile);
        }
    }
}
