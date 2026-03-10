using System;

class Program 
{
    /*
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
        catch (Exception e)
        {
            Console.WriteLine("배열의 범위를 벗어났습니다.\r\n{0}\r\n", e.Message);
        }
        //finally
        //{
        //    Console.WriteLine("예외처리 완료");

            // Open 된 자원을 close 필요.
        //}

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
    */

    public static int Main(string[] args)
    {
        try
        {
            int num = GetNumber();
            if (num < 0 || num > 10)
                throw new FilterableException ("f에러", num);
            else
                Console.WriteLine($"Output : {num}");
        }
        catch (FilterableException e) when (e.ErrorCode < 0)
        {
            Console.WriteLine($"Error : {e.ErrorCode}");
        }
        catch (FilterableException e)
        {
            Console.WriteLine($"Unknown Error : {e.ErrorCode}");
        }
        finally
        {
            // 
        }
        return 0;
    }

    static int GetNumber()
    {
        while (true) // 올바른 숫자를 입력할 때까지 무한 반복
        {
            Console.Write("숫자를 입력하세요: ");
            string? input = Console.ReadLine();

            // 1. 숫자로 변환 가능한지 확인
            if (int.TryParse(input, out int result))
            {
                return result; // 변환 성공 시 숫자 반환
            }

            // 2. 실패 시 안내 메시지 출력
            Console.WriteLine("오류: 유효한 숫자가 아닙니다. 다시 시도하세요.");
        }
    }
}

class FilterableException : Exception
{
    public int ErrorCode { get; set; }

    public FilterableException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}