#nullable disable

using ICI.SSL.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SSLExtension
    {
        public static IServiceCollection AddSSLServices(this IServiceCollection services, Action<ApiOptions> setupAction)
        {
            services.AddTransient<IOrderService,OrderService>();
            services.AddTransient<ICertificateService, CertificateService>();
            services.AddTransient<ICsrInfoService, CsrInfoService>();
            services.AddTransient<INotificationService, NotificationService>();

            services.Configure(setupAction);

            return services;
        }
    }
}
