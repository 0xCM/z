//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ToolKey : IDataType<ToolKey>
    {
        public readonly FilePath Path;

        public readonly uint Seq;

        public ToolKey(uint seq, FilePath path)
        {
            Seq = seq;
            Path = path;
        }

        public FileName Name 
            => Path.FileName;

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

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
 
        public int CompareTo(ToolKey src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                result = Seq.CompareTo(src.Seq);
            return result;
        }

        public static ToolKey Empty => new(0,FilePath.Empty);
    }
}