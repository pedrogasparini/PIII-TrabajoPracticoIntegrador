using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        void CreateProduct(ProductCreateRequest productCreateRequest);
        void UpdateProduct(int id, ProductUpdateRequest productUpdateRequest);
        void DeleteProduct(int id);
    }
}

