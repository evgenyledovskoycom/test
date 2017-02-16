using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] tokens_x1 = Console.ReadLine().Split(' ');

            enimalFactory hf = new enimalFactory();

            Horse h1 =  hf.createHorse(Convert.ToInt32(tokens_x1[0]), Convert.ToInt32(tokens_x1[1]));
            Horse h2 = hf.createHorse(Convert.ToInt32(tokens_x1[2]), Convert.ToInt32(tokens_x1[3]));
            

            if (findResult(h1, h2))
            {
                Console.WriteLine("YES");
            }
            else Console.WriteLine("NO");

            Console.ReadLine();
            
           
        }

        static bool findResult(animal en1, animal en2)
        {
            if (!canCatch(en1, en2))
                return false;

            return catchWithCompare(en1, en2);

        }

        static bool catchWithCompare(animal an1, animal an2)
        {
            while (true)
            {
                an1.step();
                an2.step();
             
                if (an1.xPosition == an2.xPosition)
                {
                    return true;
                }

                if (doSwappedPlaces(an1, an2))
                {
                    return false;
                }
        }

        }

        static bool doSwappedPlaces(animal an1, animal an2)
        {
            if ((an1.xStartPosition > an2.xStartPosition && an1.xPosition < an2.xPosition)

                   ||

                   (an2.xStartPosition > an1.xStartPosition && an2.xPosition < an1.xPosition)

                   )
            {
                return true;
            }
            else return false;
        }

        static bool canCatch(animal an1, animal an2)
        {
            if ((an1.xPosition < an2.xPosition && an1.speed < an2.speed + 1)
                ||
                (an2.xPosition < an1.xPosition && an2.speed < an1.speed + 1)

                )
               return false;
            
            else
                return true;
        }

    }

 

    abstract class animal : IStepable
    {
        internal int xStartPosition;
        internal int xPosition;
        internal int speed;

        public animal(int position, int speed)
        {
            xStartPosition = xPosition = position;
            this.speed = speed;
        }

        public abstract void step();

    }

    class Horse : animal
    {
        public Horse(int position, int speed) : base(position, speed)
            { }

        public override void step ()
        {
            xPosition += speed;   
        }
    }

    interface IStepable
    {
        void step();
    }

    class enimalFactory
    {
        public Horse createHorse(int position, int speed)
        {
            return new Horse(position, speed);
        }

    }

}




