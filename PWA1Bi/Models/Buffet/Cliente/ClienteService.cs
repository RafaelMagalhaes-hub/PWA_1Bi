using System;
using System.Collections.Generic;
using System.Linq;
using Buffet.Data;
using Buffet.RequestModels.Cliente;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteService
    {
        private readonly DatabaseContext _databaseContext;

        public ClienteService(
            DatabaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }

        public ClienteEntity Adicionar(CadastrarClienteRequestModels dadosBasicos)
        {
            var novoCliente = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Clientes.Add(novoCliente);
            _databaseContext.SaveChanges();
            return novoCliente;
        }
        private ClienteEntity ValidarDadosBasicos(
            CadastrarClienteRequestModels dadosBasicos,
            ClienteEntity entidadeExistente = null
        )
        {
            var entidade = entidadeExistente ?? new ClienteEntity();
            if (dadosBasicos.Nome == null)
            {
                throw new Exception("A Descrição é obrigatória");
            }
            entidade.Nome = dadosBasicos.Nome;
            if (dadosBasicos.Email == null)
            {
                throw new Exception("A Descrição é obrigatória");
            }
            entidade.Email = dadosBasicos.Email;
            return entidade;
        }

        public ClienteEntity ObterPorId(string param)
        {
            ClienteEntity clienteEspecifico1 = _databaseContext.Clientes.Find(new Guid(param));
            return clienteEspecifico1; 
        }

        public ClienteEntity Remover(string email)
        {
            var clienteEntity = ObterPorId(email);
            _databaseContext.Clientes.Remove(clienteEntity);
            _databaseContext.SaveChanges();
            return clienteEntity;
        }

        public ClienteEntity Editar(
            CadastrarClienteRequestModels dadosBasicos)
        {
            var clienteEntity = ObterPorId(dadosBasicos.ID);
            clienteEntity = ValidarDadosBasicos(dadosBasicos,clienteEntity);
            _databaseContext.SaveChanges();
            return clienteEntity;
        }
    }
}