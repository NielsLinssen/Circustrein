﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Wagon
    {
        private int MaxSize = 10;

        private List<Animal> Animals = new List<Animal>();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Wagon() { }

        /// <summary>
        /// Get size of current Wagon
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return MaxSize;
        }

        /// <summary>
        /// Add animal to Wagon
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            // Add the animal to the list and decrease the wagon size
            Animals.Add(animal);
            MaxSize -= animal.GetSize();
        }

        /// <summary>
        /// Check if the animal can be added to the wagon
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CheckAnimalAdd(Animal animal)
        {
            // Check if the maxsize is bigger than the animal size
            // If not we need a new wagon
            if (MaxSize >= animal.GetSize())
            {
                // Flow changes if the animal is a Carnivore so check for that
                if (animal is Carnivore)
                {
                    // Is there already a Carnivore in this wagon?
                    if (!this.CheckCarnivore())
                    {
                        // There is no carnivore already in the wagon
                        // Carnivore must be smaller than any potential herbivores
                        Animal smallestHerbivore = this.GetSmallestHerbivore();
                        if (smallestHerbivore != null && smallestHerbivore.GetSize() > animal.GetSize())
                        {
                            return true;
                        }
                    }
                } 
                else // Animal is a Herbivore
                {
                    // Is the size bigger than the biggest potential carnivore?
                    Animal biggestCarnivore = this.GetBiggestCarnivore();
                    if (animal.GetSize() > biggestCarnivore.GetSize())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check whether there is a carnivore already in the wagon
        /// </summary>
        /// <returns></returns>
        private bool CheckCarnivore()
        {
            // Animals.Any(a => a is Carnivore) is always false.
            //if (Animals.Any(a => a is Carnivore))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            // We'll loop through the animals to check
            foreach(Animal animal in Animals)
            {
                if (animal is Carnivore)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Return the smallest herbivore in the wagon
        /// </summary>
        /// <returns></returns>
        private Herbivore GetSmallestHerbivore()
        {
            // Loop through the animals since we cannot use LINQ for this
            // Also cannot create new Animal() due to it being an abstract class. Use null instead.
            Herbivore _animal = null;

            foreach (Animal animal in Animals)
            {
                // We only need Herbivores
                if (animal is Herbivore)
                {
                    // If _animal is null this means we can fill it
                    if (_animal == null)
                    {
                        _animal = (Herbivore)animal;
                    }
                    else if (animal.GetSize() < _animal.GetSize()) // _animal was not null so we can start comparing it to other animals
                    {
                        // Current animal is bigger than the loop animal so replace the object
                        _animal = (Herbivore)animal;
                    }
                }
            }
            
            return _animal;
        }

        /// <summary>
        /// Return the biggest carnivore
        /// </summary>
        /// <returns></returns>
        private Carnivore GetBiggestCarnivore()
        {
            // Only 1 carnivore can exist in a wagon so we loop until we find it
            // Because there can be no Carnivore create an empty Carnivore object we can return if there are no matches
            Carnivore _animal = new Carnivore("", 0);

            foreach (Animal animal in Animals)
            {
                // We only the carnivore
                if (animal is Carnivore)
                {
                    _animal = (Carnivore)animal;
                    // We have our result, break out of the loop
                    break;
                }
            }

            return _animal;
        }

        public string FormatAnimals()
        {
            string formattedAnimals = "";

            foreach (Animal animal in Animals)
            {
                // For each animal in the Wagon loop through and print its name, size and type
                formattedAnimals += $"\r\n  {animal.GetName()} (Size: {animal.GetSize()}) (Type: {animal.GetType()})";
            }

            return formattedAnimals;
        }
    }
}
