
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int id);
        void CreateAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}

