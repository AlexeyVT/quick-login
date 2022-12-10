using Microsoft.Extensions.Options;
using QuickLogin.Configuration;
using QuickLogin.LoginFlow;
using QuickLogin.SetupFlow;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddQuickLoginExtensions
{
    public static IQuickLoginBuilder AddQuickLogin(this IServiceCollection services, Action<QuickLoginOptions> setupAction)
    {
        services.Configure(setupAction);
        var builder = new QuickLoginBuilder(services);
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<QuickLoginOptions>>().Value);
        return builder;
    }

    public static IQuickLoginBuilder AddInMemoryLoginService(this IQuickLoginBuilder builder)
    {
        builder.Services.AddSingleton<ILoginFlowService, LoginFlowInMemoryService>();
        return builder;
    }

    public static IQuickLoginBuilder AddInMemorySetupService(this IQuickLoginBuilder builder)
    {
        builder.Services.AddSingleton<ISetupFlowService, SetupFlowInMemoryService>();
        return builder;
    }

    public static IQuickLoginBuilder AddLoginService<TLoginFlowService>(this IQuickLoginBuilder builder) where TLoginFlowService : class, ILoginFlowService
    {
        builder.Services.AddSingleton<ILoginFlowService, TLoginFlowService>();
        return builder;
    }

    public static IQuickLoginBuilder AddSetupService<TSetupFlowService>(this IQuickLoginBuilder builder) where TSetupFlowService : class, ISetupFlowService
    {
        builder.Services.AddSingleton<ISetupFlowService, TSetupFlowService>();
        return builder;
    }
}