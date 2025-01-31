using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Unit
    {
        public virtual void Move()
        {
            Console.WriteLine("두발로 걷기");
        }

        public void Attack()
        {
            Console.WriteLine("Unit 공격");
        }
    }

    public class Marine : Unit
    {

    }

    public class Zergling : Unit
    {
        public override void Move()
        {
            Console.WriteLine("네발로 걷기");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 사용 예시
            // #1 참조형태와 실형태가 같을때
            Marine marine = new Marine();
            marine.Move();
            marine.Attack();

            Zergling zergling = new Zergling();
            zergling.Move();
            zergling.Attack();

            // #2 참조형태와 실형태가 다를때
            List<Unit> list = new List<Unit>();
            list.Add(new Marine());
            list.Add(new Zergling());

            foreach (Unit unit in list)
            {
                unit.Move();
            }
        }
    }
}
