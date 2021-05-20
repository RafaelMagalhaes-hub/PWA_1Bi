using System;
using System.Collections.Generic;
using System.Diagnostics;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Evento;
using Buffet.RequestModels.Cliente;
using Buffet.ViewModels.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buffet.Controllers.Cliente
{
    [Authorize]
    public class ClienteController : Controller
    {

        private readonly ClienteService _clienteService;
        private readonly EventoService _eventoService;

        public ClienteController(
            ClienteService clienteService
        )
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View("Views/Admin/SecaoEscolhida/Secao1.cshtml");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            TempData["formMensagensErro"] = "Preenchimento inconsistente dos campos. Cadastro mal sucedido.";
            return View("Views/Admin/SecaoEscolhida/Secao1.cshtml");
        }


        [HttpPost]
        public RedirectToActionResult Cadastrar(CadastrarClienteRequestModels requestModel)
        {
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Cadastrar");
            }

            try
            {
                _clienteService.Adicionar(requestModel);
                TempData["formMensagemSucesso"] = "Cliente adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["formMensagensErro"] = new List<string> { exception.Message };
                return RedirectToAction("Cadastrar");
            }
        }

        [HttpGet]
        public IActionResult Remover(Guid param)
        {
            TempData["formMensagensErro"] = "Remoção mal sucedida.";
            return View("Views/Admin/SecaoEscolhida/Secao1.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult Remover(CadastrarClienteRequestModels requestModels)
        {
            try
            {
                _clienteService.Remover(requestModels.ID);
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
            return View("Views/Admin/SecaoEscolhida/Secao1.cshtml");
        }

        [HttpPost]
        public RedirectToActionResult Editar(CadastrarClienteRequestModels requestModel)
        { 
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0)
            {
                TempData["formMensagensErro"] = listaDeErros;
                return RedirectToAction("Editar");
            }
            try
            {
                _clienteService.Editar(requestModel);
                TempData["formMensagemSucesso"] = "Cliente editado com sucesso!";
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