
using Application.Interfaces;
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

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _adminRepository.GetAllAdmins();
        }

        public Admin GetAdminById(int id)
        {
            return _adminRepository.GetAdminById(id);
        }

        public void CreateAdmin(Admin admin)
        {
            _adminRepository.AddAdmin(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminRepository.UpdateAdmin(admin);
        }

        public void DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetAdminById(id);
            if (admin == null)
            {
                //lo mismo
            }
            _adminRepository.DeleteAdmin(admin);
        }
    }
}
