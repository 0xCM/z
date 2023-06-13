//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MsgOps;

    public readonly struct PropFormat : ITextual
    {
        public string Name {get;}

        public dynamic Value {get;}

        public sbyte Pad {get;}

        [MethodImpl(Inline)]
        public PropFormat(string name, dynamic value, sbyte pad)
        {
            Name = name;
            Value = value;
            Pad = pad;
        }

        public string Format(char sep)
            => string.Format("{0}{1}{2}",
                string.Format(api.pad(Pad), Name),
                string.Format("{0} ", sep),
                    Value);

        public string Format()
            => Format(RP.PropertySep);

        public override string ToString()
            => Format();
    }
}