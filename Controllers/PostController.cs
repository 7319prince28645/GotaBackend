using ApiGotadevida.DbContexts;
using ApiGotadevida.DTOS.Post;
using ApiGotadevida.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace ApiGotadevida.Controllers
{
    [ApiController]
    [Route("post")]

    public class PostController : Controller
    {
        public readonly GotaAGotaContext context;
        public readonly IMapper mapper;

        public PostController(GotaAGotaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("getPosts")]
        public async Task<ActionResult<IEnumerable<ListPosts>>> getPosts()
        {

        var posts = await context.PostUsers.ToListAsync();

        // Mapear los posts a DTOs para enviarlos como respuesta
        var postDTOs = mapper.Map<List<ListPosts>>(posts);

        // Devolver los posts mapeados como respuesta
        return Ok(postDTOs);
        }
        [HttpGet("getPosts/{id}")]
        public async Task<ActionResult<IEnumerable<ListPosts>>> getPosts(int id)
        {
            // Verificar si el usuario existe
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Obtener los posts asociados al usuario
            var posts = await context.PostUsers
                .Where(p => p.UserId == id)
                .ToListAsync();

            // Mapear los posts a DTOs para enviarlos como respuesta
            var postDTOs = mapper.Map<List<ListPosts>>(posts);

            // Devolver los posts mapeados como respuesta
            return Ok(postDTOs);
        }

        [HttpPost("createPost/{id}")]
        public async Task<ActionResult> CreatePost(int id, PostMsjDTO postMsjDTO)
        {
            // Buscar el usuario por su ID
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(); // Devolver un error si el usuario no se encuentra
            }

            // Mapear el DTO del post a una entidad PostUser
            var postUser = mapper.Map<PostUser>(postMsjDTO);

            postUser.UserId = id;

            context.Add(postUser);
            await context.SaveChangesAsync();

            // Devolver una respuesta indicando que se ha creado el post
            return StatusCode(201);
        }


    }
}
