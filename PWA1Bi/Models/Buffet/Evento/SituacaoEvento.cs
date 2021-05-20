using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.Evento
{
    public enum SituacaoOpcoesGerais
    {
        agendado,
        cancelado,
        executado,
        outros
    }
    public class SituacaoEvento
    {
        public Guid Id { get; set; }
        public SituacaoOpcoesGerais escolhaSituacaoGeral { get; set; }
        public string Descricao { get; set; }

        public SituacaoEvento()
        {
        }
        public SituacaoEvento(SituacaoOpcoesGerais escolhaSituacaoGeral, string descricao)
        {
            this.escolhaSituacaoGeral = escolhaSituacaoGeral;
            this.Descricao = descricao;
        }
    }
}