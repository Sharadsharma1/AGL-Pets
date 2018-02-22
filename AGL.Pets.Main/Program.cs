using System;
using System.Collections.Generic;
using AGL.Pets.Contract;
using AGL.Pets.Contract.Interfaces;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace AGL.Pets.Repository
{
    class Program
    {
        private static readonly IWindsorContainer DiContainer = new WindsorContainer();

        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // populating windsor container 
            DiContainer.Install(FromAssembly.This());
            var repository = DiContainer.Resolve<IPersonRepository>();

            // Getting Persons dictionary 
            Dictionary<string, List<Pet>>  persons = repository.GetCatsByOwnerGender();

            // Writing persons value on console
            WritePets(persons);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            DiContainer.Dispose();
        }

        /// <summary>
        /// function to write pets information
        /// </summary>
        /// <param name="items"></param>
        private static void WritePets(Dictionary<string, List<Pet>> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine("{0}", item.Key);
                foreach (var pet in item.Value)
                {
                    Console.WriteLine("\t{0}", pet.Name);
                }
            }
        }
    }
}
