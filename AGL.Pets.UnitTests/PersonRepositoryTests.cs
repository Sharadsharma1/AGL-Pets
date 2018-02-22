using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using AGL.Pets.Contract;
using AGL.Pets.Main.Repositories;

namespace AGL.Pets.UnitTests
{
    [TestClass()]
    public class PersonRepositoryTests
    {
        [TestMethod()]
        public void SortCatsByOwnerGenderTest_Valid_Success()
        {
            // ARRANGE
            var context = new TestDataContext
            {
                Persons = new List<Person> {
                    new Person
                    {
                        Gender = "Male",
                        Pets = new List<Pet>
                        {
                            new Pet
                            {
                                Type = "CAT",
                                Name = "X",
                            },
                            new Pet
                            {
                                Type = "CAT",
                                Name = "Y",
                            },
                        }
                    },
                    new Person
                    {
                        Gender = "Female",
                        Pets = new List<Pet>
                        {
                            new Pet
                            {
                                Type = "Cat",
                                Name = "",
                            },
                            new Pet
                            {
                                Type = "Rat",
                                Name = "A",
                            },
                            new Pet
                            {
                                Type = "pigs",
                                Name = "A",
                            },
                            new Pet
                            {
                                Type = "CATt",
                                Name = "A",
                            },
                        }

                    }
                }.AsQueryable(),
            };
            var Repository = new PersonRepository() { Context = context };


            // ACT
            var items = Repository.GetCatsByOwnerGender();

            // ASSERT
            Assert.IsTrue(items.Count == 2);
            Assert.IsTrue(items.Keys.ToList()[0] == "Male");
            Assert.IsTrue(items["Male"].Count == 2);
            Assert.IsTrue(items["Male"][0].Name == "X");
            Assert.IsTrue(items["Male"][1].Name == "Y");
            Assert.IsTrue(items.Keys.ToList()[1] == "Female");
            Assert.IsTrue(items["Female"].Count == 1);
            Assert.IsTrue(items["Female"][0].Name == "");
        }

        [TestMethod()]
        public void SortCatsByOwnerGenderTest_NullPets_Succeed()
        {
            // ARRANGE
            var context = new TestDataContext
            {
                Persons = new List<Person> {
                    new Person
                    {
                        Gender = "Female",
                        Pets = null  
                    }
                }.AsQueryable(),
            };
            var Repository = new PersonRepository() { Context = context };

            // ACT
            var items = Repository.GetCatsByOwnerGender();

            // ASSERT
            Assert.IsTrue(items.Count == 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortCatsByOwnerGenderTest_ArgumentNullException()
        {
            // ARRANGE
            var context = new TestDataContext
            {
                Persons = new List<Person> {
                    new Person
                {
                    Gender = null,
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Type = "caT",
                            Name = "A",
                        },
                    }
                },
                }.AsQueryable(),
            };
            var Repository = new PersonRepository() { Context = context };

            // ACT
            var items = Repository.GetCatsByOwnerGender();

            // ASSERT
            Assert.IsTrue(false);
        }
    }
}
