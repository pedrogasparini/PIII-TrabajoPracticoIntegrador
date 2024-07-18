
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _saleRepository.GetAllSales();
        }

        public Sale GetSaleById(int id)
        {
            return _saleRepository.GetSaleById(id);
        }

        public void AddSale(Sale sale)
        {
            _saleRepository.AddSale(sale);
        }

        public void UpdateSale(Sale sale)
        {
            _saleRepository.UpdateSale(sale);
        }

        public void DeleteSale(int id)
        {
            var sale = _saleRepository.GetSaleById(id);
            if (sale == null)
            {
                //agregsr exc.
            }
            _saleRepository.DeleteSale(sale);
        }
    }
}
