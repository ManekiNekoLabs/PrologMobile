using PrologMobile.Models;

namespace PrologMobile.Services
{
    public class OrganizationService
    {
        private readonly YourDbContext _context;

        public OrganizationService(YourDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrganizationSummary> GetOrganizationsSummary()
        {
            var organizations = _context.Organizations.ToList();

            return organizations.Select(org => new OrganizationSummary
            {
                Id = org.Id.ToString(),
                Name = org.Name,
                Users = _context.Users
                    .Where(u => u.OrganizationId == org.Id)
                    .Select(u => new UserSummary
                    {
                        Id = u.Id.ToString(),
                        Name = u.Name,
                        Avatar = u.Avatar, // Include the Avatar property
                        PhoneCount = _context.Phones.Count(p => p.UserId == u.Id)
                    }).ToList(),
                BlacklistTotal = _context.Phones.Count(p => p.User.OrganizationId == org.Id && p.Blacklisted).ToString(),
                TotalCount = _context.Phones.Count(p => p.User.OrganizationId == org.Id).ToString()
            }).ToList(); // Materialize the query results immediately
        }
    }

    public class OrganizationSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserSummary> Users { get; set; }
        public string BlacklistTotal { get; set; }
        public string TotalCount { get; set; }
    }

    public class UserSummary
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; } // Nullable string for Avatar
        public int PhoneCount { get; set; }
    }
}
