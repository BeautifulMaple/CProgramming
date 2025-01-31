using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    //추상 클래스
    abstract class Shape
    {
        // 추상 메소드 틀만 재공
        public abstract void Draw();
    }

    class Circle : Shape
    {
        // 강재로 클에 속을 부여
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }

    class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Square");
        }
    }

    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Triangle");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();
            list.Add(new Circle());
            list.Add(new Triangle());
            list.Add(new Square());

            foreach (Shape shape in list)
            {
                shape.Draw();
            }
        }
    }
}
