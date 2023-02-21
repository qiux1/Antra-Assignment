using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Question 1:");
        Console.WriteLine("sbyte: {0} bytes, range {1} to {2}", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        Console.WriteLine("byte: {0} bytes, range {1} to {2}", sizeof(byte), byte.MinValue, byte.MaxValue);
        Console.WriteLine("short: {0} bytes, range {1} to {2}", sizeof(short), short.MinValue, short.MaxValue);
        Console.WriteLine("ushort: {0} bytes, range {1} to {2}", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        Console.WriteLine("int: {0} bytes, range {1} to {2}", sizeof(int), int.MinValue, int.MaxValue);
        Console.WriteLine("uint: {0} bytes, range {1} to {2}", sizeof(uint), uint.MinValue, uint.MaxValue);
        Console.WriteLine("long: {0} bytes, range {1} to {2}", sizeof(long), long.MinValue, long.MaxValue);
        Console.WriteLine("ulong: {0} bytes, range {1} to {2}", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        Console.WriteLine("float: {0} bytes, range {1} to {2}", sizeof(float), float.MinValue, float.MaxValue);
        Console.WriteLine("double: {0} bytes, range {1} to {2}", sizeof(double), double.MinValue, double.MaxValue);
        Console.WriteLine("decimal: {0} bytes, range {1} to {2}", sizeof(decimal), decimal.MinValue, decimal.MaxValue);


        Console.WriteLine("Question 2:");
        const long yearsInCentury = 100;
        const long daysInYear = 365;
        const long hoursInDay = 24;
        const long minutesInHour = 60;
        const long secondsInMinute = 60;
        const long millisecondsInSecond = 1000;
        const long microsecondsInMillisecond = 1000;
        const long nanosecondsInMicrosecond = 1000;

        Console.Write("Enter the number of centuries: ");
        int centuries = int.Parse(Console.ReadLine());

        long years = centuries * yearsInCentury;
        long days = years * daysInYear;
        long hours = days * hoursInDay;
        long minutes = hours * minutesInHour;
        long seconds = minutes * secondsInMinute;
        long milliseconds = seconds * millisecondsInSecond;
        long microseconds = milliseconds * microsecondsInMillisecond;
        ulong nanoseconds = (ulong)(microseconds * nanosecondsInMicrosecond);

        Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",
                          centuries, years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds);

    }
}