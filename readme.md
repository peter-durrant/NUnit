# NUnit Examples

This code uses NUnit. See the [NUnit](http://www.nunit.org/).

## Functionality

The Example project defines a `Utility` class that defines methods to clamp `double` values and `Point3D` to a specified range.

The `Point3D` is a simple representation of a point in 3D space.

## Tests

The tests are found in the `ClampTest` class in the `ExampleTests` project. All tests follow the "arrange -> act -> assert" pattern.

### Simple Test

A simple test is marked up using the `[Test]` attribute.

### TestCase

`[TestCase]` attributes are listed before the exercising function implementation. The `[TestCase]` can be supplied with input values only or with the expected return value `ExpectedResult`.

```c#
[TestCase(1, ExpectedResult = 2)]
[TestCase(2, ExpectedResult = 4)]
public double DoubleTheInputValue(double value)
{
   return 2 * value;
}
```

### Combinatorial

`[Test, Combinatorial]` attributes enable a test function to try all combinations of inputs.

```c#
[Test, Combinatorial]
public void LessThan(
	[Values(1, 2, 3, 4, 5)] int smallValue,
	[Values(10, 20, 30, 40, 50)] int bigValue)
{
   Assert.IsTrue(smallValue < bigValue);
}
```

### TestCaseSource

The `[Test, TestCaseSource]` attribute references a list of test cases that can exercise some functionality and check the expected result.

```c#
private class DataList
{
   public static IEnumerable TestCases
   {
      get
      {
         yield return new TestCaseData(1, 10).Returns(true);
         yield return new TestCaseData(2, 20).Returns(true);
         yield return new TestCaseData(3, 30).Returns(true);
         yield return new TestCaseData(10, 1).Returns(false);
         yield return new TestCaseData(20, 2).Returns(false);
         yield return new TestCaseData(30, 3).Returns(false);
      }
   }
}

[Test, TestCaseSource(typeof(DataList), "TestCases")]
public bool LessThan(int smallValue, int bigValue)
{
   return smallValue < bigValue;
}
```
