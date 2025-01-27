using System;

public class test
{
	static void Main(string[] args)
	{

        Console.WriteLine("키(cm)를 입력하세요:");
        double heightCm = double.Parse(Console.ReadLine());

        Console.WriteLine("몸무게(kg)를 입력하세요:");
        double weight = double.Parse(Console.ReadLine());

        double heightm = heightCm / 100;

		double bmi = weight / (heightm * heightm);

		Console.WriteLine($"BMI: {bmi:F2}");

        // BMI 범주 출력
        if (bmi < 18.5)
        {
            Console.WriteLine("결과: 저체중");
        }
        else if (bmi < 25)
        {
            Console.WriteLine("결과: 정상");
        }
        else if (bmi < 30)
        {
            Console.WriteLine("결과: 과체중");
        }
        else
        {
            Console.WriteLine("결과: 비만");
        }


    }
}
