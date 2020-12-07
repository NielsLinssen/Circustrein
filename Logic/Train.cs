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
            bool isAdded = false;

            // Loop through wagons to try to add the animal
            foreach (Wagon _wagon in Wagons)
            {
                if (_wagon.TryAddAnimal(animal))
                {
                    isAdded = true;
                    break;
                }
            }

            // If the animal is not added to any wagon create and empty wagon and add the animal to it
            if (!isAdded)
            {
                Wagon wagon = new Wagon();
                wagon.TryAddAnimal(animal);

                Wagons.Add(wagon);
            }
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
