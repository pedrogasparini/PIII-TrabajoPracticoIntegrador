
using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Exceptions;

namespace Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleDetailsRepository _saledetailsRepository;

        public SaleService(ISaleRepository saleRepository, ISaleDetailsRepository saledetailsRepository)
        {
            _saleRepository = saleRepository;
            _saledetailsRepository = saledetailsRepository;
        }


        public IEnumerable<SaleDTO> GetAllSales()
        {
            var objs = _saleRepository.GetAll();
            return SaleDTO.CreateList(objs);
        }

        public SaleDTO GetSaleById(int id)
        {
            var obj = _saleRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Sale), id);
            return SaleDTO.Create(obj);
        }

        public void CreateSale(SaleCreateRequest saleCreteRequest)
        {
            
            var saledetails = new List<SaleDetail>();
            foreach (var saledetailId in saleCreteRequest.SaleDetailIds)
            {
                var saledetail = _saledetailsRepository.GetById(saledetailId);
                if (saledetail != null)
                {
                    saledetails.Add(saledetail);
                }
            }
            var sale = new Sale(saleCreteRequest.Date, saledetails, saleCreteRequest.Total);
            _saleRepository.Add(sale);
        }

        public void UpdateSale(int id, SaleUpdateRequest saleUpdateRequest)
        {
            var sale = _saleRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Sale), id); 

            if (saleUpdateRequest.Total != null) sale.Total = saleUpdateRequest.Total;

            _saleRepository.Update(sale);
        }

        public void DeleteSale(int id)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                throw new NotFoundException(nameof(Sale), id);
            }
            _saleRepository.Delete(sale);
        }
    }
}
