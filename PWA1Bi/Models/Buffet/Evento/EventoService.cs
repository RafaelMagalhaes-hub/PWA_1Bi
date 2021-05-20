using System;
using System.Collections.Generic;
using System.Linq;
using Buffet.Data;
using Buffet.RequestModels.Evento;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoService
    {
        private readonly DatabaseContext _databaseContext;

        public EventoService(
            DatabaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }

        public ICollection<EventoEntity> ObterTodos()
        {
            return _databaseContext.Eventos.ToList();
        }

        public EventoEntity Adicionar(CadastrarEventoRequestModels dadosBasicos)
        {
            var novoEvento = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Eventos.Add(novoEvento);
            _databaseContext.SaveChanges();
            return novoEvento;
        }

        private EventoEntity ValidarDadosBasicos(
            CadastrarEventoRequestModels dadosBasicos,
            EventoEntity entidadeExistente = null
        )
        {
            var entidade = entidadeExistente ?? new EventoEntity();
            if (dadosBasicos.Nome == null)
            {
                throw new Exception("A indicação de um nome para o evento é obrigatória.");
            }
            entidade.Nome = dadosBasicos.Nome;
            if (dadosBasicos.clienteContratante == null)
            {
                throw new Exception("A indicação do cliente é obrigatória.");
            }
            entidade.clienteContratante = _databaseContext.Clientes.Find(dadosBasicos.clienteContratante);
            if (dadosBasicos.localDoEvento == null)
            {
                throw new Exception("A indicação do local é obrigatória.");
            }
            entidade.localDoEvento = _databaseContext.Locais.Find(dadosBasicos.localDoEvento);
            if (dadosBasicos.descricaoEvento == null)
            {
                throw new Exception("A Descrição do evento é obrigatória.");
            }
            entidade.descricaoEvento = dadosBasicos.descricaoEvento;
            if (dadosBasicos.dataEvento == null)
            {
                throw new Exception("A colocação da data é obrigatória.");
            }
            entidade.dataEvento = DateTime.Parse(dadosBasicos.dataEvento);
            return entidade;
        }

        public EventoEntity ObterPorId(string param)
        {
            EventoEntity eventoEspecifico1 = _databaseContext.Eventos.Find(new Guid(param));
            return eventoEspecifico1;
        }

        public EventoEntity Remover(string ID)
        {
            var eventoEntity = ObterPorId(ID);
            _databaseContext.Eventos.Remove(eventoEntity);
            _databaseContext.SaveChanges();
            return eventoEntity;
        }

        public EventoEntity Editar(
        CadastrarEventoRequestModels dadosBasicos)
        {
            var eventoEntity = ObterPorId(dadosBasicos.ID);
            eventoEntity = ValidarDadosBasicos(dadosBasicos, eventoEntity);
            _databaseContext.SaveChanges();
            return eventoEntity;
        }
    }

}