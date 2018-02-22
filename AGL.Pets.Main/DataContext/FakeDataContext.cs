using AGL.Pets.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AGL.Pets.Contract;

namespace AGL.Pets.Main.Data
{
    /// <summary>
    /// This is fake Data Context Class
    /// </summary>
    public class FakeDataContext : IDataContext
    {
        public IQueryable<Person> Persons
        {
            get { return Task.Run(async () => await GetPersons()).Result;}
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Get Persons from Smmple Data file 
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<Person>> GetPersons()
        {
            var json = string.Empty;
            await Task.Run(() =>
            {
                json = File.ReadAllText(@"..\..\Sampledata\persons.json");
            });

            var result = JsonConvert.DeserializeObject<List<Person>>(json);
            return result.AsQueryable();
        }
    }
}
