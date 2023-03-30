namespace Hash_Dictionary;

public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList[] _buckets = new LinkedList[InitialSize];

    public void Add(string key, string value)
    {
        int curHash = CalculateHash(key);
        
        int index = curHash % InitialSize;
        if (_buckets[index] == null)
        {
            _buckets[index] = new LinkedList();
        }
        _buckets[index].Add(new KeyValuePair(key, value));
    }

    public void PrintDictionary(string key, string value)
    {
        for (int i = 0; i < InitialSize; i++)
        {
            Console.WriteLine($"Bucket number {i}:");
            var bucket = _buckets[i];
            if (bucket != null)
            {
                foreach (var pair in _buckets)
                {
                    Console.WriteLine($"  Key: {key}, Value: {value}");
                }
            }
            else
            {
                Console.WriteLine("  null");
            }
        }
    }
    public void Remove(string key)
    {
        int curHash = CalculateHash(key);
        
        int index = curHash % InitialSize;
        if (_buckets[index] == null)
        {
            throw new Exception("there is no such element (bucket is null)");
        }
        _buckets[index].RemoveByKey(key);
    }

    public string Get(string key)
    {
        int curHash = CalculateHash(key);
        
        int index = curHash % InitialSize;
        if (_buckets[index] == null)
        {
            throw new Exception("No such element (bucket is null)");
        }
        var pair = _buckets[index].GetItemWithKey(key);
        if (pair == null)
        {
            return null;
        }
        return pair.Value;
    }


     private int CalculateHash(string key)
    {
        // function to convert string value to number 
        int result = 0;
        foreach (var c in key)
        {
            byte number = Convert.ToByte(c);
            result += number * number;
        }
        return result;

    } 
}