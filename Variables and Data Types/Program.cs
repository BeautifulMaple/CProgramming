using System;

namespace HelloWorld
{
    class program
    {
        static void Main(string[] args)
        {
            int num1 = 20; int num2 = 10;
            
            Console.WriteLine("산술연산자");

            Console.WriteLine(num1 + num2);
            Console.WriteLine(num1 - num2);
            Console.WriteLine(num1 / num2);
            Console.WriteLine(num1 * num1);
            Console.WriteLine(num1 % num2);

            Console.WriteLine(); // 빈줄 출력

            Console.WriteLine("관계연산자");
            Console.WriteLine(num1 == num2);
            Console.WriteLine(num1 != num2);
            Console.WriteLine(num1 > num2);
            Console.WriteLine(num1 < num1);
            Console.WriteLine(num1 >= num2);
            Console.WriteLine(num1 <= num2);

            Console.WriteLine(); // 빈줄 출력

            Console.WriteLine("논리연산자");
            int num3 = 15;
            Console.WriteLine(0 < num3 && num3 <= 20);  // 0 과 20사이의 포함되면
            Console.WriteLine(0 > num3 || num3 > 20);   // 0 ~ 20 사이에 포함되지 않다면
            Console.WriteLine(!(0 < num3 && num3 <= 20));

            Console.WriteLine(); // 빈줄 출력

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
        }
    }
}