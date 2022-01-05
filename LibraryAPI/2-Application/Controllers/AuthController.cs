using LibraryAPI._3_Domain.Entities;
using LibraryAPI._3_Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI._2_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthService authService, IAuthRepository authRepository)
        {
            _authService = authService;
            _authRepository = authRepository;
        }

        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] User userRequest)
        {
            var user = _authRepository.GetUser(userRequest.Email, userRequest.Password);
            
            if(user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos"});
            }

            var token = _authService.GenerateToken(user);

            return new
            {
                token = token
            };
        }
    }
}
