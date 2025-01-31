class Overloding
{
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }
    static int AddNumbers(int a, int b, int c)
    {
        return a + b + c;
    }

    static float AddNumbers(float a, float b, float c)
    {
        return a + b + c;
    }
    static void Main(string[] args)
    {
        // 메서드 호출
        int sum1 = AddNumbers(10, 20);  // 두 개의 정수 매개변수를 가진 메서드 호출
        int sum2 = AddNumbers(10, 20, 30);  // 세 개의 정수 매개변수를 가진 메서드 호출
        float sum3 = AddNumbers(10, 20, 30);

        Console.WriteLine(sum1);
    }
}