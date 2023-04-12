//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AppGlobals
    {
        static ConcurrentDictionary<string, IDisposable> Registry = new();

        public static T register<T>(string name, Func<T> factory, Action<T> registered = null)
            where T : IDisposable
        {
            var x = Registry.GetOrAdd(name, _ => {
                var x = (T)factory();
                registered?.Invoke(x);
                return x;
            });     
            return (T)x;           
        }
    
        public static bool unregister(string name)
        {
            var result = Registry.TryRemove(name, out var disposable);
            if(result)
                disposable.Dispose();
            return result;                
        }   


        internal static void Dispose(IWfChannel channel)
        {
            sys.iter(Registry.Keys, name => {
                try
                {
                    Registry[name].Dispose();
                    channel.Babble($"Diposed application global: {name}");
                }
                catch(Exception e)
                {
                    channel.Warn(e.Message);
                }
            });
        }
    }
}