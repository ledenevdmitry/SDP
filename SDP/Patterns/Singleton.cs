using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.Singleton
{
    // Синглтон имеет метод GetInstance, который при первом обращении создаст объект, 
    // а при последующих - будет возвращать старый, а не создавать новый
    class Singleton
    {
        private Singleton() { }

        // объект, он не будет пересоздаваться
        private static Singleton _instance;

        // при первом вызове создаст объект, при последующих - будет использовать старый
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        // Наконец, любой одиночка должен содержать некоторую бизнес-логику,
        // которая может быть выполнена на его экземпляре.
        public static void someBusinessLogic()
        {
            // ...
        }
    }
}
