using System;
using System.Collections.Generic;

namespace API_GstaoEstoque.BaseDados.Models;

public partial class TEndereco
{
    public int IdEndereco { get; set; }

    /// <summary>
    /// Código de Endereçamento Postal
    /// </summary>
    public string Cep { get; set; }

    /// <summary>
    /// Nome do bairro
    /// </summary>
    public string Bairro { get; set; }

    /// <summary>
    /// Nome da rua
    /// </summary>
    public string Rua { get; set; }

    /// <summary>
    /// Número da residência ou estabelecimento
    /// </summary>
    public string Numero { get; set; }

    /// <summary>
    /// Informações adicionais sobre o endereço
    /// </summary>
    public string Observacao { get; set; }

    public virtual ICollection<TClifor> TClifors { get; set; } = new List<TClifor>();
}
