using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using showMeMicroservice.api.Models.ViewModel;
using Swashbuckle.AspNetCore.Annotations;
using uCondo.Galdino.Application.Interface.User;
using UCondo.Galdino.Base;
using uCondo.Galdino.BootStraper.Configurations.Security;
using UCondo.Galdino.Controllers.Base;
using uCondo.Galdino.Domain.Entity.User;
using UCondo.Galdino.Models.ModelView.Token;

namespace UCondo.Galdino.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ApiBaseController
{
    private IUserAppService AppService => GetService<IUserAppService>();
    private IMapper Mapper => GetService<IMapper>();
    private TokenConfig TokenConfig => GetService<TokenConfig>();

    [HttpPost]
    [SwaggerOperation(Summary = "Gerar token",
        Description = "Gerar um token para aplicacao que enviou os parametros corretos.")]
    [SwaggerResponse(200, "Token gerado comsucesso.", typeof(SuccessResponse<BaseModelView<TokenModelView>>))]
    [SwaggerResponse(400, "Não foi possível gerar o token do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] UserViewModel model)
    {
        var user = await AppService.GetUser(new UserEntity
        {
            Email = model.Email,
            Password = model.Password
        });

        if (CheckCredentials(user, out var error)) return error;

        var data = GenerateToken(user);
        var response = await AutoResult(async () =>
            new BaseModelView<TokenModelView>
            {
                Data = new TokenModelView
                {
                    Authenticate = true,
                    Created = DateTime.Now,
                    Expires = DateTime.Now.AddMinutes(TokenConfig.ExpireIn),
                    Token = data
                },
                Message = "Token gerado com sucesso"
            });
        return response;
    }

    private bool CheckCredentials(UserEntity user, out IActionResult error)
    {
        if (user is null)
        {
            error = Error("Usuario não localizado");
            return true;
        }
        error = null;
        return false;
    }


    private string GenerateToken(UserEntity user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(TokenConfig.SigningKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new GenericIdentity(user.Email, "login"),
                new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("Email", user.Email)
                }),
            Expires = DateTime.UtcNow.AddDays(TokenConfig.ExpireIn),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = TokenConfig.Audience,
            Issuer = TokenConfig.Audience,
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}