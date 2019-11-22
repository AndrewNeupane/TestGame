using System.Collections.Generic;

namespace ItSutra.TestGame.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
