using System;
using System.Collections;
using System.Collections.Generic;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }

        public ClienteEntity()
        {
            Id = new Guid();
            Eventos = new List<EventoEntity>();
        }

        public ClienteEntity(Guid id, string nome, string email, ICollection<EventoEntity> eventos)
        {
            Id = new Guid();
            Eventos = new List<EventoEntity>();
            Nome = nome;
            Email = email;
            Eventos = eventos;
        }

    }
}