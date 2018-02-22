using System.Diagnostics.CodeAnalysis;

namespace AGL.Pets.Contract
{
    /// <summary>
    /// Pet Class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Pet
    {
        /// <summary>
        /// Pet Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Pet Type
        /// </summary>
        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Type);
        }
    }
}
