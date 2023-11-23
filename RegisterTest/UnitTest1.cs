using Microsoft.Win32;
using Lab2;

namespace RegisterTest
{
    public class Tests
    {
        [TestCase("", "False", "������ ������ � �������� ������")]
        [TestCase("u", "False", "����� ������ ������ 5 ��������")]
        [TestCase("use", "False", "����� ������ ������ 5 ��������")]
        [TestCase("user1", "True", "OK")]
        [TestCase("user12", "True", "OK")]
        [TestCase("user12345", "True", "OK")]
        public void TestCheckLoginLength(string login, string str2, string str3)
        {
            var expected1 = str2;
            var expected2 = str3;
            (var a, var b) = Register.CheckRegister(login, "�_�_12345", "�_�_12345");
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("user11", "False", "������������ � ����� ������� ��� ���������������")]
        [TestCase("user22", "False", "������������ � ����� ������� ��� ���������������")]
        [TestCase("user33", "False", "������������ � ����� ������� ��� ���������������")]
        [TestCase("user44", "True", "OK")]
        public void TestCheckExistUser(string login, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister(login, "�_�_12345", "�_�_12345");
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("+7-924-017-22-00", "False", "����� �������� �� ������������� ��������� ������� +x-xxx-xxx-xxxx")]
        [TestCase("+79240172200", "False", "����� �������� �� ������������� ��������� ������� +x-xxx-xxx-xxxx")]
        [TestCase("+7 924 017 22 00", "False", "����� �������� �� ������������� ��������� ������� +x-xxx-xxx-xxxx")]
        [TestCase("+7 924 017 2200", "False", "����� �������� �� ������������� ��������� ������� +x-xxx-xxx-xxxx")]
        [TestCase("+7-924-017-2200", "True", "OK")]
        [TestCase("������������", "False", "����� �������� �������, �������� �� ��������, ���� � ����� �������������")]
        [TestCase("�����_777", "False", "����� �������� �������, �������� �� ��������, ���� � ����� �������������")]
        [TestCase("user44", "True", "OK")]
        [TestCase("userok", "True", "OK")]
        [TestCase("user@mail.ru", "True", "OK")]
        [TestCase("user@gmail.com", "True", "OK")]
        [TestCase("user@yandex.ru", "True", "OK")]
        //[TestCase("us@mail.ru", "False", "Email �� ������������� ������ ������� xxx@xxx.xxx")]
        public void TestCheckLoginContent(string phone, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister(phone, "�_�_12345", "�_�_12345");
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("", "False", "������ ������ � �������� ������")]
        [TestCase("�_�_12", "False", "����� ������ ������ 7 ��������")]
        [TestCase("�_�_123", "True", "OK")]
        [TestCase("�_�_12345", "True", "OK")]
        public void TestCheckPasswordLength(string password, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister("user12345", password, password);
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("�_�_12345", "�_�_12345", "True", "OK")]
        [TestCase("�_�_12345", "�_�_54321", "False", "�������� ������ �� ���������")]
        [TestCase("�_�_54321", "�_�_12345", "False", "�������� ������ �� ���������")]
        public void TestCheckPasswordEquality(string password, string password2, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister("user12345", password, password2);
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("�_�_12345", "True", "OK")]
        [TestCase("A_a_12345", "False", "� ������ ������������ ������������ �������")]
        [TestCase("�_�_12345", "False", "� ������ ����������� ������� ���� ��������� �����")]
        [TestCase("�_�_12345", "False", "� ������ ����������� ������� ���� �������� �����")]
        [TestCase("���_���_", "False", "� ������ ����������� ������� ���� �����")]
        [TestCase("���1���1", "False", "� ������ ����������� ������� ���� ����������� ������")]
        public void TestCheckPasswordContent(string password, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister("user12345", password, password);
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }
    }
}