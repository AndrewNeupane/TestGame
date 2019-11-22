using Abp.AutoMapper;
using ItSutra.TestGame.Authentication.External;

namespace ItSutra.TestGame.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
