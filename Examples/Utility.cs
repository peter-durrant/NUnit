namespace Examples
{
   /// <summary>
   /// Utility functions
   /// </summary>
   public static class Utility
   {
      public static double Min = -1000;
      public static double Max = 1000;

      public static double Clamp(double value)
      {
         if (value < Min) return Min;
         if (value > Max) return Max;
         return value;
      }

      public static Point3D Clamp(Point3D point)
      {
         return new Point3D(Clamp(point.X), Clamp(point.Y), Clamp(point.Z));
      }
   }
}
