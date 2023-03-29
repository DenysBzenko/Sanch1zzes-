public class KeyValuePair
{
    public string Key { get; }

    public string Value { get; }

    public KeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}

public class LinkedListNode
{
    public KeyValuePair Pair { get; }
        
    public LinkedListNode Next { get; set; }

    public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
    {
        Pair = pair;
        Next = next;
    }
}

public class LinkedList
{
    private LinkedListNode _first;

    public void Add(KeyValuePair pair)
    {
        if (_first == null)
        {
            // Якщо список порожній, створюємо новий вузол
            _first = new LinkedListNode(pair);
        }
        else
        {
            // Якщо список не порожній, шукаємо останній вузол і додаємо новий вузол в кінець
            LinkedListNode currentNode = _first;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = new LinkedListNode(pair);
        }
    }

    public void RemoveByKey(string key)
    {
        if (_first == null)
        { 
            // Якщо список порожній, нічого не робимо
            return;
        } 
        // Якщо перший елемент має ключ, що співпадає з переданим параметром, видаляємо його
        if (_first.Pair.Key == key)
        {
            _first = _first.Next;
            return;
        }

        // Шукаємо елемент з переданим ключем та видаляємо його
        LinkedListNode currentNode = _first;
        while (currentNode.Next != null)
        {
            if (currentNode.Next.Pair.Key == key)
            {
                currentNode.Next = currentNode.Next.Next;
                return;
            }
            currentNode = currentNode.Next;
        }

    }

    public KeyValuePair GetItemWithKey(string key)
    {
        LinkedListNode currentNode = _first;
        while (currentNode != null)
        {
            if (currentNode.Pair.Key == key)
            {
                return currentNode.Pair;
            }
            currentNode = currentNode.Next;
        }
        return null;
    }
}