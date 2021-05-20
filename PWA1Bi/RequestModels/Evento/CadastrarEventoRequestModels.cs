using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Buffet.RequestModels.Evento
{
    public class CadastrarEventoRequestModels
    {
        public string Nome { get; set; }
        public Guid clienteContratante { get; set; }
        public Guid localDoEvento { get; set; }
        public string descricaoEvento { get; set; }
        public string dataEvento { get; set; }
        public string ID { get; set; }


        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();
            return listaDeErros;
        }

    }
}