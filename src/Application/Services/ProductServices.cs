using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var objs = _productRepository.GetAll();
            return ProductDTO.CreateList(objs);
        }

        public ProductDTO GetProductById(int id)
        {
            var obj = _productRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Product), id);
            return ProductDTO.Create(obj);
        }

        public void CreateProduct(ProductCreateRequest productCreteRequest)
        {
            var product = new Product(productCreteRequest.Name, productCreteRequest.Price , productCreteRequest.StockAvailable);
            _productRepository.Add(product);
        }

        public void UpdateProduct(int id, ProductUpdateRequest productUpdateRequest)
        {
            var product = _productRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Product), id); 

            if (productUpdateRequest.Name != string.Empty) product.Name = productUpdateRequest.Name;

            if (productUpdateRequest.Price != null) product.Price = productUpdateRequest.Price;

            if (productUpdateRequest.StockAvailable != null) product.StockAvailable = productUpdateRequest.StockAvailable;

            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), id);
            }
            _productRepository.Delete(product);
        }

    }
}



