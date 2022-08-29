//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct WfStepId : IDataType<WfStepId>, IDataString
    {
        public readonly CliToken HostKey;

        public readonly string HostName;

        public readonly string HostIdentifier;

        [MethodImpl(Inline)]
        public WfStepId(string name)
        {
            HostName = name;
            HostKey = CliToken.Empty;
            HostIdentifier = HostName.Contains(Chars.Comma) && HostName.Contains(Chars.Dot) ? HostName.LeftOfFirst(Chars.Comma).RightOfLast(Chars.Dot) : HostName;
        }

        [MethodImpl(Inline)]
        public WfStepId(Type host)
        {
            HostName = host.AssemblyQualifiedName;
            HostKey = host.MetadataToken;
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
        public WfHostId Token
        {
            [MethodImpl(Inline)]
            get => WfHostId.create(this);
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
        public bool Equals(WfStepId src)
            => Token.Value == src.Token.Value;

        [MethodImpl(Inline)]
        public int CompareTo(WfStepId src)
            => HostName.CompareTo(src.HostName);

        [MethodImpl(Inline)]
        public string Format()
            => HostIdentifier;

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        public static WfStepId Empty
            => new WfStepId(typeof(void));

        [MethodImpl(Inline)]
        public static implicit operator WfStepId(Type control)
            => new WfStepId(control);

        public static implicit operator WfStepId(string name)
            => new WfStepId(name);
    }
}