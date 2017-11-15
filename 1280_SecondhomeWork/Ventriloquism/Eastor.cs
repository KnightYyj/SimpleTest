using _1280.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class Eastor : BaseModel, ICharge
    {
        public string Field = "我是东派";
        public string EastorName { get; set; }

        public Eastor()
        {
            base.color = ConsoleColor.Blue;
        }

        public void EastWIthPlay()
        {
            Console.WriteLine("东派绝活");
        }
        public override void ImitateDogBark()
        {
            Console.WriteLine("东派模仿狗叫");
        }

        public override void ImitatePeopleVoice()
        {
            Console.WriteLine("东派模仿哭声");
        }

        public override void ImitateWind()
        {
            Console.WriteLine("东派模仿风声");
        }

        public void AcceptMoney()
        {
            Console.WriteLine("东派表演结束，收费");
        }
    }
}
