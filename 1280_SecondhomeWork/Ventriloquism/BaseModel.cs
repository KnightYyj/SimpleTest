using _1280.InterFace;
using _1280.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    /// <summary>
    /// 增加控制台输出方法
    /// 增加context 然base类只读 根据配置去获取
    /// </summary>
    public abstract class BaseModel 
    {


        protected VocalConfig _context;
        protected ConsoleColor _outColor;

        public VocalConfig Context => _context;//让子类去赋值

        
        //public ConsoleColor Color { get; set; }
        public string Person => _context.Person;
        public string Table => _context.Table;

        public string Chair => _context.Chair;
        public string Fan => _context.Fan ;
        public string Ruler => _context.Ruler ;

        public string bField ;//自定义新增一个字段

        public string Base_Name => _context.Base_Name;//自定义新增一个属性





        public void Start()
        {
            Console.WriteLine("表演开始了！");
        }

        public abstract void ImitateDogBark();
        public abstract void ImitatePeopleVoice();//模仿人声
        public abstract void ImitateWind();//模仿风声

       public virtual void Prologue()//开场白
        {
            ConsoleHelper.WriteLine("口技表演开场白");
        }

        public virtual void EndPerformance()
        {
            ConsoleHelper.WriteLine("谢谢大家的欣赏，本次表演结束");
        }


        #region 起火事件相关
    
        //[DisplayName("起火温度")]
        public int temperature = 400;

        public virtual void SetTemperature(int currentTemperaturn)   //这里也修改了，以前写的纯粹400的数字
        {
            if (currentTemperaturn > temperature)
            {
                ConsoleHelper.WriteLine("*********火起***********");
                OnFireEvent();
            }
            
        }
       
        //观察者模式
        public event Action FireEvent;

        protected void OnFireEvent()
        {
            FireEvent?.Invoke();
        }
        #endregion
    }
}
