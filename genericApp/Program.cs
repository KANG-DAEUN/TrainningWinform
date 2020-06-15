using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericApp
{
    public class SimpleGeneric<T> // 제네릭 클래스
    {
        private T[] values; // 배열로 만듬
        private int index;

        public SimpleGeneric(int len) //글자길이 
        { // 생성자 자동생성 alt + enter
            values = new T[len];
            index = 0;
        }
        public void Add(params T[] args)
        { 
            foreach (T item in args) // tab 2번 하면 자동생성 하여 수정
            {
                values[index++] = item;
            }
        }
        public void Print()
        {
            foreach (T item in values)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SimpleGeneric<Int32> gIntegers = new SimpleGeneric<int>(10); // 배열 int형으로 사이즈 10
            SimpleGeneric<double> gDoubles = new SimpleGeneric<double>(10); // 배열 double형으로 사이즈 10

            gIntegers.Add(1, 2);
            gIntegers.Add(1, 2, 3, 4, 5, 6, 7);
            gIntegers.Add(10);

            gDoubles.Add(10.0, 12.4, 37.5);
            gIntegers.Print();
            gDoubles.Print();
        }
    }
}
