using System;
using System.Collections.Generic;
using System.Linq;
using Buffet.Data;
using Buffet.RequestModels.Local;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Models.Buffet.Localizacao
{
    public class LocalService
    {
        private readonly DatabaseContext _databaseContext;

        public LocalService(
            DatabaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }

        public LocalEntity Adicionar(CadastrarLocalRequestModels dadosBasicos)
        {
            var novoEvento = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Locais.Add(novoEvento);
            _databaseContext.SaveChanges();
            return novoEvento;
        }

        private LocalEntity ValidarDadosBasicos(
            CadastrarLocalRequestModels dadosBasicos,
            LocalEntity entidadeExistente = null
        )
        {
            var entidade = entidadeExistente ?? new LocalEntity();
            if (dadosBasicos.Nome == null)
            {
                throw new Exception("A indicação de um nome para o local é obrigatória.");
            }
            entidade.Nome = dadosBasicos.Nome;
            if (dadosBasicos.Descricao == null)
            {
                throw new Exception("A indicação de uma descricao do local é obrigatória.");
            }
            entidade.Descricao = dadosBasicos.Descricao;
            if (dadosBasicos.Logradouro == null)
            {
                throw new Exception("A indicação do logradouro é obrigatória.");
            }
            entidade.Endereco = new Endereco();
            entidade.Endereco.Logradouro = dadosBasicos.Logradouro;
            if (dadosBasicos.Bairro == null)
            {
                throw new Exception("A indicação do bairro em que fica o Local é obrigatória.");
            }
            entidade.Endereco.Bairro = dadosBasicos.Bairro;
            if (dadosBasicos.Cidade == null)
            {
                throw new Exception("A indicação da Cidade em que fica o Local é obrigatória.");
            }
            entidade.Endereco.Cidade = dadosBasicos.Cidade;
            if (dadosBasicos.CEP == null)
            {
                throw new Exception("A indicação do CEP é obrigatória.");
            }
            entidade.Endereco.Cep = dadosBasicos.CEP;
            if (dadosBasicos.UF == null)
            {
                throw new Exception("A indicação da UF de endereço do local é obrigatória.");
            }
            entidade.Endereco.Uf = dadosBasicos.UF;
            if (dadosBasicos.Numero == null)
            {
                throw new Exception("A indicação do número do local é obrigatória.");
            }
            entidade.Endereco.Numero = dadosBasicos.Numero;
            return entidade;

        }
        public LocalEntity ObterPorId(string param)
        {
            LocalEntity localEspecifico1 = _databaseContext.Locais.Find(new Guid(param));
            return localEspecifico1;
        }

        public LocalEntity Remover(string ID)
        {
            var localEntity = ObterPorId(ID);
            _databaseContext.Locais.Remove(localEntity);
            _databaseContext.SaveChanges();
            return localEntity;
        }

        public LocalEntity Editar(
        CadastrarLocalRequestModels dadosBasicos)
        {
            var localEntity = ObterPorId(dadosBasicos.ID);
            localEntity = ValidarDadosBasicos(dadosBasicos, localEntity);
            _databaseContext.SaveChanges();
            return localEntity;
        }
    }
}
