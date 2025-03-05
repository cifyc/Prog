using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
class Автостоянка
{
    private Dictionary<int, string> місця;
    private int місткість;
    public Автостоянка(int місткість)
    {
        this.місткість = місткість;
        місця = new Dictionary<int, string>();
        for (int i = 1; i <= місткість; i++)
        {
            місця[i] = null;
        }
    }
    public void ДодатиМашину(string номер, int позиція)
    {
        for (int i = позиція; i <= місткість; i++)
        {
            if (місця[i] == null)
            {
                місця[i] = номер;
                Console.WriteLine($"Машина {номер} припаркована на місце {i}");
                break;
            }
        }
    }
    public void ВидалитиМашину(string номер)
    {
        foreach (var ключ in місця.Keys.ToList())
        {
            if (місця[ключ] == номер)
            {
                місця[ключ] = null;
                Console.WriteLine($"Машина {номер} виїхала з місця {ключ}");
                break;
            }
        }
    }
    public void ЗберегтиУJson(string файл)
    {
        File.WriteAllText(файл, JsonSerializer.Serialize(місця));
        Console.WriteLine("Стан автостоянки збережено у файл " + файл);
    }
    public void ВивестиСтан()
    {
        Console.WriteLine("Поточний стан автостоянки:");
        foreach (var м in місця)
        {
            Console.WriteLine($"Місце {м.Key}: {(м.Value ?? "Вільно")}");
        }
    }
}

class Програма
{
    static void Main()
    {
        Автостоянка стоянка = new Автостоянка(5);
        стоянка.ДодатиМашину("АА1234", 2);
        стоянка.ДодатиМашину("BB5678", 1);
        стоянка.ДодатиМашину("CC9012", 3);

        стоянка.ЗберегтиУJson("стоянка.json");
        стоянка.ВивестиСтан();

        List<int> числа = new List<int> { 2, 5, 7, 10, 15, 18, 20, 6 };
        double середнє = числа.Where(n => n >= 5 && n <= 15).Average();
        Console.WriteLine($"Середнє арифметичне чисел у діапазоні [5,15]: {середнє}");
    }
}
