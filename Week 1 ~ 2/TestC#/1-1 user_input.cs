using System;

public class Class1
{
	static void Main(string[] args)
	{
		Console.WriteLine("이름과 나이를 입력하세요");
		string input = Console.ReadLine();

		string[] humon = input.Split(' ');
		string name = humon[0];
		int age = int.Parse(humon[1]);

		Console.WriteLine("이름 : {0} \n나이 : {1}", name, age);
	}
}
