namespace Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<DateTime> all13th = GetAll13thDates(5);

            while (true)
            {
                
                Console.WriteLine("Press 1 to show all 13th of every months ( for next 5 years)");
                Console.WriteLine("Press 2 to show only Friday && 13th as a date");
                Console.WriteLine("Press 3 to Exit");
                Console.Write("Choose an option (1-3): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("All 13th dates for the next 5 years: \n");
                    ShowDates(all13th);
                }
                else if (choice == "2")
                {
                    List<DateTime> friday13th = all13th.FindAll(
                        d => d.DayOfWeek == DayOfWeek.Friday);

                    Console.WriteLine("Friday the 13th dates for the next 5 years:\n");
                    ShowDates(friday13th);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(); //this will ask you to press any key and re run the while
                                   //loop as well as it will read the key and print it
            }
        }

        // Creates list of all 13th of every months for given number of years in future (here : for next 5 years )
        static List<DateTime> GetAll13thDates(int numberOfYears)
        {
            var dates = new List<DateTime>();

            DateTime start = DateTime.Today;
            int totalMonths = numberOfYears * 12;

            DateTime first13th = new DateTime(start.Year, start.Month, 13);

            for (int i = 0; i < totalMonths; i++)
            {
                DateTime dt = first13th.AddMonths(i);

                if (dt < start)
                    continue;

                dates.Add(dt);
            }

            return dates;
        }

        // Helper method to print dates

        //IEnumerable is used when we want to iterate through a
        //collection in a read-only manner, especially with LINQ, deferred execution,
        //and loosely-coupled method design.
        static void ShowDates(IEnumerable<DateTime> dates)
        {
            foreach (var d in dates)
            {
                Console.WriteLine(d.ToString("dd MMMM yyyy (dddd)"));
            }
        }
    }
}