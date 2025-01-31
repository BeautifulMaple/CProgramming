using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_and_Ref
{
    internal class Program
    {
        // out 키워드 사용 예시
        // out는 메소드에서 반환 값을 매개변수로 전달할 경우 사용한다.
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        // ref 키워드 사용 예시
        static void Swap(ref int a, ref int b)
        {
            int teml = a;
            a = b; 
            b = teml;
        }

        static void Main(string[] args)
        {
            int quotient, remalinder;
            // out 변수의 위치를 제공한다. 값을 채운다
            Divide(7, 3, out quotient, out remalinder);
            Console.WriteLine($"{quotient}, {remalinder}");

            // ref를 통해서 직접적으로 참조할지 말지 모른다(?)
            int x = 1, y = 2;
            Swap(ref x, ref y);
            Console.WriteLine($"{x}, {y}");

        }
    }
}
