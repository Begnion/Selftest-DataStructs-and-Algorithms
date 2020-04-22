using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Output(int[,] arr)
        {
            int p = arr.GetLength(0)-1;
            int q = arr.GetLength(1)-1;
            int x = 0, y = 1;
            for (int z = 0; z < 3; z++)
            {
                for (int i = x; i <= q; i++) Console.Write("{0} ", arr[x, i]);
                for (int i = y; i <= p; i++) Console.Write("{0} ", arr[i, q]);
                for (int i = q - 1; i >= x; i--) Console.Write("{0} ", arr[p, i]);
                for (int i = p - 1; i >= y; i--) Console.Write("{0} ", arr[i, x]);
                x++; y++; p--; q--;
            }
        }
        static void Main(string[] args)
        {
            //int[,] arr = new int[4, 4] { { 1, 2, 3 ,4}, { 5,6,7,8 }, { 9,10,11,12 },{ 13,14,15,16} };
            //Output(arr);
            B1 b1 = new B1();
            B2 b2 = new B2();
            b1.SayHello();
            b2.SayHello();

            A a1 = new B1();
            A a2 = new B2();
            a1.SayHello();
            a2.SayHello();

            Console.Read();
        }
    }

    public class A
    {
        public virtual int Id { get; set; }
        public virtual void SayHello()
        {
            Console.WriteLine("Hello, it's A");
        }
    }

    public class B1:A
    {
        public override int Id { get; set; }
        public override void SayHello()
        {
            Console.WriteLine("Hello, it's B1.");
        }
    }

    public class B2 : A
    {
        public new void SayHello()//overwrite
        {
            Console.WriteLine("Hello, it's B2.");
        }
    }
}
