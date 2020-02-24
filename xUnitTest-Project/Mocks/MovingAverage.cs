
/*
Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.

Example:

MovingAverage m = new MovingAverage(3);
m.next(1) = 1
m.next(10) = (1 + 10) / 2
m.next(3) = (1 + 10 + 3) / 3
m.next(5) = (10 + 3 + 5) / 3

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;


namespace xUnitTest_Project.Mocks
{
    public class MovingAverage
    {
        /** Initialize your data structure here. */
        int _size = 0;
        Queue<double> numbers = new Queue<double>();

        public MovingAverage(int size)
        {
            _size = size;
        }

        public double Next(int val)
        {
            if (_size == 0)
            {
                return 0;
            }

            if (numbers.Count >= _size)
            {
                numbers.Dequeue();
            }

            numbers.Enqueue(val);

            return numbers.Sum() / numbers.Count();
        }
    }

    /**
     * Your MovingAverage object will be instantiated and called as such:
     * MovingAverage obj = new MovingAverage(size);
     * double param_1 = obj.Next(val);
     */
}
