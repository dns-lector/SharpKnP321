using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP321.Collect
{
    internal class CollectionsDemo
    {
        public void Run()
        {
            // Collections
            List<String> strings = [];
            for (int i = 0; i < 10; i++)
            {
                strings.Add("String " + i);
            }
            foreach(String str in strings)
            {
                Console.WriteLine(str);
                // strings.Remove(str);   // InvalidOperationException: Collection was modified
                // strings.Add("New")     // InvalidOperationException: Collection was modified
            }
            strings.Add("New 7");   // поза циклом помилок немає
            Console.WriteLine("----------");
            strings.ForEach(Console.WriteLine);
            Console.WriteLine("----------");
            // Видалити усі елементи, які завершуються на непарне число
            // Під час ітерації видалення призведе до винятку, відповідно для рішення
            // потрібна друга колекція
            List<String> removes = [];
            foreach(var str in strings) // утворюємо цикл по strings та модифікуємо removes
            {
                char c = str[^1];
                if(c <= '9' && c >= '0')
                {
                    int n = (int)c;   // '0'=48, '1'=49, ... - парність числа збігається з парністю ASCII коду
                    if((n & 1) == 1)
                    {
                        removes.Add(str);   // у першому циклі знаходимо ті, що мають 
                        // бути видалені та поміщуємо їх (посилання на них) у другу колекцію
                    }
                }
                // Console.WriteLine(str[^1]);
            }
            // утворюємо цикл по removes та модифікуємо strings
            foreach(String rem in removes)
            {
                strings.Remove(rem);
            }
            Console.WriteLine("----------");
            strings.ForEach(Console.WriteLine);
            Console.WriteLine("----------");
        }
        /* bool: a && b
         * bitwise: x & y - побітовий "ТА"
         * x = 10    1010
         * y = 8     1000
         * x & y        0
         */
        /* 001000 | 001001 = 001001
         */
        /* Slices
         * str = "The string"
         * str[1] = 'h'
         * str[1..4] = "he s"
         * str[..5] == str[0..5] = "The st"
         * str[5..] = "tring"
         * str[^1] = "g" (-1 - перший з кінця)
         * str[..^1] = "The strin"
         */

        public void RunArr()
        {
            Console.WriteLine("Collections Demo");
            /* Масив(класично) - спосіб збереження даних, за якого однотипні дані розміщуються у
             * пам'яті послідовно і мають визначений розмір.
             * У C#.NET масив - об'єкт, який забезпечує управління класичним масивом.
             */
            String[] arr1 = new String[3];
            String[] arr2 = new String[3] { "1", "2", "3" };
            String[] arr3 = { "1", "2", "3" };
            String[] arr4 = [ "1", "2", "3" ];
            arr1[0] = new("Str 1");   // базовий синтаксис роботи з елементами масивів
            arr1[1] = arr2[0];        // забезпечується індексаторами на відміну від С++
                                      // де [n] - це розіменування зі зміщенням: a[n] == *(a + n)
                                      // Dereferencing (Posible null dereferencing -> NullReferenceExc)
            
            arr1[0] = "New Str 1";
            int x = arr1.Length;

            /* На відміну від масивів колекції:
             * дозволяють змінний розмір
             * дозволяють непослідовне збереження
             */
        }
    }
}
/* Garbage Collector
 * [obj1  obj2  obj3 ....]
 * [obj1  ----  obj3 ....] 
 * 
 * 
 *                pointer                      pointer
 *                   |                           |
 * GC: [obj1  ----  obj3 ....] --> [obj1 obj3 ........] 
 *                   |                    |
 *               reference             reference
 * 
 * 
 * [ arr1[0] arr1[1] ...        "Str1" ... "New Str 1" ]
 *      \_x______________________/           /
 *        \_________________________________/
 */
