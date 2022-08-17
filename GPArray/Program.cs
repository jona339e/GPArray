namespace GPArray
{
    class Program
    {
        static string[] arrangements = new string[100];
        static int[,] tickets = new int[1000, 2];
        static void Main(string[] args)
        {
            Console.WriteLine(tickets.Length);
            AddToArray();
            while (true)
            {
                menu();

            }
        }
        static void menu()
        {
            Console.WriteLine("1. Vis arrangementer \n2. Køb Billet\n3. Vis alle købte billetter\n\nIndtast valg:\n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    {
                        ShowAllArrangements();
                        break;
                    }
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    {
                        ShowAllArrangements();
                        int t = BuyTicket();
                        Console.WriteLine("Du har nummer " + t + " af " + tickets.GetLength(0));
                        break;
                    }
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    {
                        ShowTicketsBought();
                        Console.WriteLine("\n");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Defaulted");
                        break;
                    }
            }
        }

        static void ShowTicketsBought()
        {
            Console.WriteLine("Antal\tArrangment\tLokation");
            for (int i = 0; i < tickets.GetLength(0); i++)
            {
                if (tickets[i, 0] == 0) return;
                string arr = arrangements[tickets[i,1]];
                string[] splitArray = arr.Split("- ");
                Console.WriteLine(tickets[i, 0] + "\t" + splitArray[0] + "\t" + splitArray[1]);
            }
        }

        static int BuyTicket()
        {
            Console.Write("Indtast nummer op arrangement du ønsker at købe billet på: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int arrangementNumber);
            Console.Write("Indtast antal ønskede billettter: ");
            input = Console.ReadLine();
            int.TryParse(input, out int amountOfTickets);

            int freeSpot = GetNextFreeSpotInTicketArray();
            tickets[freeSpot, 0] = amountOfTickets;
            tickets[freeSpot, 1] = arrangementNumber;
            return freeSpot;

        }

        static int GetNextFreeSpotInTicketArray()
        {
            for (int i = 0; i < tickets.GetLength(0); i++)
            {
                if (tickets[i,0] == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        static void ShowAllArrangements()
        {
            foreach (string band in arrangements)
            {
                ShowArrangement(band);
            }
        }

        static void ShowArrangement(string band)
        {
            if (!string.IsNullOrEmpty(band))
            {
                int i = Array.IndexOf(arrangements, band);
                Console.WriteLine(i + " " + band);
            }
        }

        static void AddToArray()
        {
            arrangements[0] = "Lil Johan - Den Grå Hal";
            arrangements[1] = "Deagel - TEC Kantine";
            arrangements[2] = "Tec Lærerband - Amager Plads";
        }
    }
}