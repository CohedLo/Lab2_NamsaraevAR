using Lab2;
using NUnit.Framework;
using System;
using System.IO;

namespace TriangleCalculator.Tests
{
    [TestFixture]
    public class TriangleCalculatorTests
    {
        private StringWriter consoleOutput;
        private StringReader consoleInput;

        [SetUp]
        public void Setup()
        {
            consoleOutput = new StringWriter();
            consoleInput = new StringReader("");
            Console.SetOut(consoleOutput);
            Console.SetIn(consoleInput);
        }

        [TearDown]
        public void TearDown()
        {
            consoleOutput.Dispose();
            consoleInput.Dispose();
        }

        [Test]
        public void CalculateTriangle_ValidInput_SuccessfulCalculation()
        {
            consoleInput = new StringReader("3,4,5\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("Треугольник: разносторонний"));
            Assert.IsTrue(output.Contains("Координаты вершин: (0, 100), (200, 100), (100, 0)"));
        }

        [Test]
        public void CalculateTriangle_InvalidInput_LogsError()
        {
            consoleInput = new StringReader("1,2\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("Некорректный ввод. Введите длины трех сторон через запятую."));
            Assert.IsFalse(output.Contains("Треугольник:"));
        }

        [Test]
        public void CalculateTriangle_ZeroSide_LogsError()
        {
            consoleInput = new StringReader("0,2,3\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("Ошибка: Входные данные не являются вещественными положительными числами"));
            Assert.IsTrue(output.Contains("Треугольник: не треугольник"));
        }

        [Test]
        public void CalculateTriangle_NegativeSide_LogsError()
        {
            consoleInput = new StringReader("-1,2,3\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("Ошибка: Входные данные не являются вещественными положительными числами"));
            Assert.IsTrue(output.Contains("Треугольник: не треугольник"));
        }

        [Test]
        public void CalculateTriangle_Equilateral_SuccessfulCalculation()
        {
            consoleInput = new StringReader("5,5,5\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("Треугольник: равносторонний"));
            Assert.IsTrue(output.Contains("Координаты вершин: (0, 100), (200, 100), (100, 0)"));
        }

        // Добавьте аналогичные тесты для других сценариев (равнобедренный, разносторонний, и т.д.)
    }
}