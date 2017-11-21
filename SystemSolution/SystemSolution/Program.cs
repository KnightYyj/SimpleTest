
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemSolution.Common;
using SystemSolution.Common.Attributes;
using SystemSolution.Model;

namespace SystemSolution
{
    /// <summary>
    /// 4 如果数据库的表/字段名称和程序中实体不一致，尝试用特性提供；(数据库是state 程序得是status)
    ///  查询的实体数据希望通过反射展示全部数据，其中属性名称希望用具体中文描述，而不是实体的属性名；     思路反射中文特性放入字典中，从字典中查询
    ///5 进阶需求：提供泛型的数据库实体插入、实体更新、ID删除数据的数据库访问方法
    ///6 进阶需求（可选）：将数据访问层抽象，使用简单工厂+配置文件+反射的方式，来提供对数据访问层的使用
    ///7 进阶需求（可选）：按照课堂的例子，再增加几个验证特性如Required(非空)  Mobile(手机号格式) Email(格式) 字符串长度(最大最小)等，
    ///  注意这时候一个属性可能会有多个验证属性，比如Required+Email+长度
    ///  封装成一个泛型的数据校验方法，数据库增删改的时候，尝试完成数据校验    不知道放那一层中
    /// </summary>
    class Program
    {
        
        #region static Ctor
        static Program()
        {
            //程序异常统一处理
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //初始化程序，将所有反射Model信息存入泛型缓存
            Data.BootStart.Start();
        }
        #endregion
        static void Main(string[] args)
        {
            //通过简单工厂，反射创建dbcontext
            var dbContext = SystemSolution.SimpleFactory.DbContextFactory.Create();
            //测试用户表
            Console.WriteLine($"测试用户========================================");
            var userSet = dbContext.Set<User>();
            {
                //查
                var user = userSet.GetById(1);
                if (user != null)
                    Console.WriteLine($"  查询ID=1的用户 （姓名：{user.Name}）");
                var userDemo = new User()
                {
                    Account = "bank",
                    Password = "bank",
                    CompanyId = 1,
                    CompanyName = "腾讯科技",
                    CreateTime = DateTime.Now,
                    CreatorId = 0,
                    Email = "12345678@qq.com",
                    LastLoginTime = DateTime.Now,
                    LastModifierId = 0,
                    LastModifyTime = DateTime.Now,
                    Mobile = "139155706321",
                    Name = "苏州战士",
                    State = 0,     //实体的States       (数据库是state 程序得是status)目前这种方式 
                    UserType = DateTime.Now.Millisecond
                };
                //增
                if (!DataValidate.EmailValidate<User>(userDemo))// Email(格式)     可以用多播委托来完善一下
                {
                    Console.WriteLine($"{userDemo.Name} 用户邮箱不正确,无法新增！");
                }
                else
                {
                    if (!DataValidate.MobileValidate<User>(userDemo))
                    {
                        Console.WriteLine($"{userDemo.Name} 用户电话不正确,无法新增！");
                    }
                     var id = userSet.Insert(userDemo);
                    Console.WriteLine($"  插入新用户，返回ID为：{id}");
                }

                


                //删
                var isDeleted = userSet.Delete(6) > 0;
                Console.WriteLine($"  删除ID为的数据，结果：{isDeleted}");

                
                //改
                if (user != null)
                {
                    user.CompanyName = "腾讯科技" + DateTime.Now.ToShortDateString();
                    var isUpated = userSet.Update(user) > 0;
                    Console.WriteLine($"  修改ID为的数据，结果：{isUpated}");
                }

                {
                    //批量查询
                    Console.WriteLine($"  批量排序查询");
                    var list = userSet.GetList(o => o.Id > 1)
                        .OrderBy(o => o.UserType); //排序
                    foreach (var item in list)
                        Console.WriteLine($"姓名：{item.Name}，UserType:{item.UserType}");

                    Console.WriteLine($"  ----------------------");
                    var max = list.Max(o => o.UserType); //usertype 最大
                    Console.WriteLine($"  usertype 最大：" + max);

                    var min = list.Min(o => o.UserType); //usertype 最小
                    Console.WriteLine($"  usertype 最小：" + min);

                    var avg = list.Average(o => o.UserType); //平均
                    Console.WriteLine($"  usertype 平均：" + avg);

                    //表达式
                    var result = from s in list
                                 where s.UserType > 200
                                 select new { Name = s.Name, UserType = s.UserType };
                    Console.WriteLine($" UserType>200 的用户-----------");
                    foreach (var item in result)
                        Console.WriteLine($"姓名：{item.Name}，UserType:{item.UserType}");
                }


            }




            Console.WriteLine("hello");
            Console.ReadLine();
        }









        #region 异常处理
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("程序发生错误了," + e.ExceptionObject.ToString());
            Console.ReadLine();
            //todo 可以利用log4net写入本地或数据库
        }
        #endregion
    }
}
