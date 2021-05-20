using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Localizacao
{
    public class LocalEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        public LocalEntity()
        {
            Id = new Guid();
        }

        public LocalEntity(string nome, string novaDescricao, Endereco novoEndereco)
        {
            Id = new Guid();
            this.Descricao = novaDescricao;
            this.Nome = nome;
            this.Endereco = novoEndereco;
        }

    }
}