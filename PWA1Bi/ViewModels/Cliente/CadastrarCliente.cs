using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Cliente
{
    public class CadastrarCliente
    {
        public string[] FormMensagensErro { get; set; }
        public ICollection<SelectListItem> Eventos { get; set; }

        public CadastrarCliente()
        {
            Eventos = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "")
            };
        }

    }
}
