using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Endereco
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }

        public Endereco()
        {
        }

        public Endereco(string novaCidade, string novaUf, string novoCep, string novoBairro, string novoLogradouro, int novoNumero)
        {
            cidade = novaCidade;
            uf = novaUf;
            cep = novoCep;
            bairro = novoBairro;
            logradouro = novoLogradouro;
            numero = novoNumero;
        }
    }
}