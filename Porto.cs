using porto_back.Enums;
using System.Diagnostics;

namespace porto_back
{
    public class Conteiner
    {
        public string NumConteiner { get; set; }
        public string Cliente { get; set; }
        public TipoConteinerEnum TipoConteiner { get; set; }
        public StatusEnum Status { get; set; }
        public CategoriaEnum Categoria { get; set; }

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
    }

    public class Movimentacao
    {
        public int Id { get; set; }
        public TipoMovimentacaoEnum TipoMovimentacao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        public string NumConteiner { get; set; }
        public required Conteiner Conteiner { get; set; }
    }
}
