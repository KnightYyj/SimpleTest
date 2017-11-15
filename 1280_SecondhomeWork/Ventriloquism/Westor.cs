using _1280.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class Westor : BaseModel, ICharge
    {
        public string Field = "我是Westor";
        public string WestorName { get; set; }
        public void WestorWIthPlay()
        {
            Console.WriteLine("西派绝活");
        }
        public Westor()
        {
            base.color = ConsoleColor.Red;
        }
        public override void ImitateDogBark()
        {
            Console.WriteLine("西派DogBark");
        }

        public override void ImitatePeopleVoice()
        {
            Console.WriteLine("西派PeopleVoice");
        }

        public override void ImitateWind()
        {
            Console.WriteLine("西派Wind");
        }

        public override void Prologue()
        {
            Console.WriteLine($"{Field}:口技表演开场白");
        }

        public override void EndPerformance()
        {
            Console.WriteLine($"{Field}:口技表演结束语");
        }

        public void AcceptMoney()
        {
            Console.WriteLine("");
        }
    }
}
