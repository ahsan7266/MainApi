using Services.Services.Account;
using Services.Services.Mail;
using Services.Services.Portfolio;
using Services.Services.Seed;
using Services.Services.StoredProcedures;

namespace MyApi.Helper
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection appservices)
        {
            appservices.AddTransient<IPortfolioServices, PortfolioServices>();
            appservices.AddTransient<IStoredProcedureService, StoredProcedureService>();
            appservices.AddTransient<IAccountService, AccountService>();
            appservices.AddTransient<ISeedService, SeedService>();
            appservices.AddTransient<IMailService, MailService>();
            appservices.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            return appservices;
        }
    }
}
