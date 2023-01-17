using AutoMapper;
using uCondo.Galdino.Domain.Entity.Account;
using UCondo.Galdino.Models.ModelView.Account;
using UCondo.Galdino.Models.ViewModel.Account;

namespace UCondo.Galdino.AutoMapper;

public class MappingProfilesModelView : Profile
{
    public MappingProfilesModelView()
    {
        CreateMap<AccountEntity, AccountModelView>().ReverseMap();
        CreateMap<AccountEntity, AccountViewModel>().ReverseMap();
    }
}