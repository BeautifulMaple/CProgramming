using System;

public class Solution
{
    static void Main(string[] args)
    {
        // for(초기식, 조건식, 증감식)
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        int ii = 0;
        while (ii < 10)
        {
            Console.WriteLine(ii);
            ii++;
        }

        // 최초의 한번을 허용 할 것이가?
        int sum = 0;
        int num;

        do
        {
            Console.Write("숫자를 입력하세요 (0 입력 시 종료): ");
            num = int.Parse(Console.ReadLine());
            sum += num;
        } while (num != 0);

        Console.WriteLine("합계: " + sum);

        Console.WriteLine();

        // 데이터 기준으로 돌기
        string[] inventory = { "검", "방패", "활", "화살", "물약" };

        foreach (string item in inventory)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("i: {0}, j: {1}", i, j);
            }
        }
        Console.WriteLine();

        for (int i = 2; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                Console.WriteLine(i + " x " + j + " = " + (i * j));
            }
        }

        // 가로 구구단
        for (int i = 2; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                Console.Write(i + " x " + j + " = " + (i * j) + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        // 세로 구구단
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 2; j <= 9; j++)
            {
                Console.Write(j + " x " + i + " = " + (i * j) + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 1; i <= 10; i++)
        {
            if (i % 3 == 0)
            {
                continue; // 3의 배수일 경우 다음 숫자로 넘어감
            }

            Console.WriteLine(i);
            if (i == 7)
            {
                break; // 7이 출력된 이후에는 반복문을 빠져나감
            }
        }

        //int sum = 0;

        while (true)
        {
            Console.Write("숫자를 입력하세요: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.WriteLine("프로그램을 종료합니다.");
                break;
            }

            if (input < 0)
            {
                Console.WriteLine("음수는 무시합니다.");
                continue;
            }

            sum += input;
            Console.WriteLine("현재까지의 합: " + sum);
        }

        Console.WriteLine("합계: " + sum);
    }
}