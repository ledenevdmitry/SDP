using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.FactoryMethod
{
    // Интерфейс Продукта 
    public interface IProduct
    {
        string Operation();
    }

    // Реализация интерфейса продукта
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    //еще одна Реализация интерфейса продукта
    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    //Класс Создателя, у которого есть фабричный метод, возвращающий IProduct
    abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            // Вызываем фабричный метод, чтобы получить объект-продукт.
            var product = FactoryMethod();
            // Далее, работаем с этим продуктом.
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    //реализация Создателя
    class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    //еще одна реализация Создателя
    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }


    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: запустили с одним создателем.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: запустили с другим создателем.");
            ClientCode(new ConcreteCreator2());
        }

        // Какого создателя мы фактически передадим, такой продукт создастся
        public void ClientCode(Creator creator)
        {
            // ...
            Console.WriteLine("Client: Неизвестно, какой создатель\n" + creator.SomeOperation());
            // ...
        }
    }

}
