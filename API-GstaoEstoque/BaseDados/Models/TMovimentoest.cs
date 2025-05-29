using System;
using System.Collections.Generic;

namespace API_GstaoEstoque.BaseDados.Models;

public partial class TMovimentoest
{
    public int IdMovimento { get; set; }

    /// <summary>
    /// Produto movimentado (FK para t_produtos)
    /// </summary>
    public int IdProduto { get; set; }

    /// <summary>
    /// E = Entrada, S = Saída
    /// </summary>
    public char TipoMovimento { get; set; }

    /// <summary>
    /// Quantidade movimentada
    /// </summary>
    public decimal Quantidade { get; set; }

    /// <summary>
    /// Data da movimentação
    /// </summary>
    public DateTime DataMovimento { get; set; }

    /// <summary>
    /// Cliente ou fornecedor relacionado (FK para t_clifor)
    /// </summary>
    public int? IdClifor { get; set; }

    /// <summary>
    /// Observações sobre o movimento
    /// </summary>
    public string Observacao { get; set; }

    public virtual TClifor IdCliforNavigation { get; set; }

    public virtual TProduto IdProdutoNavigation { get; set; }
}
