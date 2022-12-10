using Microsoft.Extensions.DependencyInjection;

namespace QuickLogin.Configuration;

public interface IQuickLoginBuilder
{
    IServiceCollection Services { get; }
}