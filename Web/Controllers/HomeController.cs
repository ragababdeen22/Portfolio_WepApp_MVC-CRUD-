using core.interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<Portfolio> _portfolio;

        public HomeController(
            IUnitOfWork<Owner> owner,
            IUnitOfWork<Portfolio> portfolio)
        {
            _owner = owner;
            _portfolio = portfolio;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                portfolios = _portfolio.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

    }
}
