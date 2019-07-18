using Layered.EF;
using Layered.Extensions.Attributes;

namespace Layered.Repository
{
    [Injectable]
    public class DbFactory : IDbFactory
    {
        static PeopleDBEntities _dbContext;

        public PeopleDBEntities Init()
        {
            return _dbContext ?? (_dbContext = new PeopleDBEntities());
        }
    }
}