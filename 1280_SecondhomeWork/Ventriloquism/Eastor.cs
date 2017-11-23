using _1280.InterFace;
using _1280.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class Eastor : BaseModel, ICharge
    {
        
        //public string EastorName { get; set; }

        public Eastor()
        {
            _context = Config.getConfig<Eastor, VocalConfig>();//配置文件转对象
            _outColor = ConsoleColor.Blue;
        }

        public void EastWIthPlay()  //自定义新增一个字段，一个属性，一个方法(绝活儿)，每个门派有独特道具和绝活儿，四个门派各不相同
        {
            ConsoleHelper.WriteLine("东派绝活", _outColor);
        }
        public override void ImitateDogBark()
        {
            ConsoleHelper.WriteLine("东派模仿狗叫", _outColor);
        }

        public override void ImitatePeopleVoice()
        {
            ConsoleHelper.WriteLine("东派模仿哭声", _outColor);
        }

        public override void ImitateWind()
        {
            ConsoleHelper.WriteLine("东派模仿风声", _outColor);
        }

        public void AcceptMoney()
        {
            ConsoleHelper.WriteLine("东派表演结束，收费", _outColor);
        }

     

    }
}
