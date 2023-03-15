//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class ScriptVars : IIndex<CmdVar>
    {
        const NumericKind Closure = UnsignedInts;

        readonly Index<CmdVar> Data;

        [MethodImpl(Inline)]
        public ScriptVars(CmdVar[] src)
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
                if(item.Value(out var value))
                if(item.IsNonEmpty)
                    dst.AppendLineFormat("set {0}={1}", item.VarName, value);
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ScriptVars(CmdVar[] src)
            => new ScriptVars(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar[](ScriptVars src)
            => src.Data;

        public static ScriptVars Empty
        {
            [MethodImpl(Inline)]
            get => sys.array<CmdVar>();
        }
    }
}