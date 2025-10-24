
using SharpKnP321.Library;

Library library = new();
library.PrintCatalog();

Console.WriteLine("\n--------Periodic-----------");
library.PrintPeriodic();

Console.WriteLine("\n--------NonPeriodic-----------");
library.PrintNonPeriodic();

Console.WriteLine("-------------------");


void Intro()
{
    int[] arr = new int[10];
    foreach (int el in arr)
    {
        Console.WriteLine(el);
    }
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine(arr[i]);
    }
    arr[0] = default;
    int[][] arr2 = new int[5][];   // jagged - "рвані" масиви
    for (int i = 0; i < 5; i += 1)
    {
        arr2[i] = new int[i + 1];
    }
    foreach (int[] el in arr2)
    {
        foreach (int w in el)
        {
            Console.Write(w + " ");
        }
        Console.WriteLine();
    }
    int[,] arr3 = new int[3, 4];
    for (int i = 0; i < 3; ++i)
    {
        for (int j = 0; j < 4; ++j)
        {
            Console.Write(arr3[i, j]);
        }
        Console.WriteLine();
    }
    String[] strings = { "s1", "s2" };
    String[] s2 = ["s1", "s2"];

    return;

    Console.Write("Enter your name: ");    // Виведення без переводу рядка

    // NULL-safety -- традиція у сучасних мовах програмування, згідно з якою
    // розрізняються типи даних, які дозволяють значення NULL, та ті, 
    // які не дозволяють
    String? name = Console.ReadLine();     // Введення з консолі

    if (String.IsNullOrEmpty(name))
    {
        Console.WriteLine("Bye");
    }
    else
    {
        Console.WriteLine("Hello, " + name);   // Виведення з переводом рядка
    }
    // Типи даних
    // Усі типи даних є нащадками загального типу Object
    // через це вони мають ряд спільних методів: GetType, ToString, GetHashCode, ...
    // Типи даних належать простору імен System, для скорочення інструкцій
    // існють псевдоніми типів:
    int x;  // Псевдонім для System.Int32
    System.Int32 y;
    string s1;
    //System.String s2;
    float f;   // System.Single   -- 32 bit
    double g;  // System.Double   -- 62 bit
               // Nullable - версії
    Nullable<int> v;  // повна форма
    int? a;           // скорочена форма

    Console.Write("How old are you? ");
    String ageInput = Console.ReadLine()!;   // !(наприкінці) - NULL-checker
    int age = int.Parse(ageInput);           // Parsing - відновлення значення з рядка
    Console.WriteLine("Next year you'll be " + (age + 1));

    Console.Write("Previous ages: ");
    for (int i = 0; i < age; i += 1)
    {
        Console.Write(i + " ");
    }
    int rem = 10 % 3;   // залишок від ділення
    Console.WriteLine();
    // String - Immutable - не дозволяє зміни
    char c = ageInput[0];   // дозволено
                            // ageInput[0] = 'A';  - не дозволено
                            // якщо потрібно змінювати рядок, то слід формувати новий
    ageInput = "A" + ageInput.Substring(1);
}