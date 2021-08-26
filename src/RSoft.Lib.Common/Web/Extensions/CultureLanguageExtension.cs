using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace RSoft.Lib.Common.Web.Extensions
{

    /// <summary>
    /// Provides extension methods to Culture Language
    /// </summary>
    public static class CultureLanguageExtension
    {

        /// <summary>
        /// Add culture-language services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Service configuration</param>
        /// <param name="sectionSettingName">Section name to bind CultureOptions</param>
        public static IServiceCollection AddCultureLanguage(this IServiceCollection services, IConfiguration configuration, string sectionSettingName = "Application:Culture")
        {

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    CultureOptions cultureOptions = new CultureOptions();
                    configuration.GetSection(sectionSettingName).Bind(cultureOptions);

                    IList<CultureInfo> supportedCultures = cultureOptions.SupportedLanguage.Select(c => new CultureInfo(c)).ToList();

                    options.DefaultRequestCulture = new RequestCulture(culture: cultureOptions.DefaultLanguage, uiCulture: cultureOptions.DefaultLanguage);
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new[] { new HeaderRequestCultureProvider(cultureOptions.DefaultLanguage, cultureOptions.SupportedLanguage) };
                });

            return services;

        }

        /// <summary>
        /// Configure language service
        /// </summary>
        /// <param name="app">IApplicationBuilder object instance</param>
        public static IApplicationBuilder ConfigureLangague(this IApplicationBuilder app)
        {

            ServiceActivator.Configure(app.ApplicationServices);
            IOptions<RequestLocalizationOptions> localizeOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizeOptions.Value);

            return app;
        }

    }

}
