using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAgil.Repository;
using EstoqueAgil.model;
namespace EstoqueAgil.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EstoqueAgilDbContext _context;
        public ProdutoRepository(EstoqueAgilDbContext context)
        {
            _context = context;
        }
        public async Task<Produto> PegarPorId(int id)
        {
            Produto produto = await _context.Produto.FindAsync(id);
            return produto;
        }
        public async Task<Produto> SalvarProduto(ProdutoCAdastroDTO dTO)
        {
            Produto produto = new Produto(dTO.Nome);
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return produto;
        }
            public async Task SalvarAlteracao()
        {
            await _context.SaveChangesAsync();
        }
    }
}