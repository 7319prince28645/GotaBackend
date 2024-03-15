﻿using ApiGotadevida.DbContexts;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> getUser()
        {
            var usuario= await context.Users.Select(u=> mapper.Map<UserDTO>(u)).ToListAsync();
            return Ok(usuario);
        }
        [HttpPost]
        [Route("api/CrearUser")]
        public async Task<ActionResult> crearUser(UserDTO userDTO)
        {
             var createUser = mapper.Map<Users>(userDTO);
            context.Add(createUser);
            await context.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}