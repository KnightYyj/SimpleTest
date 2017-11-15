using _1280.InterFace;
using _1280.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism;

namespace _1280_SecondhomeWork
{
    class Program
    {
        public static event Action FireEventHandlerEvent;//事件就是委托的实例，增加event关键字,防止外部直接invoke和赋值

        static void Main(string[] args)
        {
            #region  一个泛型方法(用接口和基类约束)
            //ConsoleColor color = ConsoleColor.Yellow;
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                BaseModel eastor = new Eastor()
                {
                    chair = "东派一椅",
                    EastorName = "东派Name",
                    table = "东派一桌",
                    fan = "东派一扇",
                    person = "东派一人",
                    ruler = "东派一尺"
                };

                BaseModel southor = new Southor()
                {
                    chair = "南派一椅",
                    SouthorName = "南派Name",
                    table = "南派一桌",
                    fan = "南派一扇",
                    person = "南派一人",
                    ruler = "南派一尺"
                };
                BaseModel westor = new Westor();
                
                BaseModel north = new North();
                Play<Eastor>((Eastor)eastor);
                Play<Southor>((Southor)southor);

            }
            #endregion

            #region  3  每个门派都有自己各不相同的绝活， 提供一个方法功能如下，为四个门派:
            {

            }
            #endregion

            #region 4 口技表演抽象类定义一个事件，用于模拟"火起"后的场景
            {
                Console.WriteLine("****************Event*****************");
                FireEventHandlerEvent += () => Console.WriteLine("夫起大呼");
                FireEventHandlerEvent += () => Console.WriteLine("妇亦起大呼");
                FireEventHandlerEvent += () => Console.WriteLine("两儿齐哭");
                FireEventHandlerEvent += () => Console.WriteLine("俄而百千人大呼");
                FireEventHandlerEvent += () => Console.WriteLine("百千儿哭");
                FireEventHandlerEvent += () => Console.WriteLine("百千犬吠");
                FireEventHandlerEvent.Invoke();
            }
            #endregion

            #region  设置不同门派实例对象的温度，去触发火起事件，然后自动触发一系列后续动作
            {
                Console.WriteLine("****************Fire*****************");
                LogHelper.WriteLog("****************Fire*****************");
                Southor southor = new Southor();
                southor.SouthFireEvent += () => Console.WriteLine("观察者--添加一系列事件1");
                southor.SouthFireEvent += () => Console.WriteLine("观察者--添加一系列事件2");
                southor.SetTemperature(800);
            }
            #endregion
            {
                Middler mid = new Middler();
                mid.MiddlerStartEvent += () => Console.WriteLine("*************开始MID******");
                mid.PerformanceEvent += () => Console.WriteLine("表演高潮");
                mid.MiddlerEndEvent += () => Console.WriteLine("***********ENDMID**************");
                mid.Show();//新增一个Show方法，依次调用方法
            }

            //json数据然后解析使用
            {
                Console.WriteLine("***工厂测试***");
                var south = SimpleFactory.Create<Southor>();
                Play<Southor>((Southor)south);
                south.SetTemperature(900);
                Console.WriteLine("***工厂测试结束***");
            }

              //下面的没怎么实现
              //8 在程序的某些环节，大家可以试着使用泛型、反射、特性；
              //可以尝试多线程并发
              //可以让不同门派的颜色不同
              //甚至可以尝试加入音效
            Console.ReadLine();
        }


      







        public static void Play<T>(T model) where T : BaseModel, ICharge
        {
            Type t = typeof(T);
            foreach (PropertyInfo item in t.GetProperties())
            {
                Console.WriteLine($"{t.FullName}的{ item.Name}属性值为{item.GetValue(model)}");
            }

            foreach (FieldInfo item in t.GetFields())
            {
                Console.WriteLine($"{t.FullName}的{ item.Name}字段值为{item.GetValue(model)}");
            }
            model.Start();
            model.Prologue();
            model.ImitateDogBark();
            model.ImitatePeopleVoice();
            model.ImitateWind();
            model.EndPerformance();
            model.AcceptMoney();
        }
    }
}
