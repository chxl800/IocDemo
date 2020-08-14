using Autofac;
using BLL;
using BLL.Impl;
using Dao.Base;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IocApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //当前bil 文件里面所有dll
            var assemblies= Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").Select(Assembly.LoadFrom).ToArray();

            //注册所有实现了 IDependency 接口的类型
            var baseType= typeof(IDependency);

            var builder = new ContainerBuilder();
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()); //注册当前层的dll

            //注册所有dll，并且筛选【实现了IDependency接口的类型】
            builder.RegisterAssemblyTypes(assemblies)
                   //.Where(t => baseType.IsAssignableFrom(t) && t.Name.EndsWith("Controller"))
                   .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                   .AsSelf().AsImplementedInterfaces()
                   .PropertiesAutowired().InstancePerLifetimeScope();
            //.InstancePerDependency()用于控制对象的生命周期，每次加载实例时都是新建一个实例，默认就是这种方式
            builder.RegisterType<TestBLL>().SingleInstance(); //用于控制对象的生命周期，每次加载实例时都是返回同一个实例

            //其他演示 为更准确获取类型
            builder.RegisterType<ArrayList>().As<IEnumerable>();

            builder.RegisterType<ArrayList>().Named<IEnumerable>("array");
            builder.RegisterType<SortedList>().Named<IEnumerable>("sort");

            builder.RegisterType<ArrayList>().Keyed<IEnumerable>(ListType.Array);
            builder.RegisterType<SortedList>().Keyed<IEnumerable>(ListType.Sort);


            using (var container = builder.Build())
            {
                var userBll = container.Resolve<IUserBLL>();
                Console.WriteLine(userBll.SayHi("想想"));
                var userBll2 = container.Resolve<UserBLL>();
                Console.WriteLine(userBll2.SayHi("想想22"));

                var testBll = container.Resolve<TestBLL>();
                Console.WriteLine(testBll.SayHi("test"));

                //其他演示
                ArrayList result1 = (ArrayList)container.Resolve<IEnumerable>();

                ArrayList result2 = (ArrayList)container.ResolveNamed<IEnumerable>("array");
                SortedList result3 = (SortedList)container.ResolveNamed<IEnumerable>("sort");

                ArrayList result4 = (ArrayList)container.ResolveKeyed<IEnumerable>(ListType.Array);
                SortedList result5 = (SortedList)container.ResolveKeyed<IEnumerable>(ListType.Sort);
            }
        }
    }
}
