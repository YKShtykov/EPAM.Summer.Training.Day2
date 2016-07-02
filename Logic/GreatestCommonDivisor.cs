using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Logic
{
  public static class GreatestCommonDivisor
  {
    private static Stopwatch stopwatch;

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
