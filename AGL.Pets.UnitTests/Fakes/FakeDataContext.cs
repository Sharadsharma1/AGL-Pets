using AGL.Pets.Contract;
using AGL.Pets.Contract.Interfaces;

using System.Linq;

namespace AGL.Pets.UnitTests
{
    public class TestDataContext : IDataContext
    {
        public IQueryable<Person> Persons { get; set; }
    }
}
