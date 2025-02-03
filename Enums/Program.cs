using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    internal class Program
    {
        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public static void ProcessMonth(int month)
        {
            if (month >= (int)Month.January && month <= (int)Month.December)
            {
                Month selectMonth = (Month)month;
                Console.WriteLine("선택한 월은 {0}입니다.", selectMonth);
            }
            else
            {
                Console.WriteLine("올바른 월을 입력해주세요.");
            }
        }
        static void Main(string[] args)
        {
            int userInput = 7;
            ProcessMonth(userInput);
        }
    }
}
