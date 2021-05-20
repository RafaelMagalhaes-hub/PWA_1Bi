using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet.Models.Buffet.ConvidadosDoEvento
{
    public enum SituacaoConvidadoOpcoesGerais
    {
        confirmado,
        cancelado,
        emDuvida,
        outros
    }
    public class SituacaoConvidado
    {
        public SituacaoConvidadoOpcoesGerais opcaoGeral { get; set; }

        public string Descricao { get; set; }

        public Guid Id { get; set; }

        public SituacaoConvidado()
        {
        }

        public SituacaoConvidado(SituacaoConvidadoOpcoesGerais opcaoGeral, string descricao)
        {
            this.opcaoGeral = opcaoGeral;
            this.Descricao = descricao;
        }

    }
}