
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int id);
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}

