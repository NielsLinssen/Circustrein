using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Train
    {
        private List<Wagon> Wagons = new List<Wagon>();

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Train() { }

        public void AddAnimal(Animal animal)
        {
            // Standard Wagon is null, easier to check if the object is filled or not
            Wagon wagon = null;

            // We have to loop through all the wagons to determine if we can put it in an existing one
            foreach (Wagon _wagon in Wagons)
            {
                // Check if we can add the current animal in an existing wagon
                if (_wagon.CheckAnimalAdd(animal))
                {
                    wagon = _wagon;
                    // We have been able to add the animal to a wagon so break out of the loop
                    break;
                }
            }

            // wagon is still null meaning the animal could not be added. Add it to a new one instead
            if (wagon == null)
            {
                wagon = new Wagon();
                Wagons.Add(wagon);
            }

            wagon.AddAnimal(animal);
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
