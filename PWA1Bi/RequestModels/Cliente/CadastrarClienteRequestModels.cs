using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Buffet.RequestModels.Cliente
{
    public class CadastrarClienteRequestModels
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ID { get; set; }

        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();

            return listaDeErros;
        }

    }
}