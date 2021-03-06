﻿using AGL.Pets.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AGL.Pets.Contract;

namespace AGL.Pets.Main.Repositories
{
    /// <summary>
    /// Implementation of the IPersonRepository interfact
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        public IDataContext Context { get; set; }

        /// <summary>
        /// Function to get Cats name by Owner Gender
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Pet>> GetCatsByOwnerGender()
        {
            var query = from a in Context.Persons
                        where a.Pets != null
                        group a by Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(a.Gender) into g
                        select new
                        {
                            Gender = g.Key,
                            Pets = g.SelectMany(a => a.Pets)
                            .Where(b => b.Type.Equals("Cat", StringComparison.InvariantCultureIgnoreCase))
                            .OrderBy(b => b.Name)
                            .ToList(),
                        };

            var result = query.ToDictionary(a => a.Gender, a => a.Pets);

            return result;
        }
    }
}
