using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Priprema_za_Zadaću_3
{
    public class NumberCollection
    {
        protected List<int> numbers = new List<int>();

        public int returnNumber(int index)
        {
            return numbers.ElementAt(index);
        }

        public virtual void addNumber(int number)
        {
            numbers.Add(number);
        }
    }

    public class PositiveNumbers : NumberCollection
    {
        public override void addNumber(int number)
        {
            if (number > 0)
            {
                numbers.Add(number);
            }
        }
    }

    public class SmallPositiveNumbers : PositiveNumbers
    {
        public override void addNumber(int number)
        {
            if (number > 0 && number < 10)
            {
                numbers.Add(number);
            }
        }
    }

    public class EvenSmallPositiveNumbers : SmallPositiveNumbers
    {
        public override void addNumber(int number)
        {
            if (number > 0 && number < 10 && number % 2 == 0)
            {
                numbers.Add(number);
            }
        }
    }


    public class NumberCollectionRefactored
    {
        protected List<int> numbers = new List<int>();
        public Tuple<int, string> returnNumber(int index)
        {
            string info = "";

            if (numbers.ElementAt(index) > 0 && numbers.ElementAt(index) < 10 && numbers.ElementAt(index) % 2 == 0)
            {
                info = "Even Small Positive Number";
            }
            else if (numbers.ElementAt(index) > 0 && numbers.ElementAt(index) < 10)
            {
                info = "Small Positive Number";
            }
            else if (numbers.ElementAt(index) > 0)
            {
                info = "Positive Number";
            }

            return new Tuple<int, string>(numbers.ElementAt(index), info);
        }
    }
}
