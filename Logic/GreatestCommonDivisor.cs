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
    private static bool flag;

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
      flag = true;
    }

    /// <summary>
    /// Calculating the greatest common divisor of two values by Euclidian method
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

      if (a == b)
      {
        return a;
      }
      if (a == 0)
      {
        return b;
      }
      if (b == 0)
      {
        return a;
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
    /// Calculating the greatest common divisor of more then two values by Euclidian method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="arr"></param>
    /// <returns> int the greatest common divisor </returns>
    public static int EuclidianGCD(int a, int b, params int[] arr)
    {
      var result = EuclidianGCD(a, b);

      if (arr == null)
      {
        return result;
      }

      foreach (var item in arr)
      {
        result = EuclidianGCD(result, item);
      }

      return result;
    }

    /// <summary>
    /// Calculating the greatest common divisor of two values by Stain method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> int the greatest common divisor </returns>
    public static int StainGCD(int a, int b)
    {
      if (flag)
      {
        stopwatch.Start();
        flag = false;
      }
      if (a == b)
      {
        flag = true;
        stopwatch.Stop();
        return a;
      }

      if (a == 0)
      {
        return b;
      }

      if (b == 0)
      {
        return a;
      }

      if ((~a & 1) != 0)
      {
        if ((b & 1) != 0)
        {
          return StainGCD(a >> 1, b);
        }
        else
        {
          return StainGCD(a >> 1, b >> 1) << 1;
        }
      }

      if ((~b & 1) != 0)
      {
        return StainGCD(a, b >> 1);
      }

      if (a > b)
      {
        return StainGCD((a - b) >> 1, b);
      }
      else
      {
        return StainGCD(a, (b - a) >> 1);
      }
    }
    /// <summary>
    /// Calculating the greatest common divisor of more then two values by Stain method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> int the greatest common divisor </returns>
    public static int StainGCD(int a, int b, params int[] arr)
    {
      var result = StainGCD(a, b);

      if (arr == null)
      {
        return result;
      }

      foreach (var item in arr)
      {
        result = StainGCD(result, item);
      }
      return result;
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
