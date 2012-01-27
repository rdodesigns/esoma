using System;
using pulsoximeter;

class Test
{

  public static void Main()
  {
    OnyxII po = new OnyxII(true);
    //po.OpenConnection();
    for (int i = 0; i < 10; i++) {
      System.Console.WriteLine("{0}", po.GetHrAndSpo2());
    }
  }
}
