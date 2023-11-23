using Microsoft.Win32;
using Lab2;

namespace RegisterTest
{
    public class Tests
    {
        [TestCase("", "False", "Пустая строка в качестве логина")]
        [TestCase("u", "False", "Длина логина меньше 5 символов")]
        [TestCase("use", "False", "Длина логина меньше 5 символов")]
        [TestCase("user1", "True", "OK")]
        [TestCase("user12", "True", "OK")]
        [TestCase("user12345", "True", "OK")]
        public void TestCheckLoginLength(string login, string str2, string str3)
        {
            var expected1 = str2;
            var expected2 = str3;
            (var a, var b) = Register.CheckRegister(login, "Ф_ф_12345", "Ф_ф_12345");
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("user11", "False", "Пользователь с таким логином уже зарегистрирован")]
        [TestCase("user22", "False", "Пользователь с таким логином уже зарегистрирован")]
        [TestCase("user33", "False", "Пользователь с таким логином уже зарегистрирован")]
        [TestCase("user44", "True", "OK")]
        public void TestCheckExistUser(string login, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister(login, "Ф_ф_12345", "Ф_ф_12345");
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("+7-924-017-22-00", "False", "Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx")]
        [TestCase("+79240172200", "False", "Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx")]
        [TestCase("+7 924 017 22 00", "False", "Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx")]
        [TestCase("+7 924 017 2200", "False", "Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx")]
        [TestCase("+7-924-017-2200", "True", "OK")]
        [TestCase("Пользователь", "False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания")]
        [TestCase("Арсен_777", "False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания")]
        [TestCase("user44", "True", "OK")]
        [TestCase("userok", "True", "OK")]
        [TestCase("user@mail.ru", "True", "OK")]
        [TestCase("user@gmail.com", "True", "OK")]
        [TestCase("user@yandex.ru", "True", "OK")]
        //[TestCase("us@mail.ru", "False", "Email не удовлетворяет общему формату xxx@xxx.xxx")]
        public void TestCheckLoginContent(string phone, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister(phone, "Ф_ф_12345", "Ф_ф_12345");
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("", "False", "Пустая строка в качестве пароля")]
        [TestCase("Ф_ф_12", "False", "Длина пароля меньше 7 символов")]
        [TestCase("Ф_ф_123", "True", "OK")]
        [TestCase("Ф_ф_12345", "True", "OK")]
        public void TestCheckPasswordLength(string password, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister("user12345", password, password);
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("Ф_ф_12345", "Ф_ф_12345", "True", "OK")]
        [TestCase("Ф_ф_12345", "Ф_ф_54321", "False", "Заданные пароли не совпадают")]
        [TestCase("Ф_ф_54321", "Ф_ф_12345", "False", "Заданные пароли не совпадают")]
        public void TestCheckPasswordEquality(string password, string password2, string str1, string str2)
        {
            var expected1 = str1;
            var expected2 = str2;
            (var a, var b) = Register.CheckRegister("user12345", password, password2);
            Assert.That(a, Is.EqualTo(expected1));
            Assert.That(b, Is.EqualTo(expected2));
        }

        [TestCase("Ф_ф_12345", "True", "OK")]
        [TestCase("A_a_12345", "False", "В пароле присутствуют недопустимые символы")]
        [TestCase("ф_ф_12345", "False", "В пароле отсутствует минимум одна заглавная буква")]
        [TestCase("Ф_Ф_12345", "False", "В пароле отсутствует минимум одна строчная буква")]
        [TestCase("Ффф_Ффф_", "False", "В пароле отсутствует минимум одна цифра")]
        [TestCase("Ффф1Ффф1", "False", "В пароле отсутствует минимум один специальный символ")]
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