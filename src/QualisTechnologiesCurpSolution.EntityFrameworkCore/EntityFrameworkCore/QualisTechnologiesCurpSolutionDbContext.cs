using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QualisTechnologiesCurpSolution.Authorization.Roles;
using QualisTechnologiesCurpSolution.Authorization.Users;
using QualisTechnologiesCurpSolution.MultiTenancy;

namespace QualisTechnologiesCurpSolution.EntityFrameworkCore
{
    public class QualisTechnologiesCurpSolutionDbContext : AbpZeroDbContext<Tenant, Role, User, QualisTechnologiesCurpSolutionDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public QualisTechnologiesCurpSolutionDbContext(DbContextOptions<QualisTechnologiesCurpSolutionDbContext> options)
            : base(options)
        {
        }
    }
}
