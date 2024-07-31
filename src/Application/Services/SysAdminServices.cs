using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class SysAdminService : ISysAdminService
    {
        private readonly ISysAdminRepository _sysadminRepository;

        public SysAdminService(ISysAdminRepository sysadminRepository)
        {
            _sysadminRepository = sysadminRepository;
        }

        public IEnumerable<SysAdminDTO> GetAllSysAdmins()
        {
            var objs = _sysadminRepository.GetAll();
            return SysAdminDTO.CreateList(objs);
        }

        public SysAdminDTO GetSysAdminById(int id)
        {
            var obj = _sysadminRepository.GetById(id)
                ?? throw new NotFoundException(nameof(SysAdmin), id);
            return SysAdminDTO.Create(obj);
        }

        public void CreateSysAdmin(SysAdminCreateRequest sysAdminCreteRequest)
        {
            var sysAdmin = new SysAdmin(sysAdminCreteRequest.Name, sysAdminCreteRequest.LastName, sysAdminCreteRequest.Email, sysAdminCreteRequest.Username, sysAdminCreteRequest.Password);
            _sysadminRepository.Add(sysAdmin);
        }
        public void UpdateSysAdmin(int id, SysAdminUpdateRequest sysAdminUpdateRequest)
        {
            var admin = _sysadminRepository.GetById(id)
                ?? throw new NotFoundException(nameof(SysAdmin), id);

            if (sysAdminUpdateRequest.Name != string.Empty) admin.Name = sysAdminUpdateRequest.Name;

            if (sysAdminUpdateRequest.Email != string.Empty) admin.Email = sysAdminUpdateRequest.Email;

            if (sysAdminUpdateRequest.Password != string.Empty) admin.Password = sysAdminUpdateRequest.Password;

            if (sysAdminUpdateRequest.Username != string.Empty) admin.Username = sysAdminUpdateRequest.Username;

            if (sysAdminUpdateRequest.LastName != string.Empty) admin.LastName = sysAdminUpdateRequest.LastName;

            _sysadminRepository.Update(admin);
        }
        public void DeleteSysAdmin(int id)
        {
            var sysadmin = _sysadminRepository.GetById(id);
            if (sysadmin == null)
            {
                throw new NotFoundException(nameof(SysAdmin), id);
            }
            _sysadminRepository.Delete(sysadmin);
        }


    }
}