using Examples;
using NUnit.Framework;
using System.Collections;

namespace ExamplesTests
{
   [TestFixture]
   public class ClampTest
   {
      /// <summary>
      /// Simple test of double clamp
      /// </summary>
      [Test]
      public void WhenValueIsWithinRange_ThenDoNotClampValue()
      {
         var value = 123;
         var clampedValue = Utility.Clamp(value);
         Assert.AreEqual(value, clampedValue);
      }

      /// <summary>
      /// Simple test of double clamp
      /// </summary>
      [Test]
      public void WhenValueIsLessThanMinimum_ThenClampValueToMinimum()
      {
         var value = -2000;
         var clampedValue = Utility.Clamp(value);
         Assert.AreEqual(Utility.Min, clampedValue);
      }

      /// <summary>
      /// Simple test of double clamp
      /// </summary>
      [Test]
      public void WhenValueIsGreaterThanMaximum_ThenClampValueToMaximum()
      {
         var value = 2000;
         var clampedValue = Utility.Clamp(value);
         Assert.AreEqual(Utility.Max, clampedValue);
      }

      /// <summary>
      /// Run a series of test cases with defined input and output
      /// </summary>
      /// <param name="value">The test case input input parameter</param>
      /// <returns>The clamped input value</returns>
      [TestCase(-2000, ExpectedResult = -1000)]
      [TestCase(-1001, ExpectedResult = -1000)]
      [TestCase(-1000, ExpectedResult = -1000)]
      [TestCase(-999, ExpectedResult = -999)]
      [TestCase(0, ExpectedResult = 0)]
      [TestCase(999, ExpectedResult = 999)]
      [TestCase(1000, ExpectedResult = 1000)]
      [TestCase(1001, ExpectedResult = 1000)]
      [TestCase(2000, ExpectedResult = 1000)]
      public double WhenClampIsCalled_ValuesAreClampedToValidRange(double value)
      {
         return Utility.Clamp(value);
      }

      /// <summary>
      /// Simple test of Point3D clamp
      /// </summary>
      [Test]
      public void WhenPoint3DValueIsWithinRange_ThenDoNotClampValue()
      {
         var value = new Point3D(1, 2, 3);
         var clampedValue = Utility.Clamp(value);
         Assert.AreEqual(value, clampedValue);
      }

      /// <summary>
      /// Combinatorial tests - all combinations of inputs are tried, expected outputs are not provided, so asserts used
      /// </summary>
      /// <param name="x">X-coord of Point3D</param>
      /// <param name="y">Y-coord of Point3D</param>
      /// <param name="z">Z-coord of Point3D</param>
      [Test, Combinatorial]
      public void WhenPoint3DValueIsNotInValidRange_ThenClampValue_ForAllCombinations(
         [Values(-1001, -1000, -999, 999, 1000, 1001)] double x,
         [Values(-1001, -1000, -999, 999, 1000, 1001)] double y,
         [Values(-1001, -1000, -999, 999, 1000, 1001)] double z)
      {
         var value = new Point3D(x, y, z);
         var clampedValue = Utility.Clamp(value);
         Assert.IsTrue(Utility.Min <= clampedValue.X && clampedValue.X <= Utility.Max);
         Assert.IsTrue(Utility.Min <= clampedValue.Y && clampedValue.Y <= Utility.Max);
         Assert.IsTrue(Utility.Min <= clampedValue.Z && clampedValue.Z <= Utility.Max);
      }

      /// <summary>
      /// Data source for test cases - values chosen to cover a variety of cases
      /// </summary>
      private class Point3DList
      {
         public static IEnumerable TestCases
         {
            get
            {
               yield return new TestCaseData(new Point3D(0, 0, 0)).Returns(new Point3D(0, 0, 0));
               yield return new TestCaseData(new Point3D(1, 0, 0)).Returns(new Point3D(1, 0, 0));
               yield return new TestCaseData(new Point3D(-999, -1001, 0)).Returns(new Point3D(-999, Utility.Min, 0));
               yield return new TestCaseData(new Point3D(1001, 999, 2000)).Returns(new Point3D(Utility.Max, 999, Utility.Max));
            }
         }
      }

      /// <summary>
      /// Test clamping of Point3D using the Point3DList data source
      /// </summary>
      /// <param name="point">The input point to test</param>
      /// <returns>The clamped input value</returns>
      [Test, TestCaseSource(typeof(Point3DList), "TestCases")]
      public Point3D WhenPoint3DValueIsNotInValidRange_ThenClampValue(Point3D point)
      {
         return Utility.Clamp(point);
      }
   }
}
