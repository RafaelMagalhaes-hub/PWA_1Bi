using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Localizacao
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public Endereco()
        {
        }

        public Endereco(string cidade, string uf, string cep, string bairro, string logradouro, string numero)
        {
            this.Cidade = cidade;
            this.Uf = uf;
            this.Cep = cep;
            this.Bairro = bairro;
            this.Logradouro = logradouro;
            this.Numero = numero;
        }
    }
}