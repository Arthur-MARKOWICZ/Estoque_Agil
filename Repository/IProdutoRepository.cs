using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAgil.model;
using EstoqueAgil.DTOs;
namespace EstoqueAgil.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> PegarProdutoPorId(int id);
        Task<Produto> SalvarProduto(ProdutoCAdastroDTO dTO);
        Task SalvarAlteracao();
    }
}