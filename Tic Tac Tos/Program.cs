using System;

namespace TikTakToe
{
    class Program
    {
        static int[,] map = new int[3, 3];
        static int currentPlayer = 1; // 1: X, 2: O

        static void Main(string[] args)
        {
            int turnCount = 0;
            bool isGameOver = false;

            while (!isGameOver)  // 기존 코드에서 while 조건 오류 수정
            {
                PrintMap();
                PlayerMove();
                turnCount++;

                if (CheckWin())
                {
                    PrintMap();
                    Console.WriteLine($"플레이어 {currentPlayer} 승리!");
                    isGameOver = true;
                    break;
                }
                else if (turnCount == 9)
                {
                    PrintMap();
                    Console.WriteLine("무승부");
                    isGameOver = true;
                    break;
                }

                currentPlayer = (currentPlayer == 1) ? 2 : 1; // 턴 변경

            }
        }

        static void PlayerMove()
        {
            int row, col;
            while (true)
            {
                Console.WriteLine($"플레이어 {currentPlayer} ({(currentPlayer == 1 ? "X" : "O")}), 좌표 입력 (행 열): ");
                string[] input = Console.ReadLine().Split();

                if (input.Length != 2 ||
                    !int.TryParse(input[0], out row) ||
                    !int.TryParse(input[1], out col) ||
                    row < 0 || row > 2 || col < 0 || col > 2 ||
                    map[row, col] != 0)
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                }
                else
                {
                    break;
                }
            }
            map[row, col] = currentPlayer;
        }
        static bool CheckWin()
        {
            for(int i = 0; i < 3; i++)
            {
                // 가로 체크하기
                if (map[i, 0] != 0 && map[i,0] == map[i,1] && map[i, 1] == map[i, 2]) return true;
                // 세로 체크하기
                if (map[0, i] != 0 && map[0, i] == map[1, i] && map[1, i] == map[2, i]) return true;
            }

            // 대각선 체크
            // 좌상단 → 우하단
            if (map[0, 0] != 0 && map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2]) return true;
            // 우상단 → 좌하단
            if (map[0, 2] != 0 && map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0]) return true;

            return false;
        }

        static void PrintMap()
        {
            Console.Clear(); // 화면을 깨끗하게 정리
            Console.WriteLine("틱택토 게임 보드:");
            Console.WriteLine();

            // 열 인덱스 출력 (0 1 2)
            Console.Write("   "); // 좌측 여백 추가
            for (int i = 0; i < 3; i++)
            {
                Console.Write($" {i}  ");
            }
            Console.WriteLine();
            Console.WriteLine("  -------------"); // 상단 테두리

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} |"); // 행 인덱스 출력

                for (int j = 0; j < 3; j++)
                {
                    char symbol = map[i, j] == 1 ? 'X' : (map[i, j] == 2 ? 'O' : ' ');
                    Console.Write($" {symbol} |");
                }
                Console.WriteLine();
                if (i != 2) Console.WriteLine("  ----+---+----"); // 가로 구분선
            }
            Console.WriteLine("  -------------"); // 하단 테두리
            Console.WriteLine();
        }

    }
}
