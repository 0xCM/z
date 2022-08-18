//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrInstanceMethod : IEquatable<ClrInstanceMethod>, IComparable<ClrInstanceMethod>, ITextual, IRuntimeMethod
    {
        public object Host {get;}

        public MethodInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrInstanceMethod(object host, MethodInfo method)
        {
            Host = host;
            Definition = method;
        }

        public string HostedName
        {
            [MethodImpl(Inline)]
            get => Host.GetType().Name + "/" + Definition.Name;
        }

        public string Format()
            => HostedName;

        public int CompareTo(ClrInstanceMethod src)
            => HostedName.CompareTo(src.HostedName);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => HostedName.GetHashCode();

        public bool Equals(ClrInstanceMethod src)
            => HostedName.Equals(src.HostedName);

        public override bool Equals(object src)
            => src is ClrInstanceMethod m && Equals(m);

        [MethodImpl(Inline)]
        public static implicit operator ClrInstanceMethod((object host, MethodInfo method) src)
            => new ClrInstanceMethod(src.host, src.method);
    }
}