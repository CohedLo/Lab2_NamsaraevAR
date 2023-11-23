using Serilog;

namespace Lab2
{
    public class Triangle
    {
        public static (string, List<(int, int)>) GetTriangleData(string sideA, string sideB, string sideC)
        {
            bool res1 = float.TryParse(sideA, out float a);
            bool res2 = float.TryParse(sideB, out float b);
            bool res3 = float.TryParse(sideC, out float c);

            if (res1 && res2 && res3)
            {
                string triangleType = CalculateTriangleType(a, b, c);

                if (triangleType == "не треугольник")
                {
                    Log.Error("Ошибка: Входные данные не являются вещественными положительными числами");

                    return ("не треугольник", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
                }
                else if (triangleType == "")
                {
                    Log.Error("Ошибка: Входные данные не являются вещественными положительными числами");

                    return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
                }
                else
                {
                    List<(int, int)> vertexCoordinates = CalculateVertexCoordinates(a, b, c);

                    Log.Information("Успешный запрос: Тип треугольника: {type}, Координаты вершин: {@vertices}", triangleType, vertexCoordinates);

                    return (triangleType, vertexCoordinates);
                }
            }
            else
            {
                Log.Error("Ошибка: Входные данные не являются вещественными положительными числами");

                return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
            }
        }

        private static string CalculateTriangleType(float sideA, float sideB, float sideC)
        {
            if (sideA < 0 || sideB < 0 || sideC < 0)
            {
                return "";
            }
            else if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                return "не треугольник";
            }
            else if (sideA == sideB & sideB != sideC || sideB == sideC & sideC != sideA || sideA == sideC & sideC != sideB)
            {
                return "равнобедренный";
            }
            else if (sideA == sideB & sideB == sideC)
            {
                return "равносторонний";
            }
            else
            {
                return "разносторонний";
            }
        }

        private static List<(int, int)> CalculateVertexCoordinates(float sideA, float sideB, float sideC)
        {
            // Алгоритм:
            // Первая координата A в точке - (xA = 0, yA = 0),
            // Вторая координата B на оси X в точке - (xB, yB = 0),
            // Третья координата C вычисляется по сомнительной формуле из интернета - (xC, yC);

            // A (угол между b и c)
            var xA = 0;
            var yA = 0;

            // B (угол между a и c)
            var xB = (int)sideA;
            var yB = 0;

            // C (угол между a и b)
            var cosA = (sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideB * sideC);
            var xC = (int)(sideB * cosA);
            var yC = (int)(sideB * Math.Sqrt(1 - cosA * cosA));

            double scaleFactor = 100.0 / Math.Max(sideA, Math.Max(sideB, sideC));
            xA = (int)Math.Round(xA * scaleFactor);
            yA = (int)Math.Round(yA * scaleFactor);
            xB = (int)Math.Round(xB * scaleFactor);
            yB = (int)Math.Round(yB * scaleFactor);
            xC = (int)Math.Round(xC * scaleFactor);
            yC = (int)Math.Round(yC * scaleFactor);

            return new List<(int, int)> { (xA, yA), (xB, yB), (xC, yC) };
        }
    }
}
