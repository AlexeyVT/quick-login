using Microsoft.Extensions.DependencyInjection;

namespace QuickLogin.Configuration;

public class QuickLoginBuilder : IQuickLoginBuilder
{
    public QuickLoginBuilder(IServiceCollection services)
    {
        Services = services ?? throw new ArgumentNullException(nameof(services));
    }

    public IServiceCollection Services { get; }
}