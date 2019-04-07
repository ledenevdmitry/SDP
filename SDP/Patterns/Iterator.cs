using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.Iterator
{
    //Структура данных, для которой мы создаем итератор
    //в данном случае коллекция слов
    //наследуется от IteratorAggregate и реализует его GetEnumerator, 
    //чтобы можно было обойти структуру данных с помощью foreach 
    class WordsCollection : IteratorAggregate
    {
        List<string> _collection = new List<string>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<string> getItems()
        {
            return _collection;
        }

        public void AddItem(string item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new BidirectionIterator(this, _direction);
        }
    }

    //итератор - объект, позволяющий обойти какую-нибудь структуру данных
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        // Возвращает ключ текущего элемента
        public abstract int Key();

        // Возвращает текущий элемент.
        public abstract object Current();

        // Переходит к следующему элементу.
        public abstract bool MoveNext();

        // Перематывает Итератор к первому элементу.
        public abstract void Reset();
    }

    // конкретный итератор реализуют алгоритм обхода. 
    // итератор хранит текуще положение обхода
    // в данном случае у нас двунаправленный итератор, позволяющий ходить из начала в конец и из конца в начало
    class BidirectionIterator : Iterator
    {
        private WordsCollection _collection;

        // Хранит текущее положение обхода. У итератора может быть множество
        // других полей для хранения состояния итерации, особенно когда он
        // должен работать с определённым типом коллекции.
        private int _position = -1;

        private bool _reverse = false;

        public BidirectionIterator(WordsCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = collection.getItems().Count;
            }
        }

        //возвращает текущий элемент
        public override object Current()
        {
            return this._collection.getItems()[_position];
        }

        //индекс текущего элемента
        public override int Key()
        {
            return this._position;
        }

        //перейти к следующему элементу
        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        //сбросить
        public override void Reset()
        {
            this._position = this._reverse ? this._collection.getItems().Count - 1 : 0;
        }
    }

    abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
