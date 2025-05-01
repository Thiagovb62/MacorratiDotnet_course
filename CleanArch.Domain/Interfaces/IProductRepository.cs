using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts(); 
    }
}