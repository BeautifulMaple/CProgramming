using System;

namespace HelloWorld
{
    class program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("산술연산자");
            int num1 = 20, num2 = 10;

            Console.WriteLine(num1 + num2);
            Console.WriteLine(num1 - num2);
            Console.WriteLine(num1 / num2);
            Console.WriteLine(num1 * num2);
            Console.WriteLine(num1 % num2);

            Console.WriteLine(5 / 2);

            Console.WriteLine();

            Console.WriteLine("관계연산자");

            Console.WriteLine(num1 == num2);
            Console.WriteLine(num1 != num2);
            Console.WriteLine(num1 > num2);
            Console.WriteLine(num1 < num2);
            Console.WriteLine(num1 >= num2);
            Console.WriteLine(num1 <= num2);

            Console.WriteLine();

            Console.WriteLine("논리연산자");
            int num3 = 15;
            Console.WriteLine(0 <= num3 && num3 <=20);  // 0과 20과 사이의 포함되면
            Console.WriteLine(0 > num3 || num3 > 20);   // 0과 ~ 20 사이에 포함되지 않으면
            Console.WriteLine(!(0 <= num3 && num3 <= 20));


            Console.WriteLine();
            int a = 0b1100; // 12 (2진수)
            int b = 0b1010; // 10 (2진수)

            int and = a & b; // 0b1000 (8)
            int or = a | b; // 0b1110 (14)
            int xor = a ^ b; // 0b0110 (6)

            int c = 0b1011; // 11 (2진수)
            int leftShift = c << 2; // 0b101100 (44)
            int rightShift = c >> 1; // 0b0101 (5)

            int d = 0b1100; // 12 (2진수)
            int bit3 = (d >> 2) & 0b1; // 1 (3번째 비트)
            d |= 0b1000; // 0b1100 | 0b1000 = 0b1100 (12)

            // 연산자 우선순위
            //1.괄호(): 괄호로 감싸진 부분은 가장 높은 우선순위로 먼저 계산됩니다.
            //2.단항 연산자: 단항 연산자들(++, --, +, -, !등)은 괄호 다음으로 높은 우선순위를 가집니다.
            //3.산술 연산자: 산술 연산자들(*, /, %, +, -)은 단항 연산자보다 우선순위가 낮습니다.
            //4.시프트 연산자: 시프트 연산자(<<, >>)는 산술 연산자보다 우선순위가 낮습니다.
            //5.관계 연산자: 관계 연산자들(<, >, <=, >=, ==, !=)는 시프트 연산자보다 우선순위가 낮습니다.
            //6.논리 연산자: 논리 연산자들(&&, ||)는 관계 연산자보다 우선순위가 낮습니다.
            //7.할당 연산자: 할당 연산자들(=, +=, -=, *=, /= 등)는 논리 연산자보다 우선순위가 낮습니다.
        }
    }
}