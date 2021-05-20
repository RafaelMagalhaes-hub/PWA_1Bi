using System;
using System.Collections.Generic;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Localizacao;
using Buffet.Models.Buffet.ConvidadosDoEvento;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ClienteEntity clienteContratante { get; set; }
        public LocalEntity localDoEvento { get; set; }
        public string descricaoEvento { get; set; }
        public DateTime dataEvento { get; set; }
        public List<ConvidadoEntity> listaDeConvidados { get; set; }
        public SituacaoEvento Situacao { get; set; }

        public EventoEntity()
        {
            Id = new Guid();
            listaDeConvidados = new List<ConvidadoEntity>();
        }

        public EventoEntity(Guid id, string nome, ClienteEntity cliente, LocalEntity localDoEvento, string descricaoEven, DateTime dataEvento, List<ConvidadoEntity> listaDeConvidados, SituacaoEvento situacao)
        {
            Id = new Guid();
            this.listaDeConvidados = new List<ConvidadoEntity>();
            this.Nome = nome;
            this.clienteContratante = cliente;
            this.localDoEvento = localDoEvento;
            this.descricaoEvento = descricaoEven;
            this.dataEvento = dataEvento;
            this.listaDeConvidados = listaDeConvidados;
            this.Situacao = situacao;
        }
    }
}