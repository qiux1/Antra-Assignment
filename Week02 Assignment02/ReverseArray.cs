using System;

class ReverseArray
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Enter the Length of the array: ");
        var n = Convert.ToInt32(Console.ReadLine());
        // Generate an array of numbers and store it in the "numbers" variable
        int[] numbers = GenerateNumbers(n);

        // Reverse the contents of the "numbers" array
        Reverse(numbers);

        // Print the contents of the "numbers" array
        PrintNumbers(numbers);
    }

    // Method to create an array of numbers
    public static int[] GenerateNumbers(int length)
    {
        // Create a new integer array of size "length"
        int[] numbers = new int[length];

        // Loop through each index of the array and set its value to the index plus 1
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1;
        }

        // Return the completed array
        return numbers;
    }

    // Method to reverse the contents of an array
    public static void Reverse(int[] array)
    {
        // Loop through the first half of the array
        for (int i = 0; i < array.Length / 2; i++)
        {
            // Swap the values at index i and index array.Length - i - 1
            int temp = array[i];
            array[i] = array[array.Length - i - 1];
            array[array.Length - i - 1] = temp;
        }
    }

    // Method to print the contents of an array
    public static void PrintNumbers(int[] array)
    {
        // Loop through each number in the array and print it to the console
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        // Add a new line to the console output for clarity
        Console.WriteLine();
    }
}