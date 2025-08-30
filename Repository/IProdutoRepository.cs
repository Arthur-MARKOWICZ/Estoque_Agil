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
        Task<Produto> PegarPorId(int id);
        Task<Produto> SalvarProduto(Produto produto);
        Task SalvarAlteracao();
        Task<PageResult<Produto>> pegarTodosProdutos(int page, int pageSize = 10);
        void  DeletarProduto(Produto produto);
    }
}