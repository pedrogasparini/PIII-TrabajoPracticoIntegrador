
using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using global::Application.Interfaces;
using Domain.Exceptions;

namespace Application.Services
{
    public class SaleDetailsService : ISaleDetailService
    {
        private readonly ISaleDetailsRepository _saledetailsRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;


        public SaleDetailsService(ISaleDetailsRepository saledetailsRepository, ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saledetailsRepository = saledetailsRepository;
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }


        public IEnumerable<SaleDetailDTO> GetAllSaleDetails()
        {
            var objs = _saledetailsRepository.GetAll();
            return SaleDetailDTO.CreateList(objs);
        }

        public SaleDetailDTO GetSaleDetailById(int id)
        {
            var obj = _saledetailsRepository.GetById(id)
                ?? throw new NotFoundException(nameof(SaleDetail), id);
            return SaleDetailDTO.Create(obj);
        }

        public void CreateSaleDetail(SaleDetailCreateRequest saledetailCreteRequest)
        {
            var sale = _saleRepository.GetById(saledetailCreteRequest.SaleId);
            var product = _productRepository.GetById(saledetailCreteRequest.ProductId);

            // Verifica que el producto exista
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), saledetailCreteRequest.ProductId);
            }

            // Verifica que haya suficiente stock
            if (product.StockAvailable < saledetailCreteRequest.Quantity)
            {
                // Se lanza una excepción más específica con un mensaje claro
                throw new InvalidStockException("No hay suficiente stock disponible para este producto.");
            }

            // Resta la cantidad del stock del producto
            product.StockAvailable -= saledetailCreteRequest.Quantity;

            // Actualiza el producto en el repositorio
            _productRepository.Update(product);

            var saledetail = new SaleDetail(sale, product, saledetailCreteRequest.Quantity, saledetailCreteRequest.UnitPrice);
            _saledetailsRepository.Add(saledetail);
        }

        public void UpdateSaleDetail(int id, SaleDetailUpdateRequest saledetailUpdateRequest)
        {
            var saledetail = _saledetailsRepository.GetById(id)
                ?? throw new NotFoundException(nameof(SaleDetail), id);
            var sale = _saleRepository.GetById(saledetailUpdateRequest.SaleId);
            var product = _productRepository.GetById(saledetailUpdateRequest.ProductId);

            if (saledetailUpdateRequest.Quantity != null) saledetail.Quantity = saledetailUpdateRequest.Quantity;

            if (saledetailUpdateRequest.UnitPrice != null) saledetail.UnitPrice = saledetailUpdateRequest.UnitPrice;

            saledetail.Product = product;

            saledetail.Sale = sale;

            _saledetailsRepository.Update(saledetail);
        }

        public void DeleteSaleDetail(int id)
        {
            var saledetails = _saledetailsRepository.GetById(id);
            if (saledetails == null)
            {
                throw new NotFoundException(nameof(SaleDetail), id);
            }
            _saledetailsRepository.Delete(saledetails);
        }
    }
}
