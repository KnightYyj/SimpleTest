using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class Middler : BaseModel
    {
        public override void ImitateDogBark()
        {
            Console.WriteLine("Middler模仿狗叫");
        }

        public override void ImitatePeopleVoice()
        {
            Console.WriteLine("Middler模仿哭声");
        }

        public override void ImitateWind()
        {
            Console.WriteLine("Middler模仿风声");
        }

        public void MiddlerWIthPlay()
        {
            Console.WriteLine("Middler派绝活");
        }

        public event Action MiddlerStartEvent;
        public event Action PerformanceEvent;
        public event Action MiddlerEndEvent;

        //新增一个Show方法，依次调用方法
        public void Show()
        {
            base.Start();
            base.Prologue();
            ImitateDogBark();
            ImitatePeopleVoice();
            ImitateWind();
            MiddlerWIthPlay();
            OnEvent();
            EndPerformance();
            AcceptMoney();
            ENDEvent();
        }
        protected void OnEvent()
        {
            PerformanceEvent?.Invoke();
        }
        protected void ENDEvent()
        {
            MiddlerEndEvent?.Invoke();
        }

        public void AcceptMoney()
        {
            Console.WriteLine("Middler收费");
        }
    }
}
