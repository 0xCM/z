//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppData<T>
        where T : AppData<T>, new()
    {
        protected virtual void Init()
        {

        }

        static readonly ConcurrentDictionary<object,object> Cache;

        static readonly T Instance;

        static object DataLock;

        protected AppData()
        {
            
        }

        static AppData()
        {
            Cache = new();
            Instance = new ();
            DataLock = new();
            Instance.Init();
        }
 
        [MethodImpl(Inline)]
        public static D get<D>(object key, Func<D> factory)
        {
            lock(DataLock)
                return (D)Cache.GetOrAdd(key, k => factory());
        }
    }
}