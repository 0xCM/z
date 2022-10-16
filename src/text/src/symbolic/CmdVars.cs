//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CmdVars : IIndex<CmdVar>
    {

        public static CmdVar<K> var<K>(string name, K kind, string value)
            where K : unmanaged
                => new CmdVar<K>(name,kind,value);

        public static CmdVar<K,T> var<K,T>(string name, K kind, T value)
            where K : unmanaged
                => new CmdVar<K,T>(name, kind, value);

        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(string name)
            => new CmdScriptVar(name);

        [MethodImpl(Inline), Op]
        public static CmdVar var(string name, string value)
            => new CmdVar(name, value);

        [MethodImpl(Inline), Op]
        public static CmdVar var(string name, object value)
            => new CmdVar(name, value);

        [Op]
        public static CmdVars create()
            => new CmdVar[255];

        [Op]
        public static CmdVars create(ushort count)
            => new CmdVar[count];

        public static CmdVars load(params Pair<string>[] src)
        {
            var dst = new CmdVar[src.Length];
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = skip(src,i);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static CmdVars load(CmdVar[] src)
            => src;

        readonly Index<CmdVar> Data;

        [MethodImpl(Inline)]
        public CmdVars(CmdVar[] src)
        {
            Data = src;
        }

        public uint NonEmptyCount()
            => Data.Where(x => x.IsNonEmpty).Count;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref CmdVar this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref CmdVar this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public CmdVar[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = Data.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref this[i];
                if(item.IsNonEmpty)
                    dst.AppendLineFormat("set {0}={1}", item.Name, item.Value);
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVars(CmdVar[] src)
            => new CmdVars(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar[](CmdVars src)
            => src.Data;

        public static CmdVars Empty
        {
            [MethodImpl(Inline)]
            get => sys.array<CmdVar>();
        }
    }
}