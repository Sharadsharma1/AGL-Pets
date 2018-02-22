using System.Collections.Generic;

namespace AGL.Pets.Contract.Interfaces
{
    public interface IPerson
    {
        int Age { get; set; }

        string Gender { get; set; }

        string Name { get; set; }

        ICollection<IPet> Pets { get; set; }
    }
}