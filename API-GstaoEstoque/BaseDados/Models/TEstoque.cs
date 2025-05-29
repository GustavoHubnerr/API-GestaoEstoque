using System;
using System.Collections.Generic;

namespace API_GstaoEstoque.BaseDados.Models;

public partial class TEstoque
{
    public int IdEstoque { get; set; }

    /// <summary>
    /// Produto relacionado (FK para t_produtos)
    /// </summary>
    public int IdProduto { get; set; }

    /// <summary>
    /// Quantidade atual em estoque
    /// </summary>
    public decimal Quantidade { get; set; }

    public virtual TProduto IdProdutoNavigation { get; set; }
}
