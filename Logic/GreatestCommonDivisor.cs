using System;
using System.Diagnostics;

namespace Logic
{
  /// <summary>
  /// Class consists methods to find the greatest common divisor
  /// </summary>
  public static class GreatestCommonDivisor
  {
    #region EuclidianGCD

    /// <summary>
    /// Calculating the greatest common divisor of two values by Euclidian method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>int the greatest common divisor</returns>
    public static int EuclidianGCD(int a, int b)
    {
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

      return b;
    }

    /// <summary>
    /// Calculating the greatest common divisor of three values by Euclidian method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>int the greatest common divisor</returns>
    public static int EuclidianGCD(int a, int b, int c)
    {
      return EuclidianGCD(EuclidianGCD(a, b), c);
    }

    /// <summary>
    /// Calculating the greatest common divisor of more then three values by Euclidian method
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
    /// Overloaded EuclidianGCD method returns greathest common divisor of two numbers and time
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="time"></param>
    /// <returns> GCD of two numbers and time </returns>
    public static int EuclidianGCD(out long time, int a, int b)
    {
      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();
      int result = EuclidianGCD(a, b);
      stopwatch.Stop();

      time = stopwatch.ElapsedTicks;

      return result;
    }

    /// <summary>
    /// Overloaded EuclidianGCD method returns greathest common divisor of three numbers and time
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="time"></param>
    /// <returns> GCD of three numbers and time </returns>
    public static int EuclidianGCD(out long time, int a, int b, int c)
    {
      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();
      int result = EuclidianGCD(a, b, c);
      stopwatch.Stop();

      time = stopwatch.ElapsedTicks;

      return result;
    }

    /// <summary>
    /// Overloaded EuclidianGCD method returns greathest common divisor of more than three numbers and time
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="time"></param>
    /// <returns> GCD of more than three numbers and time </returns>
    public static int EuclidianGCD(out long time, int a, int b, params int[] arr)
    {
      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();
      int result = EuclidianGCD(a, b, arr);
      stopwatch.Stop();

      time = stopwatch.ElapsedTicks;

      return result;
    }
    #endregion

    #region ShteinGCD
    /// <summary>
    /// Calculating the greatest common divisor of two values by Stain method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> int the greatest common divisor of two values  </returns>
    public static int ShteinGCD(int a, int b)
    {
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

      if ((~a & 1) != 0)
      {
        if ((b & 1) != 0)
        {
          return ShteinGCD(a >> 1, b);
        }
        else
        {
          return ShteinGCD(a >> 1, b >> 1) << 1;
        }
      }

      if ((~b & 1) != 0)
      {
        return ShteinGCD(a, b >> 1);
      }

      if (a > b)
      {
        return ShteinGCD((a - b) >> 1, b);
      }
      else
      {
        return ShteinGCD(a, (b - a) >> 1);
      }
    }

    /// <summary>
    /// Calculating the greatest common divisor of three values by Stain method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> int the greatest common divisor of three values </returns>
    public static int ShteinGCD(int a, int b, int c)
    {
      return ShteinGCD(ShteinGCD(a, b), c);
    }

    /// <summary>
    /// Calculating the greatest common divisor of more then two values by Stain method
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> int the greatest common divisor </returns>
    public static int ShteinGCD(int a, int b, params int[] arr)
    {
      var result = ShteinGCD(a, b);

      if (arr == null)
      {
        return result;
      }

      foreach (var item in arr)
      {
        result = ShteinGCD(result, item);
      }
      return result;
    }

    /// <summary>
    /// Overloaded ShteinGCD method returns greathest common divisor of two numbers and time
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="time"></param>
    /// <returns> GCD of two numbers and time </returns>
    public static int ShteinGCD(out long time, int a, int b)
    {
      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();
      int result = ShteinGCD(a, b);
      stopwatch.Stop();

      time = stopwatch.ElapsedTicks;

      return result;
    }

    /// <summary>
    /// Overloaded ShteinGCD method returns greathest common divisor of three numbers and time
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="time"></param>
    /// <returns> GCD of three numbers and time </returns>
    public static int ShteinGCD(out long time, int a, int b, int c)
    {
      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();
      int result = ShteinGCD(a, b, c);
      stopwatch.Stop();

      time = stopwatch.ElapsedTicks;

      return result;
    }

    /// <summary>
    /// Overloaded ShteinGCD method returns greathest common divisor of more than three numbers and time
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="time"></param>
    /// <returns> GCD of more than three numbers and time </returns>
    public static int ShteinGCD(out long time, int a, int b, params int[] arr)
    {
      Stopwatch stopwatch = new Stopwatch();

      stopwatch.Start();
      int result = ShteinGCD(a, b, arr);
      stopwatch.Stop();

      time = stopwatch.ElapsedTicks;

      return result;
    } 
    #endregion

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
