using System;
using System.Collections.Generic;
using System.Diagnostics;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Localizacao;
using Buffet.RequestModels.Local;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers.Local
{
    [Authorize]
    public class LocalController : Controller
    {

        private readonly LocalService _localService;
        private readonly EventoService _eventoService;

        public LocalController(
            LocalService localService
        )
        {
            _localService = localService;
        }

        public IActionResult Index()
        {
            return View("Views/Admin/SecaoEscolhida/Secao3.cshtml");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            TempData["formMensagensErro"] = "Preenchimento inadequado de campos.";
            return View("Views/Admin/SecaoEscolhida/Secao3.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult Cadastrar(CadastrarLocalRequestModels requestModel)
        {
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Cadastrar");
            }
            try
            {
                _localService.Adicionar(requestModel);
                TempData["formMensagemSucesso"] = "Local adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> { exception.Message };
                return RedirectToAction("Cadastrar");
            }
        }

        public IActionResult Remover(Guid param)
        {
            TempData["formMensagensErro"] = "Remoção mal sucedida.";
            return View("Views/Admin/SecaoEscolhida/Secao3.cshtml");
        }

        [HttpGet]
        public IActionResult Editar()
        {
            TempData["formMensagensErro"] = "Cadastro mal-sucedido.";
            return View("Views/Admin/SecaoEscolhida/Secao2.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult Remover(CadastrarLocalRequestModels requestModels)
        {
            try
            {
                _localService.Remover(requestModels.ID);
                TempData["formMensagemSucesso"] = "Remoção realizada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> { exception.Message };
                return RedirectToAction("Remover");
            }
        }

        [HttpPost]
        public RedirectToActionResult Editar(CadastrarLocalRequestModels requestModel)
        {
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Editar");
            }
            try
            {
                _localService.Editar(requestModel);
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