using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interface;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService:IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var products = await _productRepository.GetProducts();
            var productViewModels = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return productViewModels;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public void Add(ProductViewModel product)
        {
            
            var mapProduct = _mapper.Map<Products>(product);
            _productRepository.Add(mapProduct);
          
        }

        public void Update(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Products>(productViewModel);
            _productRepository.Update(product);
        }

        public void Remove(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                _productRepository.Delete(id);
            }
        }
    }
}