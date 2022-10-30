using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalogList = new List<Catalog>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commArr = command.Split(' ');
                string typeOfVehicle = commArr[0];
                string model = commArr[1];
                string color = commArr[2];
                int horsepower = int.Parse(commArr[3]);

                Catalog catalog = new Catalog(typeOfVehicle, model, color, horsepower);
                catalogList.Add(catalog);


            }
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {

                Console.WriteLine(catalogList.Find(x => x.Model == command));

            }
            List<Catalog> onlyCars = catalogList.Where(x => x.TypeOfVehicle == "car").ToList();
            List<Catalog> onlyTrucks = catalogList.Where(x => x.TypeOfVehicle == "truck").ToList();
            double totalCarsHorsepower = 0;
            double totalTrucksHorsepower = 0;

            foreach (var car in onlyCars)
            {
                totalCarsHorsepower += car.Horsepower;
            }

            foreach (var truck in onlyTrucks)
            {
                totalTrucksHorsepower += truck.Horsepower;
            }

            double averageCarsHorsepower = totalCarsHorsepower / onlyCars.Count;
            double averageTrucksHorsepower = totalTrucksHorsepower / onlyTrucks.Count;

            if (onlyCars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:f2}.");

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (onlyTrucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
    internal class Catalog
    {
        public Catalog(string typeOfVehicle, string model, string color, int horsepower)
        {
            TypeOfVehicle = typeOfVehicle;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
        public override string ToString()
        {
            string vehicleStr = $"Type: {(this.TypeOfVehicle == "truck" ? "Truck" : "Car")}{Environment.NewLine}" + $"Model: {this.Model}{Environment.NewLine}" +
                                $"Color: {this.Color}{Environment.NewLine}" + $"Horsepower: {this.Horsepower}";

            return vehicleStr;
        }

    }

}
