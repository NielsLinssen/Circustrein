using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Animal
    {
        private string Name;

        private int Size;

        public Animal() { }

        public Animal(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public int GetSize()
        {
            return Size;
        }

        public string GetName() {
            return Name;
        }
    }
}
