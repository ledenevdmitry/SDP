using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.Composite
{
    //компонент - базовый класс, от которого наследуются листья и компоновщики
    abstract class Component
    {
        public Component() { }

        //операция, которую лист или компоновщик будет выполнять
        public abstract string Operation();

        //компоновщики могут также добавлять компоненты
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        //и удалять
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        //проверка, является ли данный объект компоновщиком (или листом)
        public virtual bool IsComposite()
        {
            return true;
        }
    }

    //лист (не имеет дочерних элементов)
    class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    //компоновщик
    class Composite : Component
    {
        //дочерние элементы
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component)
        {
            this._children.Add(component);
        }

        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        // в операции компоновщика он выполняет какие-то свои действия,
        // а также вызывает операции дочерних элементов
        public override string Operation()
        {
            int i = 0;
            string result = "Branch(";

            foreach (Component component in this._children)
            {
                result += component.Operation();
                if (i != this._children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }

            return result + ")";
        }
    }

    class Client
    {
        //для клиента нет разницы, работает он с листом или компоновщиком,
        //тк у них одинаковый базовый класс
        public void ClientCode(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }
        
        public void ClientCode2(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }

            Console.WriteLine($"RESULT: {component1.Operation()}");
        }
    }
}
