namespace Examples
{
   /// <summary>
   /// Represent a point in 3D space
   /// </summary>
   public class Point3D
   {
      public Point3D(double x, double y, double z)
      {
         X = x;
         Y = y;
         Z = z;
      }

      public double X { get; private set; }
      public double Y { get; private set; }
      public double Z { get; private set; }

      public override bool Equals(object obj)
      {
         if (obj == null || GetType() != obj.GetType())
         {
            return false;
         }
         var point = (Point3D)obj;
         return X == point.X && Y == point.Y && Z == point.Z;
      }

      public override int GetHashCode()
      {
         int hash = 0;
         hash += (hash * 397) ^ X.GetHashCode();
         hash += (hash * 397) ^ Y.GetHashCode();
         hash += (hash * 397) ^ Z.GetHashCode();
         return hash;
      }

      public override string ToString()
      {
         return string.Format("({0},{1},{2})", X, Y, Z);
      }
   }
}
