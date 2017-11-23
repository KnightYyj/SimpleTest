using _1280.InterFace;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class Southor : BaseModel, ICharge
    {
        public string Field = "我是Southor";
        public string SouthorName { get; set; }
        public void SouthorWIthPlay()
        {
            Console.WriteLine("南派绝活");
        }
        public Southor()
        {

        }

        //public Southor(string speak)
        //{
        //    Console.WriteLine($"{speak}");

        //}
        public override void ImitateDogBark()
        {
            Console.WriteLine("南派");
        }

        public override void ImitatePeopleVoice()
        {
            Console.WriteLine("南派");
        }

        public override void ImitateWind()
        {
            Console.WriteLine("南派");
        }

        public override void Prologue()
        {
            Console.WriteLine($"{this.Field}复写口技表演开场白");
        }

        public void AcceptMoney()
        {
            Console.WriteLine("南派收费");
        }
        public override void SetTemperature(int temperature)
        {
            base.temperature = temperature;
            if (base.temperature > 800)
            {
                Console.WriteLine($"****{Field}*****火起***********");
            }
            base.OnFireEvent();
        }

      

    }
}
