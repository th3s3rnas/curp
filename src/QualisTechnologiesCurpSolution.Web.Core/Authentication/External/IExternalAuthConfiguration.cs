using System.Collections.Generic;

namespace QualisTechnologiesCurpSolution.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
