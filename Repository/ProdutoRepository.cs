using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAgil.Repository;
using EstoqueAgil.model;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Produto> SalvarProduto(Produto produto)
        {

            _context.Produto.Add(produto);
            _context.SaveChanges();
            return produto;
        }
        public async Task SalvarAlteracao()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<PageResult<Produto>> pegarTodosProdutos(int page, int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var query = _context.Produto.AsQueryable();

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<Produto>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = items
            };
        }
        public  void DeletarProduto(Produto produto) {
             _context.Produto.Remove(produto);
            _context.SaveChanges();
        }
    }
    
}