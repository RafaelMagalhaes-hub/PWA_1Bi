using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers.Admin
{
    [Authorize]
    public class AdminController : Controller
    {
        public AdminController()
        {
        }
        
        public IActionResult Supervisao()
        {
            return View();
        }

        public IActionResult Secao1()
        {
            return View("SecaoEscolhida/Secao1");
        }

        public IActionResult Secao2()
        {
            return View("SecaoEscolhida/Secao2");
        }

        public IActionResult Secao3()
        {
            return View("SecaoEscolhida/Secao3");
        }


        public IActionResult Secao4()
        {
            return View("SecaoEscolhida/Secao4");
        }

        public IActionResult filtroClientes()
        {
            return View();
        }

        public IActionResult filtroEventos()
        {
            return View();
        }

        public IActionResult filtroLocais()
        {
            return View();
        }
    }
}