using Lab2;
using Serilog;

string template = "{Timestamp:HH:mm:ss} | [{Level:u3}] | {Message:lj}{NewLine}{Exception}";
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(outputTemplate: template)
    .WriteTo.File("logs/file_.txt", outputTemplate: template)
    .CreateLogger();

Log.Verbose("Логгер сконфигурирован");
Log.Information("Приложение запущено");

(var s, var d) = Triangle.GetTriangleData("-1", "2", "2");

Log.CloseAndFlush();

(string a, string b) = Register.CheckRegister("user@mail.com", "Ф_ф_12345", "Ф_ф_12345");

Console.WriteLine(a);
Console.WriteLine(b);