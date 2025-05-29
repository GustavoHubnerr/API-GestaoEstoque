using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_GstaoEstoque.BaseDados.Models;

public partial class DbTrabalhoFinalContext : DbContext
{
    public DbTrabalhoFinalContext()
    {
    }

    public DbTrabalhoFinalContext(DbContextOptions<DbTrabalhoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TClifor> TClifors { get; set; }

    public virtual DbSet<TEndereco> TEnderecos { get; set; }

    public virtual DbSet<TEstoque> TEstoques { get; set; }

    public virtual DbSet<TMovimentoest> TMovimentoests { get; set; }

    public virtual DbSet<TProduto> TProdutos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=DB_TRABALHO_FINAL;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TClifor>(entity =>
        {
            entity.HasKey(e => e.IdClifor).HasName("t_clifor_pkey");

            entity.ToTable("t_clifor");

            entity.Property(e => e.IdClifor).HasColumnName("id_clifor");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(20)
                .HasComment("CPF ou CNPJ")
                .HasColumnName("cpf_cnpj");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasComment("Email de contato")
                .HasColumnName("email");
            entity.Property(e => e.IdEndereco)
                .HasComment("Endereço vinculado (FK para t_endereco)")
                .HasColumnName("id_endereco");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome do cliente ou fornecedor")
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasComment("Telefone de contato")
                .HasColumnName("telefone");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasComment("Tipo: C = Cliente, F = Fornecedor")
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.TClifors)
                .HasForeignKey(d => d.IdEndereco)
                .HasConstraintName("fk_endereco");
        });

        modelBuilder.Entity<TEndereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("t_endereco_pkey");

            entity.ToTable("t_endereco");

            entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .HasComment("Nome do bairro")
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .HasComment("Código de Endereçamento Postal")
                .HasColumnName("cep");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasComment("Número da residência ou estabelecimento")
                .HasColumnName("numero");
            entity.Property(e => e.Observacao)
                .HasComment("Informações adicionais sobre o endereço")
                .HasColumnName("observacao");
            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .HasComment("Nome da rua")
                .HasColumnName("rua");
        });

        modelBuilder.Entity<TEstoque>(entity =>
        {
            entity.HasKey(e => e.IdEstoque).HasName("t_estoque_pkey");

            entity.ToTable("t_estoque");

            entity.Property(e => e.IdEstoque).HasColumnName("id_estoque");
            entity.Property(e => e.IdProduto)
                .HasComment("Produto relacionado (FK para t_produtos)")
                .HasColumnName("id_produto");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10, 2)
                .HasComment("Quantidade atual em estoque")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.TEstoques)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estoque_produto");
        });

        modelBuilder.Entity<TMovimentoest>(entity =>
        {
            entity.HasKey(e => e.IdMovimento).HasName("t_movimentoest_pkey");

            entity.ToTable("t_movimentoest");

            entity.Property(e => e.IdMovimento).HasColumnName("id_movimento");
            entity.Property(e => e.DataMovimento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Data da movimentação")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_movimento");
            entity.Property(e => e.IdClifor)
                .HasComment("Cliente ou fornecedor relacionado (FK para t_clifor)")
                .HasColumnName("id_clifor");
            entity.Property(e => e.IdProduto)
                .HasComment("Produto movimentado (FK para t_produtos)")
                .HasColumnName("id_produto");
            entity.Property(e => e.Observacao)
                .HasComment("Observações sobre o movimento")
                .HasColumnName("observacao");
            entity.Property(e => e.Quantidade)
                .HasPrecision(10, 2)
                .HasComment("Quantidade movimentada")
                .HasColumnName("quantidade");
            entity.Property(e => e.TipoMovimento)
                .HasMaxLength(1)
                .HasComment("E = Entrada, S = Saída")
                .HasColumnName("tipo_movimento");

            entity.HasOne(d => d.IdCliforNavigation).WithMany(p => p.TMovimentoests)
                .HasForeignKey(d => d.IdClifor)
                .HasConstraintName("fk_movimento_clifor");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.TMovimentoests)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimento_produto");
        });

        modelBuilder.Entity<TProduto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("t_produtos_pkey");

            entity.ToTable("t_produtos");

            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.Fornecedor)
                .HasComment("Fornecedor principal (FK para t_clifor)")
                .HasColumnName("fornecedor");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome do produto")
                .HasColumnName("nome");
            entity.Property(e => e.PrecoCusto)
                .HasPrecision(10, 2)
                .HasComment("Preço de custo")
                .HasColumnName("preco_custo");
            entity.Property(e => e.PrecoVenda)
                .HasPrecision(10, 2)
                .HasComment("Preço de venda")
                .HasColumnName("preco_venda");
            entity.Property(e => e.SituacaoProduto)
                .HasMaxLength(1)
                .HasDefaultValueSql("'A'::bpchar")
                .HasComment("Situação: A = Ativo, I = Inativo")
                .HasColumnName("situacao_produto");
            entity.Property(e => e.UndMedida)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("Unidade de medida (ex: UN, KG, L)")
                .HasColumnName("und_medida");

            entity.HasOne(d => d.FornecedorNavigation).WithMany(p => p.TProdutos)
                .HasForeignKey(d => d.Fornecedor)
                .HasConstraintName("fk_produto_fornecedor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
