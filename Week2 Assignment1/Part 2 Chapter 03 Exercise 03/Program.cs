class Chapter03
{
    static void Main(string[] args)
    {
        Console.WriteLine("FizzBuzz");
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine();
        Console.WriteLine("If the code executes, it will create an infinite loop, " +
            "as byte can only hold values up to 255, and max is 500. When i reaches 255, " +
            "it will wrap around to 0 and continue the loop indefinitely.");

        Console.WriteLine();
        Console.WriteLine("I will add a if condition inside the for loop to check if i == byte.MaxValue to handle error");
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            Console.WriteLine(i);
            if (i == byte.MaxValue)
            {
                Console.WriteLine("Warning: i has reached the maximum value of a byte.");
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Your program can create a random number between 1 and 3 with the following code");
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number between 1 and 3:");
        int guessedNumber = int.Parse(Console.ReadLine());
        while(guessedNumber != correctNumber)
        {
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Invalid guess: must be between 1 and 3.");
            }
            else if (guessedNumber < correctNumber)
            {
                Console.WriteLine("Too low.");
            }
            else if (guessedNumber > correctNumber)
            {
                Console.WriteLine("Too high.");
            }
            
            guessedNumber = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Correct!");

        Console.WriteLine();
        Console.WriteLine("Print-a-prymid");
        int rows = int.Parse(Console.ReadLine());
        

        for (var i = 1; i <= rows; i++)
        {
            for (var j = i; j < rows; j++)
            {
                Console.Write(" ");
            }
            for (var k = 1; k < i * 2; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Birthday");
        int year, month, day;

        // Loop until valid year is entered
        while (true)
        {
            Console.Write("Enter your birth year: ");
            if (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year, please enter a valid integer.");
                continue;
            }
            if (year < 1 || year > DateTime.Today.Year)
            {
                Console.WriteLine("Invalid year, please enter a valid year between 1 and " + DateTime.Today.Year + ".");
                continue;
            }
            break;
        }

        // Loop until valid month is entered
        while (true)
        {
            Console.Write("Enter your birth month (1-12): ");
            if (!int.TryParse(Console.ReadLine(), out month))
            {
                Console.WriteLine("Invalid month, please enter a valid integer.");
                continue;
            }
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Invalid month, please enter a valid month between 1 and 12.");
                continue;
            }
            break;
        }

        // Loop until valid day is entered
        while (true)
        {
            Console.Write("Enter your birth day: ");
            if (!int.TryParse(Console.ReadLine(), out day))
            {
                Console.WriteLine("Invalid day, please enter a valid integer.");
                continue;
            }
            if (day < 1 || day > GetDaysInMonth(year, month))
            {
                Console.WriteLine("Invalid day, please enter a valid day for the selected month and year.");
                continue;
            }
            break;
        }

        DateTime birthDate = new DateTime(year, month, day);
        DateTime today = DateTime.Today;

        int ageInDays = (today - birthDate).Days;
        Console.WriteLine("Age in days: " + ageInDays);

        int daysToNextAnniversary = 10000 - (ageInDays % 10000);
        DateTime nextAnniversary = today.AddDays(daysToNextAnniversary);
        Console.WriteLine("Next anniversary in days: " + daysToNextAnniversary);
        Console.WriteLine("Next anniversary date: " + nextAnniversary.ToShortDateString());

        Console.WriteLine();
        Console.WriteLine("Greeting");
        DateTime now = DateTime.Now;
        int hour = now.Hour;

        if (hour < 12)
        {
            Console.WriteLine("Good Morning");
        }
        if (hour >= 12 && hour < 18)
        {
            Console.WriteLine("Good Afternoon");
        }
        if (hour >= 18 && hour < 22)
        {
            Console.WriteLine("Good Evening");
        }
        if (hour >= 22 || hour < 6)
        {
            Console.WriteLine("Good Night");
        }

        Console.WriteLine();
        Console.WriteLine("Counting");
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j <= 24; j += i)
            {
                Console.Write(j + ",");
            }
            Console.WriteLine();
        }
    }
    static int GetDaysInMonth(int year, int month)
    {
        switch (month)
        {
            case 2:
                if (DateTime.IsLeapYear(year))
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            default:
                return 31;
        }
    }
}

    