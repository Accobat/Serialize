using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Serialize_People
{
    [Serializable]
    class Person : IDeserializationCallback
    {
        void IDeserializationCallback.OnDeserialization(Object sender)
        {
             
            CalculateAge();
        }


        public string name;
        public DateTime dateOfBirth;
        [NonSerialized] public int age;


        public Person(string _name, DateTime _dateOfBirth)
        {
            name = _name;
            dateOfBirth = _dateOfBirth;
            CalculateAge();
        }

        public Person()
        {
            
        }
        private static void Serialize(Person sp)
        {
            // TODO: Serialize sp object
            // Create file to save the data to
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, sp);

            // Close the file
            fs.Close();

        }

        public override string ToString()
        {
            return name + " was born on " + dateOfBirth.ToShortDateString() + " and is " + age.ToString() + " years old.";
        }

        private void CalculateAge()
        {
            age = DateTime.Now.Year - dateOfBirth.Year;

            // If they haven't had their birthday this year, 
            // subtract a year from their age
            if (dateOfBirth.AddYears(DateTime.Now.Year - dateOfBirth.Year) > DateTime.Now)
            {
                age--;
            }
        }
    }
}
