using System;

namespace HelloWorld
{
    class program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter two numbers: ");
            string input = Console.ReadLine();    // "10 20"과 같은 문자열을 입력받음

            string[] numbers = input.Split(' ');  // 문자열을 공백으로 구분하여 배열로 만듦
            // { "10", "20" }
            int num1 = int.Parse(numbers[0]);     // 첫 번째 값을 정수로 변환하여 저장
            int num2 = int.Parse(numbers[1]);     // 두 번째 값을 정수로 변환하여 저장

            int sum = num1 + num2;                // 두 수를 더하여 결과를 계산

            Console.WriteLine("The sum of {0} and {1} is {2}.", num1, num2, sum);

            // var 키워드
            // 변수를 선언하면 변수의 자료형이 컴파일러에 의해 자동으로 결정됩니다. 
            var num = 10;         // int 자료형으로 결정됨
            var name = "kero";   // string 자료형으로 결정됨
            var pi = 3.141592;    // double 자료형으로 결정됨

        }
    }
}