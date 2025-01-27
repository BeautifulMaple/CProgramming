using System;

public class Solution
{
    static void Main(string[] args)
    {
        // 1) 홀수 / 짝수 구분하기
        //Console.WriteLine("번호를 입력하세요 : ");
        //int number = int.Parse(Console.ReadLine());

        //if(number % 2 == 0)
        //{ 
        //    Console.WriteLine("짝구입니다.");
        //}
        //else
        //{
        //    Console.WriteLine("홀수입니다.");
        //}

        //// 2) 등급 출력
        //int playerSocre = 100;
        //string playerRank = "";

        //switch(playerSocre / 10)
        //{
        //    case 10:
        //    case 9:
        //        playerRank = "Diamode";
        //        break;
        //    case 8:
        //        playerRank = "Platinum";
        //        break;
        //    case 7:
        //        playerRank = "Gold";
        //        break;
        //    case 6:
        //        playerRank = "Silver";
        //        break;
        //    case 5:
        //        playerRank = "Bronze";
        //        break;
        //    default:
        //        playerRank = "UnRank";
        //        break;
        //}

        //Console.WriteLine(playerRank);

        //// 3) 로그인 프로그램
        //string id = "id";
        //string password = "password";

        //Console.WriteLine("아이디를 입력하세요: ");
        //string inputId = Console.ReadLine();
        //Console.WriteLine("비밀번호를 입력하세요: ");
        //string inputPw = Console.ReadLine();


        //if (id == inputId && password == inputPw)
        //{
        //    Console.WriteLine("로그인 성공");
        //}
        //else
        //    Console.WriteLine("로그인 실패");

        // 4) 알파벳 판별 프로그램
        Console.Write("문자을 입력하세요: ");
        char input = Console.ReadLine()[0]; // indexing -> 문자열 끝에 있는 걸 가져옴

        if((input >= 'a' && input <= 'z') || (input >= 'A' && input <= 'Z'))
        {
            Console.WriteLine("알파뱃입니다.");
        }
        else
        {
            Console.WriteLine("알파뱃이 아닙니다.");
        }

    }
}