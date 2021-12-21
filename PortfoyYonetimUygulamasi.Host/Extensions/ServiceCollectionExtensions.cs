using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Data.Concrete;
using PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Contexts;
using PortfoyYonetimUygulamasi.Host.Abstract;
using PortfoyYonetimUygulamasi.Host.Concrete;

namespace PortfoyYonetimUygulamasi.Host.Extensions
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PortfoyYonetimUygulamasiContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IPortfolioService, PortfolioManager>();
            serviceCollection.AddScoped<IWalletService, WalletManager>();
            serviceCollection.AddScoped<ICoinService, CoinManager>();
            return serviceCollection;
        }
    }
}
