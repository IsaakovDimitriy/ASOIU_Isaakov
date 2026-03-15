//Алгоритм Дамерау-Левенштейна
using System;

class EditDistance
{
    public static int Distance(string x, string y)
    {
        if ((x == null) || (y == null)) return -1;

        int xLen = x.Length;
        int yLen = y.Length;

        if ((xLen == 0) && (yLen == 0)) return 0;
        if (xLen == 0) return yLen;
        if (yLen == 0) return xLen;

        string str1 = x.ToUpper();
        string str2 = y.ToUpper();

        int[,] matrix = new int[xLen + 1, yLen + 1];

        for (int i = 0; i <= xLen; i++) matrix[i, 0] = i;
        for (int j = 0; j <= yLen; j++) matrix[0, j] = j;

        for (int i = 1; i <= xLen; i++)
        {
            for (int j = 1; j <= yLen; j++)
            {
                int symbEqual = (
                    (str1.Substring(i - 1, 1) ==
                    str2.Substring(j - 1, 1)) ? 0 : 1);

                int ins = matrix[i, j - 1] + 1;
                int del = matrix[i - 1, j] + 1;
                int subst = matrix[i - 1, j - 1] + symbEqual;

                matrix[i, j] = Math.Min(Math.Min(ins, del), subst);

                if ((i > 1) && (j > 1) &&
                    (str1.Substring(i - 1, 1) == str2.Substring(j - 2, 1)) &&
                    (str1.Substring(i - 2, 1) == str2.Substring(j - 1, 1)))
                {
                    matrix[i, j] = Math.Min(matrix[i, j],
                        matrix[i - 2, j - 2] + symbEqual);
                }
            }
        }
        return matrix[xLen, yLen];
    }

    public static void WriteDistance(string x, string y)
    {
        int d = Distance(x, y);
        Console.WriteLine("'" + x + "' ,'" +
            y + "' -> " + d.ToString());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добавление одного символа в начало, середину и конец строки");
        EditDistance.WriteDistance("ИВАНОВ", "ИИВАНОВ");
        EditDistance.WriteDistance("ИВАНОВ", "ИВАННОВ");
        EditDistance.WriteDistance("ИВАНОВ", "ИВАНОВВ");

        Console.WriteLine("\nДобавление двух символов в начало, середину и конец строки");
        EditDistance.WriteDistance("ИВАНОВ", "ИИИВАНОВ");
        EditDistance.WriteDistance("ИВАНОВ", "ИВАНННОВ");
        EditDistance.WriteDistance("ИВАНОВ", "ИВАНОВВВ");

        Console.WriteLine("\nДобавление трех символов");
        EditDistance.WriteDistance("ИВАНОВ", "ИИВАННОВВ");

        Console.WriteLine("\nТранспозиция");
        EditDistance.WriteDistance("ИВАНОВ", "ИВАОНВ");

        Console.WriteLine("\nРассмотренный ранее пример");
        EditDistance.WriteDistance("ИВАНОВ", "БАННОВ");

    }
}

//Алгоритм Левенштейна
//using System;

//class EditDistance
//{
//    public static int Distance(string x, string y)
//    {
//        if (x == null || y == null) return -1;

//        int xLen = x.Length;
//        int yLen = y.Length;

//        if (xLen == 0) return yLen;
//        if (yLen == 0) return xLen;

//        string str1 = x.ToUpper();
//        string str2 = y.ToUpper();

//        int[,] matrix = new int[xLen + 1, yLen + 1];

//        for (int i = 0; i <= xLen; i++) matrix[i, 0] = i;
//        for (int j = 0; j <= yLen; j++) matrix[0, j] = j;

//        for (int i = 1; i <= xLen; i++)
//        {
//            for (int j = 1; j <= yLen; j++)
//            {
//                int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

//                int ins = matrix[i, j - 1] + 1;
//                int del = matrix[i - 1, j] + 1;
//                int subst = matrix[i - 1, j - 1] + cost;

//                matrix[i, j] = Math.Min(Math.Min(ins, del), subst);
//            }
//        }
//        return matrix[xLen, yLen];
//    }

//    public static void WriteDistance(string x, string y)
//    {
//        int d = Distance(x, y);
//        Console.WriteLine($"'{x}' ,'{y}' -> {d}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Добавление одного символа в начало, середину и конец строки");
//        EditDistance.WriteDistance("ИВАНОВ", "ИИВАНОВ");
//        EditDistance.WriteDistance("ИВАНОВ", "ИВАННОВ");
//        EditDistance.WriteDistance("ИВАНОВ", "ИВАНОВВ");

//        Console.WriteLine("\nДобавление двух символов в начало, середину и конец строки");
//        EditDistance.WriteDistance("ИВАНОВ", "ИИИВАНОВ");
//        EditDistance.WriteDistance("ИВАНОВ", "ИВАНННОВ");
//        EditDistance.WriteDistance("ИВАНОВ", "ИВАНОВВВ");

//        Console.WriteLine("\nДобавление трех символов");
//        EditDistance.WriteDistance("ИВАНОВ", "ИИВАННОВВ");

//        Console.WriteLine("\nТранспозиция");
//        EditDistance.WriteDistance("ИВАНОВ", "ИВАОНВ");

//        Console.WriteLine("\nРассмотренный ранее пример");
//        EditDistance.WriteDistance("ИВАНОВ", "БАННОВ");
//    }
//}