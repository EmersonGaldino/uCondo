using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using uCondo.Galdino.Application.Interface.Account;
using UCondo.Galdino.Base;
using UCondo.Galdino.Controllers.Base;
using uCondo.Galdino.Domain.Entity.Account;
using UCondo.Galdino.Models.ModelView.Account;
using UCondo.Galdino.Models.ModelView.Token;
using UCondo.Galdino.Models.ViewModel.Account;

namespace UCondo.Galdino.Controllers.Account;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ApiBaseController
{
    private IMapper Mapper => GetService<IMapper>();
    private IAccountAppService appService => GetService<IAccountAppService>();

    [HttpGet]
    [SwaggerOperation(Summary = "Get Account",
        Description = "Buscar todas as contas criadas no sistema.")]
    [SwaggerResponse(200, "Lista.", typeof(SuccessResponse<BaseModelView<List<AccountModelView>>>))]
    [SwaggerResponse(400, "Não foi possível bsucar as contas do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Get() => await AutoResult(async () => new BaseModelView<List<AccountModelView>>
    {
        Data = Mapper.Map<List<AccountModelView>>(await appService.Get()),
        Message = "list account",
        Success = true
    });

    [HttpPost]
    [SwaggerOperation(Summary = "Create Account",
        Description = "Cria uma conta no sistema.")]
    [SwaggerResponse(200, "Conta criada.", typeof(SuccessResponse<BaseModelView<List<AccountModelView>>>))]
    [SwaggerResponse(400, "Não foi possível bsucar as contas do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Post([FromBody] AccountViewModel model) =>
        await AutoResult(async () => new BaseModelView<AccountModelView>
        {
            Data = Mapper.Map<AccountModelView>(await appService.Post(Mapper.Map<AccountEntity>(model))),
            Message = "Account create success.",
            Success = true
        });

    [HttpPut]
    [SwaggerOperation(Summary = "Update Account",
        Description = "Cria uma conta no sistema.")]
    [SwaggerResponse(200, "Conta criada.", typeof(SuccessResponse<BaseModelView<List<AccountModelView>>>))]
    [SwaggerResponse(400, "Não foi possível bsucar as contas do sistema.", typeof(BadResponse))]
    [SwaggerResponse(500, "Erro no rastreamento da pilha.", typeof(BadResponse))]
    public async Task<IActionResult> Put([FromBody] AccountViewModel model)
    {
        await appService.Put(Mapper.Map<AccountEntity>(model));
        return await AutoResult(async () => new BaseModelView<AccountModelView>
        {
            Message = "Account update success.",
            Success = true
        });
    }
}