
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IEnumerable<AdminDTO> GetAllAdmins()
        {
            var objs = _adminRepository.GetAll();
            return AdminDTO.CreateList(objs);
        }

        public AdminDTO GetAdminById(int id)
        {
           var obj =  _adminRepository.GetById(id);
            return AdminDTO.Create(obj);
        }

        public void CreateAdmin(AdminCreateRequest adminCreteRequest)
        {
            var admin = new Admin(adminCreteRequest.Name, adminCreteRequest.LastName, adminCreteRequest.Email, adminCreteRequest.Username, adminCreteRequest.Password);
            _adminRepository.Add(admin);
        }

        public void UpdateAdmin(int id, AdminUpdateRequest adminUpdateRequest)
        {
            var admin = _adminRepository.GetById(id);
            if (adminUpdateRequest.Name != string.Empty) admin.Name = adminUpdateRequest.Name;

            if (adminUpdateRequest.Email != string.Empty) admin.Email = adminUpdateRequest.Email;

            if (adminUpdateRequest.Password != string.Empty) admin.Password = adminUpdateRequest.Password;

            if (adminUpdateRequest.Username != string.Empty) admin.Username = adminUpdateRequest.Username;

            if (adminUpdateRequest.LastName != string.Empty) admin.LastName = adminUpdateRequest.LastName;

            _adminRepository.Update(admin);
        }

        public void DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                //exceptions
            }
            _adminRepository.Delete(admin);
        }
    }
}
