//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LiteralFields
    {
        public Index<FieldInfo> Defs {get;}

        public Index<string> Names {get;}

        public Index<object> Values {get;}

        [MethodImpl(Inline)]
        public LiteralFields(FieldInfo[] fields, Index<string> names, Index<object> values)
        {
            Defs = fields;
            Names = names;
            Values = values;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Defs.Length;
        }
    }
}