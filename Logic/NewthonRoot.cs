using System;

namespace Logic
{
  /// <summary>
  /// Class of calculation roots
  /// </summary>
  public static class NewthonRoot
  {
    /// <summary>
    /// Get root of the value calculated by Newton method
    /// </summary>
    /// <param name="value"></param>
    /// <param name="power"></param>
    /// <param name="acuracy"></param>
    /// <returns> Root of the value </returns>
    public static double Root(double value, int power, double acuracy = 0.001) 
    {
      double currentValue = value;
      double previousValue;

      if (value == 0)
      {
        return 0;
      }

      do
      {
        previousValue = currentValue;
        currentValue = ((double)1 / power) * ((power - 1) * previousValue + value / Power(previousValue, power - 1));
      } while (Module(currentValue - previousValue) > acuracy);

      return currentValue;
    }

    #region Private Methods

    /// <summary>
    /// Get power of the value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="power"></param>
    /// <returns> Value power </returns>
    private static double Power(double value, int power)
    {
      double result = 1;

      for (int i = 1; i <= power; i++)
      {
        result *= value;
      }

      return result;
    }

    /// <summary>
    /// Get absolute value of the number
    /// </summary>
    /// <param name="value"></param>
    /// <returns> Absolute value </returns>
    private static double Module(double value)
    {
      if (value < 0)
      {
        return -value;
      }
      else
      {
        return value;
      }
    } 

    #endregion
  }
}
