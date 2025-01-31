

class Game
{
    static void Main(string[] args)
    {
        Random random = new Random();  // 랜덤 객체 생성
        int[] numbers = new int[3];  // 3개의 숫자를 저장할 배열

        // 3개의 랜덤 숫자 생성하여 배열에 저장
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 10);
        }

        int attempt = 0;  // 시도 횟수 초기화
        while (true)
        {
            Console.Write("3개의 숫자를 입력하세요 (1~9): ");
            int[] guesses = new int[3];  // 사용자가 입력한 숫자를 저장할 배열

            for(int i = 0;i < guesses.Length;i++)
            {
                guesses[i]  = int.Parse(Console.ReadLine());
            }
            int correct = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < guesses.Length; j++)
                {
                    if (numbers[i] == guesses[j])
                    {
                        correct++;
                        break;
                    }
                }
            }

            attempt++;
            Console.WriteLine("시도 횟수 #" + attempt + " : " + correct + "개의 숫자를 맞추셨습니다.");
            if(correct == 3)
            {
                Console.WriteLine("축하합니다. 모든 숫자를 맞췄습니다.");
                break;
            }
        }
    }
}
