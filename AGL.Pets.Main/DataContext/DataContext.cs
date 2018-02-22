using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AGL.Pets.Contract;
using AGL.Pets.Contract.Interfaces;
using Newtonsoft.Json;

namespace AGL.Pets.Main.DataContext
{
    /// <summary>
    /// DataContext Class 
    /// </summary>
    public class DataContext : IDataContext
    {
        public IQueryable<Person> Persons
        {
            get
            {
                return Task.Run(async () => await GetPersons()).Result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Get Person Json from Url
        /// </summary>
        /// <returns>IQuarable Person</returns>
        public async Task<IQueryable<Person>> GetPersons()
        {
            string url = ConfigurationManager.AppSettings["WebAPIUrl"].ToString();
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            using (var content = response.Content)
            {
                string json = await content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Person>>(json);

                return result.AsQueryable();
            }
        }
    }
}
