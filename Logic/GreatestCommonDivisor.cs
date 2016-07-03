using System;
using System.Diagnostics;

namespace Logic
{
  /// <summary>
  /// Class consists methods to find the greatest common divisor
  /// </summary>
  public static class GreatestCommonDivisor
  {
    private static Stopwatch stopwatch;

    /// <summary>
    /// Calculating time
    /// </summary>
    public static TimeSpan Time
    {
      get
      {
        return stopwatch.Elapsed;
      }
    }

    static GreatestCommonDivisor()
    {
      stopwatch = new Stopwatch();
    }

    /// <summary>
    /// Calculating the greatest common divisor by Euclidian method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>int the greatest common divisor</returns>
    public static int EuclidianGCD(int a, int b)
    {
      stopwatch.Start();

      int rest = 0;
      a = Math.Abs(a);
      b = Math.Abs(b);

      if (a == 0 || b == 0)
      {
        return 0;
      }

      if (a < b)
      {
        int temp = a;
        a = b;
        b = temp;
      }

      while ((rest = Division(a, b)) != 0)
      {
        a = b;
        b = rest;
      }

      stopwatch.Stop();

      return b;
    }

    /// <summary>
    /// Method calculates minimal remainder of the division
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static int Division(int a, int b)
    {
      while (a >= b)
      {
        a = a - b;
      }

      return a;
    }
  }
}
