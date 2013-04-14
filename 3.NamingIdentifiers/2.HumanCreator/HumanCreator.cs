using System;
using System.Linq;

namespace HumansNameSpace
{
    class HumanCreator    {        enum Gender { CoolDude, HotChick };        class Human        {            public Gender Sex { get; set; }            public string Name { get; set; }            public int Age { get; set; }        }

        public void MakeHuman(int age)
        {
            Human newHuman = new Human();
            newHuman.Age = age;
            if (age % 2 == 0)
            {
                newHuman.Name = "Батката";
                newHuman.Sex = Gender.CoolDude;
            }
            else
            {
                newHuman.Name = "Мацето";
                newHuman.Sex = Gender.HotChick;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HumanCreator humanCreator = new HumanCreator();
            humanCreator.MakeHuman(2);
            humanCreator.MakeHuman(3);            
        }
    }
}
