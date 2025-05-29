using System;
using System.Collections.Generic;

namespace API_GstaoEstoque.BaseDados.Models;

public partial class TProduto
{
    public int IdProduto { get; set; }

    /// <summary>
    /// Nome do produto
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Unidade de medida (ex: UN, KG, L)
    /// </summary>
    public string UndMedida { get; set; }

    /// <summary>
    /// Preço de custo
    /// </summary>
    public decimal? PrecoCusto { get; set; }

    /// <summary>
    /// Preço de venda
    /// </summary>
    public decimal? PrecoVenda { get; set; }

    /// <summary>
    /// Situação: A = Ativo, I = Inativo
    /// </summary>
    public char SituacaoProduto { get; set; }

    /// <summary>
    /// Fornecedor principal (FK para t_clifor)
    /// </summary>
    public int? Fornecedor { get; set; }

    public virtual TClifor FornecedorNavigation { get; set; }

    public virtual ICollection<TEstoque> TEstoques { get; set; } = new List<TEstoque>();

    public virtual ICollection<TMovimentoest> TMovimentoests { get; set; } = new List<TMovimentoest>();
}
