using System;
using System.Collections.Generic;
using System.Diagnostics;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;
using Buffet.RequestModels.Evento;
using Buffet.ViewModels.Cliente;
using Buffet.ViewModels.Evento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buffet.Controllers.Evento
{
    [Authorize]
    public class EventoController : Controller
    {

        private readonly ClienteService _clienteService;
        private readonly EventoService _eventoService;

        public EventoController(
            EventoService eventoService
        )
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public IActionResult Remover(Guid param)
        {
            TempData["formMensagensErro"] = "Remoção mal sucedida.";
            return View("Views/Admin/SecaoEscolhida/Secao1.cshtml");
        }

        public IActionResult Index()
        {
            return View("Views/Admin/SecaoEscolhida/Secao2.cshtml");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            TempData["formMensagensErro"] = "Cadastro mal-sucedido.";
            return View("Views/Admin/SecaoEscolhida/Secao2.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult Cadastrar(CadastrarEventoRequestModels requestModel)
        {
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Cadastrar");
            }
            try
            {
                _eventoService.Adicionar(requestModel);
                TempData["formMensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> { exception.Message };
                return RedirectToAction("Cadastrar");
            }
        }

        [HttpPost]
        public RedirectToActionResult Remover(CadastrarEventoRequestModels requestModels)
        {
            try
            {
                _eventoService.Remover(requestModels.ID);
                TempData["formMensagemSucesso"] = "Remoção realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> { exception.Message };
                return RedirectToAction("Remover");
            }
        }

        [HttpGet]
        public IActionResult Editar(Guid param)
        {
            TempData["formMensagensErro"] = "Edição mal sucedida.";
            return View("Views/Admin/SecaoEscolhida/Secao2.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult Editar(CadastrarEventoRequestModels requestModel)
        {
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Editar");
            }
            try
            {
                _eventoService.Editar(requestModel);
                TempData["formMensagemSucesso"] = "Evento editado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> { exception.Message };
                return RedirectToAction("Editar");
            }
        }
    }

}