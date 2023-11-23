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
            Assert.IsTrue(output.Contains("�����������: ��������������"));
            Assert.IsTrue(output.Contains("���������� ������: (0, 100), (200, 100), (100, 0)"));
        }

        [Test]
        public void CalculateTriangle_InvalidInput_LogsError()
        {
            consoleInput = new StringReader("1,2\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("������������ ����. ������� ����� ���� ������ ����� �������."));
            Assert.IsFalse(output.Contains("�����������:"));
        }

        [Test]
        public void CalculateTriangle_ZeroSide_LogsError()
        {
            consoleInput = new StringReader("0,2,3\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("������: ������� ������ �� �������� ������������� �������������� �������"));
            Assert.IsTrue(output.Contains("�����������: �� �����������"));
        }

        [Test]
        public void CalculateTriangle_NegativeSide_LogsError()
        {
            consoleInput = new StringReader("-1,2,3\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("������: ������� ������ �� �������� ������������� �������������� �������"));
            Assert.IsTrue(output.Contains("�����������: �� �����������"));
        }

        [Test]
        public void CalculateTriangle_Equilateral_SuccessfulCalculation()
        {
            consoleInput = new StringReader("5,5,5\n");
            Console.SetIn(consoleInput);

            TriangleCalculator.Main();

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("�����������: ��������������"));
            Assert.IsTrue(output.Contains("���������� ������: (0, 100), (200, 100), (100, 0)"));
        }

        // �������� ����������� ����� ��� ������ ��������� (��������������, ��������������, � �.�.)
    }
}