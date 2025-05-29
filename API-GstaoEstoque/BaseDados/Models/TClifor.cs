using System;
using System.Collections.Generic;

namespace API_GstaoEstoque.BaseDados.Models;

public partial class TClifor
{
    public int IdClifor { get; set; }

    /// <summary>
    /// Nome do cliente ou fornecedor
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Tipo: C = Cliente, F = Fornecedor
    /// </summary>
    public char Tipo { get; set; }

    /// <summary>
    /// Telefone de contato
    /// </summary>
    public string Telefone { get; set; }

    /// <summary>
    /// Email de contato
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// CPF ou CNPJ
    /// </summary>
    public string CpfCnpj { get; set; }

    /// <summary>
    /// Endereço vinculado (FK para t_endereco)
    /// </summary>
    public int? IdEndereco { get; set; }

    public virtual TEndereco IdEnderecoNavigation { get; set; }

    public virtual ICollection<TMovimentoest> TMovimentoests { get; set; } = new List<TMovimentoest>();

    public virtual ICollection<TProduto> TProdutos { get; set; } = new List<TProduto>();
}
