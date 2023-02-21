using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)

    {
        CreateACopy();

        CreateAList();

        Console.Write("Enter start number: ");
        int startNum = int.Parse(Console.ReadLine());

        Console.Write("Enter end number: ");
        int endNum = int.Parse(Console.ReadLine());

        int[] primes = FindPrimesInRange(startNum, endNum);

        Console.WriteLine("Prime numbers in the given range:");
        foreach (int prime in primes)
        {
            Console.Write(prime + " ");
        }

        Console.WriteLine();

        RotatedArray();

        MostFreqNumber();

        MostFreqNumberTwo();

        ReverseStringCharArray();

        ReverseStringForLoop();

        ReverseWirds();

        Palindromes();

        ParseUrl();
    }

    /// <summary>
    /// Create a copy of an integer array
    /// </summary>
    public static void CreateACopy()
    {
        int[] array1 = new int[10];

        int[] array2 = new int[array1.Length];

        for(int i = 0; i < array1.Length;i++)
        {
            array1[i] = i+1;
        }

        for (int i = 0; i < array1.Length; i++)
        {
            array2[i] = array1[i];
        }

        Console.WriteLine("Array1:");
        foreach (int value in array1)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Array2:");
        foreach (int value in array2)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

    public static void CreateAList()
    {
        //initalize a list to manage all user input
        List<string> list = new List<string>();
        
        var flag = true;
        while (flag)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();
            //check clear before remove so that clear function can be activated
            if (input == "--")
            {
                list.Clear();
                Console.WriteLine("List cleared.");
            }
            //add item to list if the command start with +
            else if (input.StartsWith("+"))
            {
                string item = input.Substring(2);
                list.Add(item);
            }
            //remove the item if the command start with "-" and is not "--"
            else if (input.StartsWith("-"))
            {
                string item = input.Substring(2);
                list.Remove(item);
            }
            //All other command is invalid
            else
            {
                Console.WriteLine("Invalid command.");
            }

            Console.WriteLine("List Contents:");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Do you want to continue");

            //below is to allow to get out of the loop.
            //It can be comment out if it is not necesssary
            var YesOrNo = Console.ReadLine();
            //if user enter no/No, the user can get out of the loop
            //Otherwise the loop continue which includes empty input 
            if (YesOrNo.StartsWith("n") || YesOrNo.StartsWith("N"))
            {
                flag= false;
            }
            else
            {
                continue;
            }
        }
    }

    /// <summary>
    /// Write a method that calculates all prime numbers in given range and 
    /// returns them as array of integers
    /// </summary>
    /// <param name="startNum"></param>
    /// <param name="endNum"></param>
    /// <returns></returns>
    public static int[] FindPrimesInRange(int startNum, int endNum)
    {
        //initialize a list to store all prime number 
        List<int> primes = new List<int>();

        //for loop to go through all number in between the range
        for (int i = startNum; i <= endNum; i++)
        {
            //check if the number is prime
            if (IsPrime(i))
            {
                //if so, add to list
                primes.Add(i);
            }
        }

        //return the prime list in array
        return primes.ToArray();
    }

    /// <summary>
    /// Helper function to determine if the number is Prime number or now
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool IsPrime(int num)
    {
        if (num < 2)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Write a program to read an array of n integers (space separated on a single line) and an
    ///integer k, rotate the array right k times and sum the obtained arrays after each rotation
    /// </summary>
    public static void RotatedArray()
    {
        // read input array
        Console.Write("Enter an integer array. Seperat each number by space: ");
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        // read k
        Console.Write("Enter k for how many times the array is rotated: ");
        int k = int.Parse(Console.ReadLine());

        // calculate sums
        int n = nums.Length;
        int[] sums = new int[n];
        for (int r = 1; r <= k; r++)
        {
            for (int i = 0; i < n; i++)
            {
                sums[(i + r) % n] += nums[i];
            }
        }

        // print sums
        Console.WriteLine(string.Join(" ", sums));
    }

    /// <summary>
    ///  Finds the longest sequence of equal elements in an array of integers. 
    ///  If several longest sequences exist, print the leftmost one
    /// </summary>
    public static void MostFreqNumber()
    {
        //Take user input 
        Console.WriteLine("Enter the sequence of numbers, separated by spaces:");
        int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //Use dict to store all number and its freq in this sequence array
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        int maxFrequency = 0;
        int mostFrequentNumber = 0;

        //foreach loop to iterate each number in the array
        foreach (int number in sequence)
        {
            //if the number is not in the dict, add it into the dict
            if (!frequencies.ContainsKey(number))
            {
                frequencies[number] = 0;
            }
            //increment the freq by 1
            frequencies[number]++;
            //if the current freq is bigger than the max freq
            //replace the maxfreq and mostfreqnum
            if (frequencies[number] > maxFrequency)
            {
                maxFrequency = frequencies[number];
                mostFrequentNumber = number;
            }
        }

        //Display output 
        Console.WriteLine("Output");
        for (int i = 0; i < maxFrequency; i++)
        {
            Console.Write(mostFrequentNumber + " ");
        }
    }

    /// <summary>
    /// finds the most frequent number in a given sequence of numbers.
    /// In case of multiple numbers with the same maximal frequency, 
    /// print the leftmost of them
    /// </summary>
    public static void MostFreqNumberTwo()
    {
        // Read the input numbers from the console and split them into an array
        Console.WriteLine("Enter a sequence of numbers separated by spaces:");
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Use a dictionary to keep track of the number of occurrences of each number
        Dictionary<int, int> occurrences = new Dictionary<int, int>();

        // Loop through the input numbers and count the occurrences of each number
        foreach (int number in numbers)
        {
            // If the number is not in the dictionary, add it with a count of 1
            if (!occurrences.ContainsKey(number))
            {
                occurrences[number] = 1;
            }
            // If the number is already in the dictionary, increment its count
            else
            {
                occurrences[number]++;
            }
        }

        // Find the most frequent number(s)
        int maxOccurrences = occurrences.Values.Max(); // Get the maximum number of occurrences
        List<int> mostFrequentNumbers = new List<int>(); // Create a list to hold the most frequent numbers

        foreach (int number in occurrences.Keys)
        {
            if (occurrences[number] == maxOccurrences) // If this number has the maximum number of occurrences
            {
                mostFrequentNumbers.Add(number); // Add it to the list of most frequent numbers
            }
        }

        // Print the result
        Console.Write("The number");
        if (mostFrequentNumbers.Count > 1) // If there are multiple most frequent numbers
        {
            Console.Write("s"); // Print a plural "s"
        }
        Console.Write(" ");
        for (int i = 0; i < mostFrequentNumbers.Count; i++)
        {
            Console.Write(mostFrequentNumbers[i]);
            if (i < mostFrequentNumbers.Count - 1) // If this is not the last number in the list
            {
                Console.Write(", "); // Print a comma and a space
            }
        }
        Console.WriteLine($" have the same maximal frequency (each occurs {maxOccurrences} times). The leftmost of them is {mostFrequentNumbers[0]}.");
    }

    /// <summary>
    /// reads a string from the console, reverses its letters and prints the result back at the console.
    /// Convert the string to char array, reverse it, then convert it to string again
    /// </summary>
    public static void ReverseStringCharArray()
    {
        //Take user input
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine();

        // Convert the string to a character array
        char[] charArray = str.ToCharArray();

        // Reverse the array
        Array.Reverse(charArray);

        // Convert the character array to a string
        string reversedStr = new string(charArray);

        Console.WriteLine("Reversed string: " + reversedStr);
    }

    /// <summary>
    /// reads a string from the console, reverses its letters and prints the result back at the console
    /// Print the letters of the string in back direction (from the last to the first) in a for-loop
    /// </summary>
    public static void ReverseStringForLoop()
    {
        //take user input
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine();

        Console.Write("Reversed string: ");
        // Print the characters of the string in reverse order
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
    }

    /// <summary>
    /// reverses the words in a given sentence without changing the punctuation and space
    /// </summary>
    public static void ReverseWirds()
    {
        // Read the input sentence from the console
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        // Define the word separators
        string separators = ".,:;=()&[]\"'\\/!? ";

        // Split the input sentence into words using the separators
        string[] words = input.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        // Split the input sentence into separators
        string[] separatorsArray = input.Split(words, StringSplitOptions.None);

        // Reverse the words
        Array.Reverse(words);

        // Build the output sentence by interleaving the words and separators
        string output = "";
        for (int i = 0; i < separatorsArray.Length; i++)
        {
            output += separatorsArray[i];
            if (i < words.Length)
            {
                output += words[i];
            }
        }

        // Print the output sentence
        Console.WriteLine(output);
    }

    /// <summary>
    /// Extract all palindromes from a given text
    /// </summary>
    public static void Palindromes()
    {
        Console.WriteLine("Enter a sentence: ");
        string sentence = Console.ReadLine();

        // Remove all non-alphanumeric characters and convert the sentence to lowercase
        string cleanSentence = Regex.Replace(sentence, "[^a-zA-Z0-9 ]", " ");

        // Split the clean sentence into words and find all palindromic words
        List<string> palindromicWords = new List<string>();
        string[] words = cleanSentence.Split(' ');
        
        //Foreach loop to iterate the words array
        foreach (string word in words)
        {
            if (IsPalindrome(word))
            {
                palindromicWords.Add(word);
            }
        }

        // Remove duplicates and sort the list of palindromic words
        List<string> uniquePalindromicWords = palindromicWords.Distinct().OrderBy(w => w).ToList();

        // Print the list of unique palindromic words
        Console.WriteLine(string.Join(" ", uniquePalindromicWords));
    }

    /// <summary>
    /// Helper function to find if the word is palidrome
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public static bool IsPalindrome(string word)
    {
        // Compare the first half of the string with the reversed second half
        int mid = word.Length / 2;

        for (int i = 0; i < mid; i++)
        {
            if (word[i] != word[word.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Parse URL in the given format
    /// </summary>
    public static void ParseUrl()
    {
        // Ask user to enter URL
        Console.Write("Enter URL in the format [protocol]://[server]/[resource]: ");
        string url = Console.ReadLine();

        // Initialize variables for each part of the URL
        string protocol = null;
        string server = null;
        string resource = null;

        // Find the index of the first colon (:) to determine the protocol (if any)
        int protocolIndex = url.IndexOf(':');
        if (protocolIndex != -1)
        {
            protocol = url.Substring(0, protocolIndex);
            // skip over :// separator
            url = url.Substring(protocolIndex + 3); 
        }

        // Find the index of the first slash (/) after the protocol (if any) to determine the server
        int serverIndex = url.IndexOf('/');
        if (serverIndex != -1)
        {
            server = url.Substring(0, serverIndex);
            resource = url.Substring(serverIndex);
        }
        else
        {
            server = url;
        }

        // Output the parsed parts of the URL
        Console.WriteLine("[Protocol]= " + protocol);
        Console.WriteLine("[Server]= " + server);
        Console.WriteLine("[Resource]= " + resource);

    }
}
