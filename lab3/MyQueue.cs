using System;

namespace lab3
{
    class MyQueue<T>
    {
        T[] elements;
        int count;

        public MyQueue()
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
                throw new ArgumentNullException("Queue is empty");
            else
            {
                T[] tempArr = new T[count - 1];
                for (int i = 1; i < count; i++)
                    tempArr[i - 1] = elements[i];
                T toReturn = elements[0];
                Array.Resize(ref elements, --count);
                elements = tempArr;
                return toReturn;
            }
        }
        public T First() => count == 0 ? throw new ArgumentNullException("Queue is empty") : elements[0]; 
        public int Size() => count;
        public MyQueue<T> Clear()
        {
            return new MyQueue<T>();
        }
    }
}
