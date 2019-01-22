using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeyCloakSSODotnetCore.Helpers.KeyCloakDomain
{
    public static class Extensions
    {
        public static void BindKeyCloakOAuthAPIOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new KeyCloakOAuthAPIConfig();
            var section = configuration.GetSection("KeyCloak");
            section.Bind(options);

            services.AddSingleton<KeyCloakOAuthAPIConfig>(_ => options);
        }

        public static void BindKeyCloakOAuthClientOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new KeyCloakOAuthClientConfig();
            var section = configuration.GetSection("KeyCloakClient");
            section.Bind(options);

            services.AddSingleton<KeyCloakOAuthClientConfig>(_ => options);
        }
    }
}
