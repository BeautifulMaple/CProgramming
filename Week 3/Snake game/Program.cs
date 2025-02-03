using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Snake_game
{
    class Program
    {
        class Snake
        {
            private List<Point> body;       // 뱀의 몸통 리스트
            private Direction direction;    // 뱀의 방향
            public Snake(Point tail, int length, Direction direction)
            {
                body = new List<Point>();
                this.direction = direction;
                for (int i = 0; i < length; i++)
                {
                    Point p = new Point(tail.x + i, tail.y, tail.sym);
                    body.Add(p);
                    tail.x += 1;
                }
            }
            // 움직이는 뱀 그리기
            public void Draw()
            {
                foreach (Point p in body)
                    p.Draw();
            }
            public Point GetNextPoint()
            {
                Point head = body[body.Count - 1];
                Point newHead = new Point(head.x, head.y, head.sym);
                switch (direction)
                {
                    case Direction.UP:
                        newHead.y -= 1;
                        break;
                    case Direction.DOWN:
                        newHead.y += 1;
                        break;
                    case Direction.LEFT:
                        newHead.x -= 1;
                        break;
                    case Direction.RIGHT:
                        newHead.x += 1;
                        break;
                }
                return newHead;
            }
            public void SetDirection(Direction newDirection)
            {
                // 반대 방향으로 가지 못하도록 설정
                if ((direction == Direction.UP && newDirection == Direction.DOWN) ||
                    (direction == Direction.DOWN && newDirection == Direction.UP) ||
                    (direction == Direction.LEFT && newDirection == Direction.RIGHT) ||
                    (direction == Direction.RIGHT && newDirection == Direction.LEFT))
                {
                    return;
                }
                direction = newDirection;
            }

            // 뱀이 음식을 먹었는지 판단하는 메서드입니다.
            public bool Eat(Point food)
            {
                Point head = GetNextPoint();
                if (head.IsHit(food))
                {
                    food.sym = head.sym;
                    body.Add(food);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // 뱀이 이동하는 메서드입니다.
            public void Move()
            {
                Point tail = body.First();
                body.Remove(tail);
                Point head = GetNextPoint();
                body.Add(head);

                tail.Clear();
                head.Draw();
            }

            public bool IsHitTail()
            {
                var head = body.Last();
                for (int i = 0; i < body.Count - 1; i++)
                {
                    if (head.IsHit(body[i])) return true;
                }
                return false;
            }
            public bool IsHitWall()
            {
                var head = body.Last();
                if (head.x <= 0 || head.x >= 80 || head.y <= 0 || head.y >= 20) return true;
                return false;
            }
        }

        class FoodCreator
        {
            private int mapWidth;
            private int mapHeight;
            private char foodsym;
            private Random random;
            public FoodCreator(int width, int height, char sym)
            {
                mapWidth = width;
                mapHeight = height;
                foodsym = sym;
                random = new Random();
            }
            public Point CreateFood()
            {
                int x = random.Next(1, mapWidth - 1);
                int y = random.Next(1, mapHeight - 1);
                return new Point(x, y, foodsym);
            }
        }
        static void Main(string[] args)
        {
            int gameSpeed = 100;
            int foodCount = 0;  //먹은 횟수

            // 게임을 시작할 때 벽을 그립니다.
            DrawWalls();
            // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // 음식의 위치를 무작위로 생성하고, 그립니다.
            FoodCreator foodCreator = new FoodCreator(80, 20, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
            while (true)
            {
                // 키 입력이 있는 경우에만 방향을 변경합니다.
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 입력된 키를 화면에 표시하지 않음
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                            snake.SetDirection(Direction.UP);
                            break;
                        case ConsoleKey.S:
                            snake.SetDirection(Direction.DOWN);
                            break;
                        case ConsoleKey.A:
                            snake.SetDirection(Direction.LEFT);
                            break;
                        case ConsoleKey.D:
                            snake.SetDirection(Direction.RIGHT);
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("프로그램을 종료합니다.");
                            return;
                    }
                }

                // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
                // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.
                if(snake.Eat(food))
                {
                    foodCount++;
                    food.Draw();
                    // 뱀이 음식을 먹었다면, 새로운 음식을 만들고 그립니다.
                    food = foodCreator.CreateFood();
                    food.Draw();
                    if(gameSpeed > 10)
                    {
                        gameSpeed -= 10;
                    }
                }
                else snake.Move();
                Thread.Sleep(gameSpeed); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)

                if (snake.IsHitTail() || snake.IsHitWall()) break;

                // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)
                Console.SetCursorPosition(0, 21); // 커서 위치 설정
                Console.WriteLine("ESC를 눌러서 나가기");
                Console.WriteLine($"먹은 음식 수: {foodCount}"); // 먹은 음식 수 출력
            }
            WriteGameOver();  // 게임 오버 메시지를 출력합니다.
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 22;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("         GAME OVER", xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        // 벽 그리는 메서드
        static void DrawWalls()
        {
            // 상하 벽 그리기
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, 20);
                Console.Write("#");
            }

            // 좌우 벽 그리기
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(80, i);
                Console.Write("#");
            }
        }

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public char sym { get; set; }

            // Point 클래스 생성자
            public Point(int _x, int _y, char _sym)
            {
                x = _x;
                y = _y;
                sym = _sym;
            }

            // 점을 그리는 메서드
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }

            // 점을 지우는 메서드
            public void Clear()
            {
                sym = ' ';
                Draw();
            }

            // 두 점이 같은지 비교하는 메서드
            public bool IsHit(Point p)
            {
                return p.x == x && p.y == y;
            }
        }
        // 방향을 표현하는 열거형입니다.
        public enum Direction { UP, DOWN, LEFT, RIGHT }
    }
}