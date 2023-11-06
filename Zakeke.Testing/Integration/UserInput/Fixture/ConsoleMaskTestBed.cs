using Calculator.UserInput;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Zakeke.Testing.Integration.UserInput.Fixture
{
    public class ConsoleMaskTestBed : TestBedFixture, IAsyncLifetime
    {
        public Task InitializeAsync()
        {
            //Everything needed to initialize a test, in our case nothing particular
            return Task.CompletedTask;
        }

        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            services.AddScoped<ConsoleMask>();
        }
        protected override ValueTask DisposeAsyncCore() => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "appsettings.Test.json", IsOptional = false };
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            //Everything needed to dispose a test goes here

            return Task.CompletedTask;
        }
    }
}