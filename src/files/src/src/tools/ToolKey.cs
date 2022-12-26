//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ToolKey(uint Seq, FileName Name) : IDataType<ToolKey>
    {
        public int CompareTo(ToolKey src)
        {
            if(Name == src.Name)
            {
                return Seq.CompareTo(src.Seq);
            }
            else
                return Name.CompareTo(src.Name);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | (Hash32)Seq;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(ToolKey src)
            => Name == src.Name && Seq == src.Seq;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public static ToolKey Empty => new(0,FileName.Empty);
    }
}