using System;

public class Solution
{
    static void Main(string[] args)
    {

        //// 1) 가위바위보 맞추기
        //string[] choices = { "가위", "바위", "보" };
        //string playerChoices = "";
        //string computerChoices = choices[new Random().Next(0, 3)];

        //while (playerChoices != computerChoices)
        //{
        //    Console.WriteLine("가위, 바위, 보 중 하나를 선택해주세요");
        //    playerChoices = Console.ReadLine();

        //    if (playerChoices == computerChoices)
        //    {
        //        Console.WriteLine("비겼습니다.");

        //    }
        //    else if ((playerChoices == "가위" && computerChoices == "보") ||
        //        (playerChoices == "바위" && computerChoices == "가위") ||
        //        (playerChoices == "보" && computerChoices == "바위"))
        //    {
        //        Console.WriteLine("이겼습니다.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("졌습니다.");
        //    }

        // 2) 숫자 맞추기
        int targetNumver = new Random().Next(1, 100);
        int guess = 0;
        int count = 0;
        Console.WriteLine("1부터 100 사이이 숫자를 맞춰보세요");

        while(guess != targetNumver)
        {
            Console.Write("추측한 숫자를 입력하세요: ");
            guess = int.Parse(Console.ReadLine());
            count++;

            if (guess < targetNumver)
            {
                Console.WriteLine("좀 더 큰 숫자를 입력해주세요");
            }
            else if (guess > targetNumver)
            {
                Console.WriteLine("좀 더 작은 숫자를 입력해주세요");
            }
            else
            {
                Console.WriteLine("축하합니다. 숫자를 맞추셨습니다.");
                Console.WriteLine("시도한 횟수: " + count);
            }
        }
    }
}