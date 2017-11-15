using _1280.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class North : BaseModel, ICharge
    {
        public string Field = "我是North";
        public string NorthName { get; set; }
        public void NorthWIthPlay()
        {
            Console.WriteLine("北派绝活");
        }
        public override void ImitateDogBark()
        {
            Console.WriteLine("北派DogBark");
        }
        public North()
        {
            base.color = ConsoleColor.Green;
        }
        public override void ImitatePeopleVoice()
        {
            Console.WriteLine("北派PeopleVoice");
        }

        public override void ImitateWind()
        {
            Console.WriteLine("北派Wind");
        }
        public override void EndPerformance()
        {
            Console.WriteLine($"{this.Field}复写口技表演结束语");
        }

        public void AcceptMoney()
        {
            Console.WriteLine("");
        }



        public override void SetTemperature(int temperature)
        {
            base.temperature = temperature;
            if (base.temperature > 1000)
            {
                Console.WriteLine("*********火起***********");
            }
        }
    }
}
