using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.ViewModels.Evento
{
    public class CadastrarEvento
    { 

        public string[] FormMensagensErro { get; set; }

        public ICollection<SelectListItem> Convidados { get; set; }

        public CadastrarEvento()
        {
            Convidados = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "")
            };
        }
    }
}
