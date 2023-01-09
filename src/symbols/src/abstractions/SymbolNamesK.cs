//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SymbolNames<K>
        where K : unmanaged, Enum
    {
        readonly ReadOnlySeq<FieldInfo> Fields;

        readonly ConcurrentDictionary<K,string> Expressions;

        readonly ConcurrentDictionary<K,string> Names;

        readonly ConcurrentDictionary<string,K> ExprKinds;

        readonly ConcurrentDictionary<string,K> NameKinds;

        readonly ReadOnlySeq<K> FieldKind;

        readonly ReadOnlySeq<ulong> FieldValues;

        public readonly ClrIntegerKind SymValueKind;

        protected SymbolNames()
        {
            Fields = typeof(K).LiteralFields().ToSeq();
            var count = Fields.Length;
            Expressions = new (1,count);
            Names = new (1,count);
            ExprKinds = new (1,count);
            NameKinds = new (1,count);
            FieldKind = sys.alloc<K>(count);
            FieldValues = sys.alloc<ulong>(count);
            
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref Fields[i];
                var symbol = SymbolAttribute.symbol(field);
                var value = field.GetRawConstantValue();                
            }

        }

    }
    public abstract class SymbolNames<S,K> : SymbolNames<K>
        where S : SymbolNames<S,K>, new()
        where K : unmanaged, Enum
    {

    }
}