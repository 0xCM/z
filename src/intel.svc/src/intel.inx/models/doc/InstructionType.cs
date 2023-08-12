//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntrinsicsDoc
{
    public readonly record struct InstructionType : IComparable<InstructionType>
    {
        public const string ElementType = "type";

        public readonly @string Content;

        [MethodImpl(Inline)]
        public InstructionType(string src)
        {
            Content = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.GetHashCode();
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(InstructionType src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(InstructionType src)
            => Content == src.Content;

        public string Format()
            => Content;

        public override string ToString()
            => Content;

        [MethodImpl(Inline)]
        public static implicit operator InstructionType(string src)
            => new InstructionType(src);
    }
}
