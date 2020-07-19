using System;

namespace lab3
{
    class MyStack<T>
    {
        T[] elements;
        int count;
        public bool IsEmpty() => count == 0 ? true : false;

        public MyStack()
        {
            elements = new T[0];
            count = 0;
        }

        public void Push(T el)
        {
            Array.Resize(ref elements, ++count);
            elements[count - 1] = el;
        }

        public T Pop()
        {
            if (count == 0)
                throw new ArgumentNullException("Stack is empty");
            else
            {
                T toBeReturned = elements[count - 1];
                Array.Resize(ref elements, --count);
                return toBeReturned;
            }
        }

        public T Back()
        {
            if (count == 0)
                throw new ArgumentNullException("Stack is empty");
            else
                return elements[count - 1];
        }

        public int Size() => count;

        public MyStack<T> Clear()
        {
            return new MyStack<T>();
        }
    }
}
