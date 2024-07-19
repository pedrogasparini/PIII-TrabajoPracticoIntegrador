
using Application.Models;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<AdminDTO> GetAllAdmins();
        AdminDTO GetAdminById(int id);
        void CreateAdmin(AdminCreateRequest adminCreateRequest);
        void UpdateAdmin(int id ,AdminUpdateRequest adminUpdateRequest);
        void DeleteAdmin(int id);
    }
}

