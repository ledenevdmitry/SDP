using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Прокси обеспечивает тот же самый интерфейс, что и базовый класс, оборачивает его методы
namespace SDP.Proxy
{
    // интерфейс, от которого будут наследоваться RealSubject и Proxy
    public interface ISubject
    {
        void Request();
    }

    // Базовый класс, для которого создается прокси 
    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Обработка запроса.");
        }
    }

    // прокси
    class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        //в своем методе реквест прокси оборачивает реквест базового класса, 
        //проверяя доступ, логируя и т. п.
        public void Request()
        {
            if (this.CheckAccess())
            {
                this._realSubject = new RealSubject();
                this._realSubject.Request();

                this.LogAccess();
            }
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Проверка доступа.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Логирование запроса.");
        }
    }

    public class Client
    {
        //клиент может работать как с базовым классом, так и с прокси, 
        //тк интерфейс у них одинаковый - ISubject
        public void ClientCode(ISubject subject)
        {
            // ...

            subject.Request();

            // ...
        }
    }
}
