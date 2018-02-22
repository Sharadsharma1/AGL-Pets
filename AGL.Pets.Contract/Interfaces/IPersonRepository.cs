using System.Collections.Generic;

namespace AGL.Pets.Contract.Interfaces
{
    /// <summary>
    /// Interface to access the list of Persons.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Get all Persons with Pets as Dicationary with Person's gender as the Key 
        /// and all Pets owned by Persons of that Gender sorted aphabetically as the Value.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, List<Pet>> GetCatsByOwnerGender();
    }
}