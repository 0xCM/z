//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MimeType
    {
        public @string BaseTypeName {get;}

        public @string SubtypeName {get;}

        [MethodImpl(Inline)]
        public MimeType(string @base, string subtype)
        {
            BaseTypeName = @base;
            SubtypeName = subtype;
        }

        public string Format()
            => string.Format("{0}/{1}", BaseTypeName, SubtypeName);

        public override string ToString()
            => Format();
    }
}