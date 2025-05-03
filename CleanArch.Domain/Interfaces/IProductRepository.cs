using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetProducts(); 
        Task<Products> GetProductById(int id);
        
        void Add(Products product);
        void Update(Products product);
        void Delete(int id);
    }
}