using Layered.EF;

namespace Layered.Repository
{
    public interface IDbFactory
    {
        PeopleDBEntities Init();
    }
}