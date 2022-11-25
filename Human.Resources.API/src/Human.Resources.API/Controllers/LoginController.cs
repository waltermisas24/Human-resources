using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.Mapper;
using Human.Resources.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Human.Resources.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(string nombreUsuario, string Contrasena)
        {
            try
            {

                var response = await _loginServices.LoginAsync(WorkerMapper.UserDTOToEntity(nombreUsuario, Contrasena));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(500, ex.Message);
            }
        }
        private IActionResult ErrorResponse(int codeError, string message)
        {
            ErrorMessageEntity errorMessage = new ErrorMessageEntity();
            errorMessage.CodeError = codeError;
            errorMessage.Message = message;

            return new BadRequestObjectResult(errorMessage);
        }
    }
}
