using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    enum FoodType { 土豆肉丝, 西红柿炒蛋 }
    class Class1
    {
        static void Main()
        {
            Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
                food1.Print();

            Food food2 = FoodSimpleFactory.CreateFood("土豆肉丝");
            food2.Print();

        }

    }


    public class FoodSimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type.Equals("土豆肉丝"))
            {
                food = new ShreddedPorkWithPotatoes();
            }
            else if (type.Equals("西红柿炒蛋"))
            {
                food = new TomatoScrambledEggs();
            }
            return food;
        }
    }



    public abstract class Food
    {
        public abstract void Print();
    }


    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒蛋");
        }
    }


    public class ShreddedPorkWithPotatoes: Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒蛋");
        }
    }
}
