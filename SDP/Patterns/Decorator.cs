using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Декоратор обеспечивает расширенный интерфейс в отличие от прокси
namespace SDP.Decorator
{
    //базовый абстрактный класс, который будет оборачиваться базовым декоратором
    public abstract class Component
    {
        public abstract string Operation();
    }

    //конкретный класс, который будет оборачиваться конкретным декоратором
    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "Конкретный компонент";
        }
    }

    // Базовый декоратор
    abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        // Декоратор делегирует всю работу обёрнутому компоненту.
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    // конкретный декоратор, наследуется от базового
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp)
        {
        }

        //использует метод базового декоратора, который в свою очередь использует метод декорируемого объекта
        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    //другой конкретный декоратор
    // Декораторы могут выполнять своё поведение до или после вызова обёрнутого
    // объекта.
    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }

    public class Client
    {
        //клиент может работать с любым классом и любым декоратором
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }
}
