using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Train
    {
        public List<Wagon> Wagons = new List<Wagon>();

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Train() { }

        public void AddAnimal(Animal animal)
        {
            // Standard Wagon is null, easier to check if the object is filled or not
            Wagon wagon = GetSmallestEligeableWagon(animal);

            // If the size is 10 this means there are no animals in the wagon yet
            // AKA, new wagon object
            if (wagon.GetSize() == 10)
            {
                Wagons.Add(wagon);
            }

            wagon.AddAnimal(animal);
        }

        /// <summary>
        /// Get the smallest wagon the animal would still be allowed in.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public Wagon GetSmallestEligeableWagon(Animal animal)
        {
            Wagon wagon = null;

            foreach (Wagon _wagon in Wagons)
            {
                if (_wagon.CheckAnimalAdd(animal))
                {
                    // If wagon is null fill it
                    // If old wagon is bigger than new eligiable wagon replace it.
                    if (wagon == null || wagon.GetSize() > _wagon.GetSize())
                    {
                        wagon = _wagon;
                    }
                }
            }

            // Just in case
            if (wagon == null || wagon.GetSize() < animal.GetSize())
            {
                wagon = new Wagon();
            }

            return wagon;
        }

        public string FormatWagons()
        {
            string formattedWagons = "";

            // Use a for loop so we can use the ii variable for naming purposes
            for (int ii = 0; ii < this.Wagons.Count; ii++)
            {
                // Instantiate an object to use
                Wagon wagon = this.Wagons[ii];
                // Create the string to show to the user
                formattedWagons += $"\r\n Wagon {ii}: " +
                                   $"\r\n Size remaining: {wagon.GetSize()} " +
                                   $"\r\n Animals: {wagon.FormatAnimals()}" +
                                   $"\r\n";
            }

            return formattedWagons;
        }
    }
}
