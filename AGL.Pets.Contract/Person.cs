using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AGL.Pets.Contract
{
    /// <summary>
    /// Person Class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Person
        {
            /// <summary>
            /// Person Age 
            /// </summary>
            public int Age { get; set; }

            /// <summary>
            /// Person Gender
            /// </summary>
            public string Gender { get; set; }

            /// <summary>
            /// Person Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Pets Collection
            /// </summary>
            public ICollection<Pet> Pets { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} {2}", Name, Gender, Age);
            }
        }
    
}
