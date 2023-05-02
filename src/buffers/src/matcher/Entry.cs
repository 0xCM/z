//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        public readonly struct Entry
        {
            public readonly uint Key;

            public readonly string Target;

            public readonly ushort Length;

            public readonly CharIndices Indices;

            [MethodImpl(Inline)]
            public Entry(uint key, string target, CharIndices indices, ushort length)
            {
                Key = key;
                Target = target;
                Indices = indices;
                Length = length;
            }

            public string Format()
                => string.Format("[{0}, {1}, {2}, <{3}>", Key, text.dquote(Target), Length, Indices);

            public override string ToString()
                => Format();
        }
    }
}