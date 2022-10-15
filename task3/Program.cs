using System.Collections;

MyDictionary<string, int> dir = new(("Vova", 1), ("Max", 5));
dir.Print();
Console.WriteLine($"Size = {dir.Size}");
dir.Add(("Sasha", 7));
dir.Print();
Console.WriteLine($"Size = {dir.Size}");
Console.WriteLine($"dir[\"Max\"] = {dir["Max"]}");
dir["Max"] = 4;
Console.WriteLine($"dir[\"Max\"] = {dir["Max"]}");
dir.Print();
foreach (var pair in dir)
{
    Console.WriteLine($"({pair.Item1}, {pair.Item2})");
}

internal class MyDictionary<TKey,TValue>
{
    private (TKey, TValue)[] _dir;
    public int Size { get; private set; } = 0;

    public MyDictionary(params (TKey, TValue)[] dir)
    {
        _dir = dir;
        Size = dir.Length;
    }

    public void Add((TKey, TValue) elem)
    {
        Size++;
        Array.Resize(ref _dir, Size);
        _dir[^1] = elem;
    }

    public void Print()
    {
        Console.Write("{");
        for (var i = 0; i < Size; i++)
        {
            if (i == Size - 1)
            {
                Console.Write($"({_dir[i].Item1}, {_dir[i].Item2})");
                break;
            }
            Console.Write($"({_dir[i].Item1}, {_dir[i].Item2}), ");
        }
        Console.WriteLine("}");
    }

    public TValue this[TKey key]
    {
        get
        {
            var i = 0;
            while (key != null && !key.Equals(_dir[i].Item1))
            {
                i++;
            }
            
            return _dir[i].Item2;
        }
        set
        {
            var i = 0;
            while (key != null && !key.Equals(_dir[i].Item1))
            {
                i++;
            }

            _dir[i].Item2 = value;
        }
    }

    public IEnumerator<Tuple<TKey, TValue>> GetEnumerator()
    {
        for (var i = 0; i < Size; ++i)
        {
            yield return new Tuple<TKey, TValue>(_dir[i].Item1, _dir[i].Item2);
        }
    }
}


