using Lab2;

namespace TriangleTest
{
    public class Tests
    {
        [TestCase("0", "1", "1")]
        [TestCase("1", "0", "1")]
        [TestCase("1", "1", "0")]
        [TestCase("2", "1", "1")]
        [TestCase("1", "2", "1")]
        [TestCase("1", "1", "2")]
        public void TestCheckNotaTriangle(string a, string b, string c)
        {
            var expectedType = "не треугольник";
            var expectedList = new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) };
            (var s, var d) = Triangle.GetTriangleData(a, b, c);
            Assert.That(s, Is.EqualTo(expectedType));
            CollectionAssert.AreEquivalent(expectedList, d);
        }

        [TestCase("a", "1", "1")]
        [TestCase("1", "b", "1")]
        [TestCase("1", "1", "c")]
        [TestCase("", "1", "1")]
        [TestCase("1", "", "1")]
        [TestCase("1", "1", "")]
        [TestCase(" ", "1", "1")]
        [TestCase("1", " ", "1")]
        [TestCase("1", "1", " ")]
        [TestCase("-1", "1", "1")]
        [TestCase("1", "-1", "1")]
        [TestCase("1", "1", "-1")]
        public void TestCheckNotValid(string a, string b, string c)
        {
            var expectedType = "";
            var expectedList = new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) };
            (var s, var d) = Triangle.GetTriangleData(a, b, c);
            Assert.That(s, Is.EqualTo(expectedType));
            CollectionAssert.AreEquivalent(expectedList, d);
        }

        [TestCase("1", "1", "1")]
        [TestCase("100", "100", "100")]
        [TestCase("101", "101", "101")]
        public void TestCheckEquilateral(string a, string b, string c)
        {
            var expectedType = "равносторонний";
            //var expectedList = new List<(int, int)> { (0, 0), (100, 0), (50, 0) };
            (var s, var d) = Triangle.GetTriangleData(a, b, c);
            Assert.That(s, Is.EqualTo(expectedType));
            //CollectionAssert.AreEquivalent(expectedList, d);
        }

        [TestCase("1", "2", "2")]
        [TestCase("2", "1", "2")]
        [TestCase("2", "2", "1")]
        public void TestCheckIsosceles(string a, string b, string c)
        {
            var expectedType = "равнобедренный";
            //var expectedList = new List<(int, int)> { (0, 0), (100, 0), (50, 0) };
            (var s, var d) = Triangle.GetTriangleData(a, b, c);
            Assert.That(s, Is.EqualTo(expectedType));
            //CollectionAssert.AreEquivalent(expectedList, d);
        }

        [TestCase("4", "5", "6")]
        [TestCase("5", "4", "6")]
        [TestCase("4", "6", "5")]
        public void TestCheckScalene(string a, string b, string c)
        {
            var expectedType = "разносторонний";
            //var expectedList = new List<(int, int)> { (0, 0), (100, 0), (50, 0) };
            (var s, var d) = Triangle.GetTriangleData(a, b, c);
            Assert.That(s, Is.EqualTo(expectedType));
            //CollectionAssert.AreEquivalent(expectedList, d);
        }
    }
}