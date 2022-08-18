//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct JobType
    {
        public readonly asci16 Name;

        [MethodImpl(Inline)]
        public JobType(asci16 name)
        {
            Name = name;
        }

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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(JobType src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(JobType src)
            => Name.Equals(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator JobType(string name)
            => new JobType(name);

        [MethodImpl(Inline)]
        public static implicit operator JobType(asci16 name)
            => new JobType(name);
    }
}