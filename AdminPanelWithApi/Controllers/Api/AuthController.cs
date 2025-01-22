using AdminPanelWithApi.PathUrl;
using Application.Handlers.Commands.Auth.ChangePassword.Dto;
using Application.Handlers.Commands.Auth.ForgetPassword.Dto;
using Application.Handlers.Commands.Auth.Login.Dto;
using Application.Handlers.Commands.Auth.RefreshToken.Dto;
using Application.Handlers.Commands.Auth.Register.Dto;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdminPanelWithApi.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "AuthAPI")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.Register)]
        [ProducesResponseType(typeof(RegisterResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {

            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.Register.Commend { Model = model }));

        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.Login)]
        [ProducesResponseType(typeof(LoginResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> Login([FromForm] LoginDto model)
        {

            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.Login.Commend { Model = model }));

        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.ForgetPassword)]
        [ProducesResponseType(typeof(AuthModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> ForgetPassword([FromForm] ForgetPasswordDto model)
        {
            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.ForgetPassword.Commend { Model = model }));

        }
        [HttpPost(ApiRoutes.Identity.ChangePassword)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        [ProducesResponseType(typeof(AuthModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordDto model)
        {
            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.ChangePassword.Commend { Model = model }));

        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.SendCode)]
        [ProducesResponseType(typeof(AuthModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> SendCode(string email)
        {
            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.SendCode.Commend { Email = email }));

        }
         
        [HttpPost(ApiRoutes.Identity.RefreshToken)]
        [ProducesResponseType(typeof(RefreshTokenResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.RefreshToken.Commend { Token = refreshToken }));

        }
        
        [HttpPost(ApiRoutes.Identity.RevokeToken)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> RevokeToken(string refreshToken)
        {
            return Ok(await _mediator.Send(new Application.Handlers.Commands.Auth.RevokeToken.Commend { Token = refreshToken }));

        }
    }
}
