﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.Facade
{
    // Класс Фасада предоставляет простой интерфейс для сложной логики одной или
    // нескольких подсистем. Фасад делегирует запросы клиентов соответствующим
    // объектам внутри подсистемы. Фасад также отвечает за управление их
    // жизненным циклом. Все это защищает клиента от нежелательной сложности
    // подсистемы.
    public class Facade
    {
        protected Subsystem1 _subsystem1;

        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

        // Методы Фасада удобны для быстрого доступа к сложной функциональности
        // подсистем. Однако клиенты получают только часть возможностей
        // подсистемы.
        public string Operation()
        {
            string result = "Фасад инициализирует подсистемы:\n";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += "Фасад упорядочивает подсистемы, управляя вызовами:\n";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            return result;
        }
    }

    // Подсистема может принимать запросы либо от фасада, либо от клиента
    // напрямую. В любом случае, для Подсистемы Фасад – это еще один клиент, и
    // он не является частью Подсистемы.
    public class Subsystem1
    {
        public string operation1()
        {
            return "Подсистема1: Готово!\n";
        }

        public string operationN()
        {
            return "Подсистема1: Поехали!\n";
        }
    }

    // Некоторые фасады могут работать с разными подсистемами одновременно.
    public class Subsystem2
    {
        public string operation1()
        {
            return "Подсистема2: Приготовиться!\n";
        }

        public string operationZ()
        {
            return "Подсистема2: Огонь!\n";
        }
    }


    class Client
    {
        // Клиентский код работает со сложными подсистемами через простой
        // интерфейс, предоставляемый Фасадом. Когда фасад управляет жизненным
        // циклом подсистемы, клиент может даже не знать о существовании
        // подсистемы. Такой подход позволяет держать сложность под контролем.
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }
}
