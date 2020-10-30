using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ooad2020E_schedule.Modeli
{
    public class finishedCounter
    {
        public int counter;
        public bool istina;
        public finishedCounter()
        {
            counter = 0; 
        }

        public int getCounter()
        {
            return counter;
        }

        public void setCounter(int counter)
        {
            this.counter = counter;
        }

    }
}