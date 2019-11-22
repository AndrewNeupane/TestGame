using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ItSutra.TestGame.MultiTenancy.Dto;

namespace ItSutra.TestGame.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

