using System;

class Program 
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("Hello, World!");

        int[] src = {1, 2, 3, 4, -10};
        int[] dest = new int[src.Length];

        CopyArray<int>(src, dest);

        //12. 예외처리하기
        try
        {
            for (int i = 0; i < dest.Length + 1; i++)
            {
                Console.WriteLine(dest[i]);
            }
        }
        //catch (IndexOutOfRangeException e)
        //{
        //    Console.WriteLine("배열의 범위를 벗어났습니다. \r\n" + e.Message);
        //}
        finally
        {
            Console.WriteLine("예외처리 완료");
        }

        Console.WriteLine("프로그램 정상 종료");
    }

    // generic method
    public static void CopyArray<T> (T[] source, T[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }
}