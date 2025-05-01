using System.Collections.Generic;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetProducts()
        {
            return _context.Products;
        }
    }
}