using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackT
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _top;

        public MyStack()
        {
            _items = new T[4];
            _top = 0;
        }

        public int Count => _top;

        public void Push(T value)
        {
            if (_top == _items.Length)
            {
                Resize();
            }
            _items[_top++] = value;
        }

        public T Pop()
        {
            if ( _top == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T value = _items[_top - 1];
            _items[_top - 1] = default(T);
            _top--;
            return value;
        }

        public T Peek()
        {
            if (_top == 0)
            {
                throw new InvalidOperationException("Stack is ewmpty");
            }

            return _items[_top - 1];
        }


        public void Resize()
        {
            T[] newStack = new T[_items.Length * 2];
            for (int i = 0; i < _top; i++)
            {
                newStack[i] = _items[i];
            }
            _items = newStack;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> stack = new MyStack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Push("d");
            stack.Push("e");

            Console.WriteLine($"{stack.Peek()}");

            Console.WriteLine($"{stack.Pop()}");

            Console.WriteLine($"{stack.Peek()}");
        }
    }
}
