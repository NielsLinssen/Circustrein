using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestsCircusTrein
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        /// Check if the wagons get used optimally.
        public void OptimalHerbivoreTest()
        {
            Train train = new Train();

            Wagon wagon1 = new Wagon();
            Wagon wagon2 = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Antilope = new Herbivore("Antilope", 3);
            Animal Chicken = new Herbivore("Chicken", 1);
            //Animal Monkey = new Herbivore("Monkey", 1);
            //Animal Squirrel = new Herbivore("Squirrel", 1);

            // Pre make wagon1 so we can test the new functionality
            wagon1.AddAnimal(Elephant);
            wagon1.AddAnimal(Antilope);

            train.Wagons.Add(wagon1);
            train.Wagons.Add(wagon2);

            Wagon smallestEligeableWagon = train.GetSmallestEligeableWagon(Chicken);
            smallestEligeableWagon.AddAnimal(Chicken);

            // Size should be 9
            Assert.AreEqual(9, 10 - smallestEligeableWagon.GetSize());
        }

        [TestMethod]
        public void AddCarnivoreToHerbivoreWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Antilope = new Herbivore("Antilope", 3);
            Animal Tiger = new Carnivore("Tiger", 3);

            wagon.AddAnimal(Antilope);

            train.Wagons.Add(wagon);

            Assert.AreEqual(false, wagon.CheckAnimalAdd(Tiger));
        }

        [TestMethod]
        public void AddBiggerCarnivoreToHerbivoreWagon()
        {
            // Setup
            Train train = new Train();

            Wagon wagon = new Wagon();

            Animal Elephant = new Herbivore("Elephant", 5);
            Animal Tiger = new Carnivore("Tiger", 3);

            wagon.AddAnimal(Elephant);

            train.Wagons.Add(wagon);

            Assert.AreEqual(true, wagon.CheckAnimalAdd(Tiger));
        }
    }
}
