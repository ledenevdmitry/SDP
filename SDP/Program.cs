using System;

namespace SDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethod
            new FactoryMethod.Client().Main();

            //Singleton

            Singleton.Singleton s1 = Singleton.Singleton.GetInstance();
            Singleton.Singleton s2 = Singleton.Singleton.GetInstance();

            //при проверке на равенство проверятся ссылки, они должны быть одинаковые,
            //тк старый объект переиспользуется 
            if (s1 == s2)
            {
                Console.WriteLine("Синглтон сработал, обе переменные содержат один и тот же объект.");
            }
            else
            {
                Console.WriteLine("Синглтон не сработал, переменные содержат разные объекты.");
            }

            //Adapter

            Adapter.Adaptee adaptee = new Adapter.Adaptee();
            Adapter.ITarget adapter = new Adapter.Adapter(adaptee);

            Console.WriteLine("Интерфейс адаптируемого класса несовместим с клиентам.");
            Console.WriteLine("Но с адаптером все в порядке.");

            //не получится использовать adaptee напрямую, необходимо использовать адаптер
            //Adapter.Client adapterClient = new Adapter.Client(adaptee); - !!!ошибка

            //вызов через адаптер проходит корректно
            Adapter.Client adapterClient = new Adapter.Client(adapter);
            adapterClient.PrintRequest();

            //Facade

            // В клиентском коде могут быть уже созданы некоторые объекты
            // подсистемы. В этом случае может оказаться целесообразным
            // инициализировать Фасад с этими объектами вместо того, чтобы
            // позволить Фасаду создавать новые экземпляры.
            Facade.Subsystem1 subsystem1 = new Facade.Subsystem1();
            Facade.Subsystem2 subsystem2 = new Facade.Subsystem2();
            Facade.Facade facade = new Facade.Facade(subsystem1, subsystem2);
            Facade.Client.ClientCode(facade);

            //Proxy: 
            //Client может работать как с базовым классом, так и с прокси

            Proxy.Client proxyClient = new Proxy.Client();

            Console.WriteLine("Client: выполнение клиентского кода с RealSubject:");
            Proxy.RealSubject realSubject = new Proxy.RealSubject();
            proxyClient.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: выполнение того же клиентского кода с proxy:");
            Proxy.Proxy proxy = new Proxy.Proxy(realSubject);
            proxyClient.ClientCode(proxy);

            //Composite

            Composite.Client compositeClient = new Composite.Client();

            // Таким образом, клиентский код может поддерживать простые
            // компоненты-листья...
            Composite.Leaf leaf = new Composite.Leaf();
            Console.WriteLine("Client: получил простой лист:");
            compositeClient.ClientCode(leaf);

            // ...а также сложные контейнеры.
            Composite.Composite tree = new Composite.Composite();
            Composite.Composite branch1 = new Composite.Composite();
            branch1.Add(new Composite.Leaf());
            branch1.Add(new Composite.Leaf());
            Composite.Composite branch2 = new Composite.Composite();
            branch2.Add(new Composite.Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: получил дерево:");
            compositeClient.ClientCode(tree);

            Console.Write("Client: не важно, дерево у нас или лист:\n");
            compositeClient.ClientCode2(tree, leaf);

            //Iterator

            // Клиентский код может знать или не знать о Конкретном Итераторе
            // или классах Коллекций, в зависимости от уровня косвенности,
            // который вы хотите сохранить в своей программе.
            var collection = new Iterator.WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            //Decorator

            Decorator.Client decoratorClient = new Decorator.Client();

            var simple = new Decorator.ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            decoratorClient.ClientCode(simple);
            Console.WriteLine();

            // ...так и декорированные.
            //
            // Обратите внимание, что декораторы могут обёртывать не только
            // простые компоненты, но и другие декораторы.
            Decorator.ConcreteDecoratorA decorator1 = new Decorator.ConcreteDecoratorA(simple);
            Decorator.ConcreteDecoratorB decorator2 = new Decorator.ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            decoratorClient.ClientCode(decorator2);

            Console.ReadKey();
        }
    }
}
