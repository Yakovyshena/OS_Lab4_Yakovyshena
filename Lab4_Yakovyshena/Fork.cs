using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_Yakovyshena
{
    public class Fork
    {
        private bool istaken;

        public Fork() { Istaken = false; }

        public void put()
        {
            //Console.WriteLine("Fork put!");
            Istaken = false;
        }


        public bool Istaken
        {
            get { return istaken; }
            set { istaken = value; }
        }


    }
}
