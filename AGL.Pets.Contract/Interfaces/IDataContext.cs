using System.Linq;

namespace AGL.Pets.Contract.Interfaces
{
    /// <summary>
    /// DataContext interfact
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// IQuarable Persons
        /// </summary>
        IQueryable<Person> Persons { get; set; }
    }
}
