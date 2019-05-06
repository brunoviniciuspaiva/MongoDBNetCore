
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Service.Services;
using Service.Validators;
using System;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController: Controller
    {
        private readonly IService<Users> _service;

        public UserController(IConfiguration configuration)
        {
            _service = new BaseService<Users>(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [Route("api/user", Name = "GetId")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Users item)
        {
            try
            { 
                _service.Post<UserValidator>(item);

                return Created("GetId", item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Users item)
        {
            try
            {
                item.Id = ObjectId.Parse(id);
                _service.Put<UserValidator>(item);

                return Created("GetId", item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                //Users user = new Users() { Id = ObjectId.Parse(id) };
                return Ok(_service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}