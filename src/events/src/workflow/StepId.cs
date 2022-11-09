//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct StepId : IDataType<StepId>, IDataString
    {
        public readonly uint HostKey;

        public readonly string HostName;

        public readonly string HostIdentifier;

        [MethodImpl(Inline)]
        public StepId(string name)
        {
            HostName = name;
            HostKey = 0;
            HostIdentifier = HostName.Contains(Chars.Comma) && HostName.Contains(Chars.Dot) ? HostName.LeftOfFirst(Chars.Comma).RightOfLast(Chars.Dot) : HostName;
        }

        [MethodImpl(Inline)]
        public StepId(Type host)
        {
            HostName = host.AssemblyQualifiedName;
            HostKey = (uint)host.MetadataToken;
            HostIdentifier = HostName.Contains(Chars.Comma) && HostName.Contains(Chars.Dot) ? HostName.LeftOfFirst(Chars.Comma).RightOfLast(Chars.Dot) : HostName;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(HostIdentifier);
        }

        /// <summary>
        /// The step token
        /// </summary>
        public HostId Token
        {
            [MethodImpl(Inline)]
            get => HostId.create(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(StepId src)
            => Token.Value == src.Token.Value;

        [MethodImpl(Inline)]
        public int CompareTo(StepId src)
            => HostName.CompareTo(src.HostName);

        [MethodImpl(Inline)]
        public string Format()
            => HostIdentifier;

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        public static StepId Empty
            => new StepId(typeof(void));

        [MethodImpl(Inline)]
        public static implicit operator StepId(Type control)
            => new StepId(control);

        public static implicit operator StepId(string name)
            => new StepId(name);
    }
}