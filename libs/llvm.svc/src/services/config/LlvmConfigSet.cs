//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using K = llvm.LlvmConfigKind;

    public class LlvmConfigSet
    {
        readonly Dictionary<K,dynamic> Data;

        public LlvmConfigSet()
        {
            Data = new();
        }

        public void Set<T>(K key, T value)
        {
            Data[key] = value;
        }

        public bool Get<T>(K key, out T value)
        {
            var result = false;
            value = default;
            try
            {
                if(Data.TryGetValue(key, out var v))
                {
                    value = (T)v;
                    result = true;
                }
            }
            catch(Exception)
            {
            }
            return result;
        }

        public bool BinDir(out FS.FolderPath dst)
            => Get(K.BinDir, out dst);

        public bool LibDir(out FS.FolderPath dst)
            => Get(K.LibDir, out dst);

        public IReadOnlyCollection<KeyValuePair<K, dynamic>> Items
            => Data;
    }
}