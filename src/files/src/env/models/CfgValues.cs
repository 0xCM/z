//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CfgValues 
    {
        public abstract record class CfgValue<V> : ICfgValue<V>
            where V : CfgValue<V>, new()
        {
            public abstract CfgValueKind ValueKind {get;}

            public virtual Fence<char> Fence => Fence<char>.Empty;

            public abstract bool IsEmpty {get;}

            public abstract Hash32 Hash {get;}

            public abstract bool Equals(V other);

            public abstract string Format();
        }

        public sealed record class CfgText : CfgValue<CfgText>
        {
            readonly @string Content;

            public CfgText()
            {
                Content = @string.Empty;
            }

            public CfgText(@string value)
            {
                Content = text.unfence(value,Fence);
            }

            public override Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Content.Hash;
            }

            public override int GetHashCode()
                => Hash;

            public override bool Equals(CfgText src)
                => Content == src.Content;

            public override CfgValueKind ValueKind 
                => CfgValueKind.Text;

            public override bool IsEmpty 
                => Content.IsEmpty;

            public override Fence<char> Fence 
                => (Chars.SQuote, Chars.SQuote);

            public override string Format()
                => text.fence(Content,Fence);

            public override string ToString()
                => Format();
        }

        public sealed record class CfgRecord : CfgValue<CfgRecord>
        {
            readonly Seq<ICfgEntry> Members;

            public CfgRecord()
            {
                Members = sys.empty<ICfgEntry>();
            }

            public override CfgValueKind ValueKind 
                => CfgValueKind.Record;

            public override Fence<char> Fence 
                => (Chars.LBrace, Chars.RBrace);

            public CfgRecord(ICfgEntry[] src) 
            {
                Members = src;
            }

            public ref ICfgEntry this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Members[i];
            }

            public override Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Members.Hash;
            }

            public ref ICfgEntry this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Members[i];
            }

            public override bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Members.IsEmpty;
            }

            public override string Format()
            {
                var dst = text.emitter(); 
                for(var i=0; i<Members.Count; i++)
                    dst.AppendLine(Members[i]);
                return text.fence(dst.Emit(), Fence);
            }

            public override bool Equals(CfgRecord src)
            {
                var result = Members.Count == src.Members.Count;
                if(result)
                {   
                    for(var i=0; i<Members.Count; i++)
                    {
                        result = this[i].Value.Equals(src[i]);
                        if(!result)
                            break;
                    }
                }

                return result;
            }

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => Hash;
        }        
    }
}