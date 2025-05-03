using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interface
{
    public interface IProductService
    {
        
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
       void Add(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(int id);
    }
}