//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    [ApiHost]
    public class Const
    {
        public static ConstGroup group(@string name, @string spec)
            => new ConstGroup(name,spec);
        
        public static Const<string> define(@string name, uint ordinal, string value, @string? description = null)
            => new(name,ordinal,value,description);

        public static Const<char> define(@string name, uint ordinal, char value, @string? description = null)
            => new(name,ordinal,value,description);

        public static Const<uint> define(@string name, uint ordinal, byte value, @string? description = null)
            => new(name,ordinal,value,description);

        public static Const<ushort> define(@string name, uint ordinal, ushort value, @string? description = null)
            => new(name, ordinal, value, description);

        public static Const<uint> define(@string name, uint ordinal, uint value, @string? description = null)
            => new(name, ordinal, value, description);

        public static Const<ulong> define(@string name, uint ordinal, ulong value, @string? description = null)
            => new(name, ordinal, value, description);

        public static Const<sbyte> define(@string name, uint ordinal, sbyte value, @string? description = null)
            => new(name,ordinal,value,description);

        public static Const<short> define(@string name, uint ordinal, short value, @string? description = null)
            => new(name, ordinal, value, description);

        public static Const<int> define(@string name, uint ordinal, int value, @string? description = null)
            => new(name, ordinal, value, description);

        public static Const<long> define(@string name, uint ordinal, long value, @string? description = null)
            => new(name, ordinal, value, description);
    }
}