using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface1
{
    internal class Program
    {
        // 인터페이스 구현해보기
        public interface IMovable
        {
            void Move(int x, int y);
        }
        public class Player : IMovable
        {
            public void Move(int x, int y)
            {
                // 이동 구현
            }
        }
        public class Enemy : IMovable
        {
            public void Move(int x, int y)
            {
                // 이동 구현
            }
        }
        static void Main(string[] args)
        {
            IMovable movableObject1 = new Player();
            IMovable movableObject2 = new Enemy();

            movableObject1.Move(1,2);
            movableObject2.Move(1,9);
        }
    }
}
