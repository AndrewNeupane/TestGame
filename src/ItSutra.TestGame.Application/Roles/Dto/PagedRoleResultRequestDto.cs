using Abp.Application.Services.Dto;

namespace ItSutra.TestGame.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

