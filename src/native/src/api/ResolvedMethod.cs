//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedMethod : IComparable<ResolvedMethod>
    {
        public static string format(in ResolvedMethod src)
            => src.IsEmpty ? "<empty>"
            : string.Format("{0}::{1}:{2}:{3}",
                src.EntryPoint.Format(),
                src.Component.Format(),
                src.HostType.Format(),
                src.Method.DisplaySig()
            );

        public readonly OpUri Uri;

        public readonly MethodInfo Method;

        public readonly MemoryAddress EntryPoint;

        [MethodImpl(Inline)]
        public ResolvedMethod(MethodInfo method, OpUri uri, MemoryAddress address)
        {
            Uri = uri;
            Method = method;
            EntryPoint = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Method is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public Assembly Component
        {
            [MethodImpl(Inline)]
            get => HostType.Assembly;
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => Method.DeclaringType;
        }

        public string Format()
            => format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ResolvedMethod src)
            => EntryPoint.CompareTo(src.EntryPoint);

        // public ApiMemberInfo Describe()
        //     => describe(this);
    }
}