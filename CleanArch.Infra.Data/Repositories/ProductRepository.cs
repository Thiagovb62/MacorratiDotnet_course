using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetProductById(int id)
        {

            Products products = await _context.Products
                .FirstAsync(p => p.Id == id);

            if (products == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            {
                return products;
            }

        }

        public void Add(Products product)
        {
             _context.Products.AddAsync(product);
             _context.SaveChangesAsync();
        }

        public void Update(Products product)
        {
            _context.Update(product);

             _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }
        }
    }
}