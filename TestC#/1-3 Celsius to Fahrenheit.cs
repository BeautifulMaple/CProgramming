using System;

public class test
{
	static void Main(string[] args)
	{
        int playerScore = 80;

        if (playerScore >= 70)
        {
            Console.WriteLine("플레이어의 점수는 70점 이상입니다. 합격입니다!");
        }
        Console.WriteLine("프로그램이 종료됩니다.");

        Console.WriteLine();

        int itemCount = 5;
        string itemName = "HP 포션";

        if (itemCount > 0)
        {
            Console.WriteLine($"보유한 {itemName}의 수량: {itemCount}");
        }
        else
        {
            Console.WriteLine($"보유한 {itemName}이 없습니다.");
        }
    }
}
