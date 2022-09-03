//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Rules;

    public sealed class TextMap : Rule
    {
        ConstLookup<string,string> Data;

        Index<IProduction> _Productions;

        internal TextMap(ConstLookup<string,string> src, IProduction[] productions)
        {
            Data = src;
            _Productions = productions;
        }

        public ReadOnlySpan<IProduction> Productions
        {
            [MethodImpl(Inline)]
            get => _Productions;
        }

        public string Apply(string src)
        {
            if(Data.Find(src, out var dst))
                return dst;
            else
                return src;
        }

        public override string Format()
        {
            var dst = text.buffer();
            var count = _Productions.Count;
            for(var i=0; i<count; i++)
            {
                dst.AppendLine(_Productions[i].Format());
            }
            return dst.Emit();
        }
    }
}