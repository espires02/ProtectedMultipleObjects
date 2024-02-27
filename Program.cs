namespace Inheritance
{
    //base class
    class Games
    {
        protected string _Name;
        protected int _ReleaseDate;
        protected string _Type;

        //default
        public Games()
        {
            _Name = string.Empty;
            _ReleaseDate = 0;
            _Type = string.Empty;
        }
        //parameterized
        public Games(string name, int releaseDate, string type)
        {
            _Name = name;
            _ReleaseDate = releaseDate;
            _Type = type;
        }

        public virtual void addChange()
        {
            Console.Write("Name=");
            _Name=(Console.ReadLine());
            Console.Write("Release date=");
            _ReleaseDate=(int.Parse(Console.ReadLine()));
            Console.Write("Type=");
            _Type=(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine($"Name: {_Name}");
            Console.WriteLine($"Release date: {_ReleaseDate}");
            Console.WriteLine($"Type: {_Type}");
        }
    }
    class videoGames : Games
    {
        protected string _Developer;
        protected string _Style;

        //default
        public videoGames()
        {
            _Name = string.Empty;
            _ReleaseDate = 0;
            _Type = string.Empty;
            _Developer = string.Empty;
            _Style = string.Empty;
        }

        //parameterized
        public videoGames(string name, int releaseDate, string type, string developer, string style)
        {
            _Name = string.Empty;
            _ReleaseDate = 0;
            _Type = string.Empty;
            _Developer = developer;
            _Style = style;
        }

        public override void addChange()
        {
            Console.Write("Name=");
            _Name = (Console.ReadLine());
            Console.Write("Release date=");
            _ReleaseDate = (int.Parse(Console.ReadLine()));
            Console.Write("Type=");
            _Type = (Console.ReadLine());
            Console.Write("Developer=");
            _Developer = (Console.ReadLine());
            Console.WriteLine("Style=");
            _Style = (Console.ReadLine());
        }

        public override void print()
        {
            Console.WriteLine($"Name: {_Name}");
            Console.WriteLine($"Release date: {_ReleaseDate}");
            Console.WriteLine($"Type: {_Type}");
            Console.WriteLine($"Developer: {_Developer}");
            Console.WriteLine($"Style: {_Style}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many games do you want to enter?");
            int maxGms;
            while (!int.TryParse(Console.ReadLine(), out maxGms))
                Console.WriteLine("Please enter a whole number");
            Games[] gms = new Games[maxGms];
            Console.WriteLine("How many video games do you want to enter?");
            int maxVGms;
            while (!int.TryParse(Console.ReadLine(), out maxVGms))
                Console.WriteLine("Please enter a whole number");
            videoGames[] vgms = new videoGames[maxVGms];

            int choice, rec, type;
            int gmsCounter = 0, vgmsCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Video Games or 2 for Games");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Video Games or 2 for Games");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //Video games
                            {
                                if (vgmsCounter <= maxVGms)
                                {
                                    vgms[vgmsCounter] = new videoGames(); // places an object in the array instead of null
                                    vgms[vgmsCounter].addChange();
                                    vgmsCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of video games has been added");

                            }
                            else //games
                            {
                                if (gmsCounter <= maxGms)
                                {
                                    gms[gmsCounter] = new Games(); // places an object in the array instead of null
                                    gms[gmsCounter].addChange();
                                    gmsCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of games has been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //video games
                            {
                                while (rec > vgmsCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                vgms[rec].addChange();
                            }
                            else // games
                            {
                                while (rec > gmsCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                gms[rec].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //video games
                            {
                                for (int i = 0; i < vgmsCounter; i++)
                                    vgms[i].print();
                            }
                            else // games
                            {
                                for (int i = 0; i < gmsCounter; i++)
                                    gms[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }

        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }

}
