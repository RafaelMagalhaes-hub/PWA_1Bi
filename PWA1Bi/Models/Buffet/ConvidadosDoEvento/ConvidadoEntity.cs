using Buffet.Models.Buffet.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.ConvidadosDoEvento
{
    public class ConvidadoEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime nascimentoConvidado { get; set; }
        public string Observacoes { get; set; }
        public DateTime Insercao { get; set; }
        public DateTime Modificacao { get; set; }
        public SituacaoConvidado situacaoConvidado { get; set; }

        public ConvidadoEntity()
        {
            Id = new Guid();
        }

        public ConvidadoEntity(string nome, string email, string cpf, DateTime nascimentoConvidado, string observacoes, DateTime insercao, DateTime modificacao, SituacaoConvidado situacaoConvidado)
        {
            Id = new Guid();
            this.Nome = nome;
            this.Email = email;
            this.Cpf = cpf;
            this.nascimentoConvidado = nascimentoConvidado;
            this.Observacoes = observacoes;
            this.Insercao = insercao;
            this.Modificacao = modificacao;
            this.situacaoConvidado = situacaoConvidado;
        }

    }
}