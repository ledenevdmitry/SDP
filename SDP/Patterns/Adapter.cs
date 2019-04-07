using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Адаптер обеспечивает отличающийся интерфейс к объекту, предоставляя к нему доступ, подходящий клиенту
namespace SDP.Adapter
{
    //клиент, использующий старый интерфейс
    class Client
    {
        ITarget target;

        public Client(ITarget target)
        {
            this.target = target;
        }

        public void PrintRequest()
        {
            Console.WriteLine(target.GetRequest());
        }
    }

    //интерфейс, с которым раньше работал клиент
    public interface ITarget
    {
        string GetRequest();
    }

    //появляется другой класс, у которого другие методы, которые требуется адаптировать под клиента
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Определенный запрос.";
        }
    }

    // Адаптер делает интерфейс адаптируемого класса совместимым с клиентом
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        //адаптер агрегирует адаптируемый класс..
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        //..и на его основе реализует интерфейс ITarget
        public string GetRequest()
        {
            return $"Это '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}
