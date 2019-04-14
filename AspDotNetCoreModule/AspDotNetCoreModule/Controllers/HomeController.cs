using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCoreStart.Controllers
{
    public class HomeController : Controller
    {
        private IServiceProvider _serviceProvider;

        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public IActionResult Index()
        {
            IM001 m001 = _serviceProvider.GetService<IM001>();
            var fromM001 = m001.Get(new ToM001 { Nbr1 = 100 });

            var m002 = _serviceProvider.GetService<IM002>();
            var fromM002 = m002.Get(new ToM002 { Nbr1 = 100 });

            var m010 = _serviceProvider.GetService<IM010>();
            var fromM010 = m010.Get(new ToM010 { Nbr1 = 100 });

            var m011 = _serviceProvider.GetService<IM011>();
            var fromM011 = m011.Get(new ToM011 { Nbr1 = 100 });

            return View();
        }
   }
}
