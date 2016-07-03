using System;
using Logic;

namespace CUI
{
  class Program
  {
    static void Main(string[] args)
    {
      double value = 19;
      int power = 3;

      var x = NewthonRoot.Root(value, power);
      var y = Math.Pow(value, 1.0 / power);

      Console.WriteLine("Value :  {0};    Power :  {1};", value, power);
      Console.WriteLine("Newton method result : {0}", x);
      Console.WriteLine("Math power result : {0}", y);
      Console.WriteLine();

      int a = 18;
      int b = 144;
      int[] c = { 264, 543, 22, 76, 44, 90, 67, 46, 78 };

      Console.WriteLine("Value 1 :  {0};   Value 2 :  {1};", a, b);
      Console.WriteLine("Greatest common divisor (Euclidian method) : {0}", GreatestCommonDivisor.EuclidianGCD(a, b, c));
      Console.WriteLine("time : {0}", GreatestCommonDivisor.Time);
      Console.ReadKey();
    }
  }
}
