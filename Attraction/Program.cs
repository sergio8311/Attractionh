using System;
using System.Reflection.Metadata.Ecma335;

namespace Attraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Kid kid = new Kid();
            int height;
            Gender gender;
            WeekDay weekDay;
            Attractions attraction;

            Console.WriteLine("Enter kid height in cm: ");
            while (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Height is not a number");
            }

            kid.Height = height;

            Console.WriteLine("Choose Week Day (Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday): ");
            while (!Enum.TryParse(Console.ReadLine(), out weekDay))
            {
                Console.WriteLine("Enter Week Day in right format: Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday");
            }          

            Console.WriteLine("Choose kid gender (Boy, Girl): ");
            while (!Enum.TryParse(Console.ReadLine(), out gender))
            {
                Console.WriteLine("Uknown gender. Please choose one of: Boy, Girl");
            }          

            kid.Gender = gender;

            Console.WriteLine("Enter Kid Name: ");
            kid.Name = Console.ReadLine();

            Console.WriteLine("Which Attraction kid want to visit (Batman, Swan, Pony): ");
            while (!Enum.TryParse(Console.ReadLine(), out attraction))
            {
                Console.WriteLine($"Uknown Attraction name. Please choose one of: Batman, Swan, Pony.");
            }

            KidAllowedToAttractions(weekDay, kid, attraction);

            Console.ReadKey();
        }

        static bool IsAttractionOpened(WeekDay weekDay, Attractions attraction)
        {
            if (attraction == Attractions.Batman & WeekDay.Monday == weekDay | WeekDay.Wednesday == weekDay |
                WeekDay.Friday == weekDay)
                return true;

            if (attraction == Attractions.Swan & weekDay == WeekDay.Tuesday | weekDay == WeekDay.Wednesday |
                weekDay == WeekDay.Thursday)
                return true;

            if (attraction == Attractions.Pony & weekDay != WeekDay.Sunday)
                return true;

            return false;
        }

        static bool IsKidAllowed(Attractions attraction, Kid kid)
        {
            if (attraction == Attractions.Batman & kid.Height > 150 & kid.Gender == Gender.Boy)
                return true;
            if (attraction == Attractions.Swan & kid.Gender == Gender.Girl & (kid.Height > 120 & kid.Height < 140))
                return true;
            if (attraction == Attractions.Swan & kid.Gender == Gender.Boy & kid.Height < 140)
                return true;
            if (attraction == Attractions.Pony)
                return true;
            return false;
        }

        static void KidAllowedToAttractions(WeekDay weekDay, Kid kid, Attractions attractions)
        {
            if (IsAttractionOpened(weekDay, attractions) & IsKidAllowed(attractions, kid))
            {
                Console.WriteLine($"Kid Name: {kid.Name}");
                Console.WriteLine($"Attraction Name: {attractions}");
            }
                

            else
                Console.WriteLine($"{kid.Name} is not allowed to any of attractions");         
        }
    }
}
