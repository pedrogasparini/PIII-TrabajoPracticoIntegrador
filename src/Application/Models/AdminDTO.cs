using Domain.Entities;

namespace Application.Models
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public string Adminname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static AdminDTO Create(Admin admin)
        {
            return new AdminDTO
            {
                Id = admin.Id,
                Adminname = admin.Username,
                Name = admin.Name,
                LastName = admin.LastName,
                Email = admin.Email,
            };
        }

        public static List<AdminDTO> CreateList(IEnumerable<Admin> admins)
        {
            List<AdminDTO> listDto = new List<AdminDTO>();
            foreach (var admin in admins)
            {
                listDto.Add(Create(admin));
            }
            return listDto;
        }
    }
}
