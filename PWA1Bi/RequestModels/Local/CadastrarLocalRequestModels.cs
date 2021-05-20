using Buffet.Models.Buffet.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Buffet.RequestModels.Local
{
    public class CadastrarLocalRequestModels
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Cidade{ get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Bairro{ get; set; }
        public string Numero{ get; set; }
        public string ID { get; set; }

        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();

            return listaDeErros;
        }

    }
}