using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestsCircusTrein
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void AddAnimal()
        {
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal animal = new Herbivore("Antilope", 3);

            Assert.AreEqual(true, wagon.TryAddAnimal(animal));
        }

        [TestMethod]
        public void AddCarnivoreToHerbivoreWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Antilope = new Herbivore("Antilope", 3);
            Animal Tiger = new Carnivore("Tiger", 3);

            wagon.TryAddAnimal(Antilope);

            train.Wagons.Add(wagon);

            Assert.AreEqual(false, wagon.TryAddAnimal(Tiger));
        }

        [TestMethod]
        public void AddBiggerCarnivoreToHerbivoreWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Tiger = new Carnivore("Tiger", 3);

            wagon.TryAddAnimal(Elephant);

            train.Wagons.Add(wagon);

            Assert.AreEqual(true, wagon.TryAddAnimal(Tiger));
        }
    }
}
