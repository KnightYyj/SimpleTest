using _1280.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public abstract class BaseModel
    {
        public ConsoleColor color = ConsoleColor.White;
        public string person{ get;set;}
        public string table { get; set; }

        public string chair { get; set; }
        public string fan { get; set; }
        public string ruler { get; set; }

        public int temperature { get; set; }

        public void Start()
        {
            Console.WriteLine("表演开始了！");
        }

        public abstract void ImitateDogBark();
        public abstract void ImitatePeopleVoice();//模仿人声
        public abstract void ImitateWind();//模仿风声

       public virtual void Prologue()
        {
            Console.WriteLine("口技表演开场白");
        }

        public virtual void EndPerformance()
        {
            Console.WriteLine("口技表演结束语");
        }

        public virtual void SetTemperature(int temperature)
        {
            this.temperature = temperature;
            if (this.temperature > 400)
            {
                Console.WriteLine("*********火起***********");
            }
        }

     

    }
}
