//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ResolvedMethods
    {
        Index<Element> Data;

        public static ResolvedMethods create(ReadOnlySpan<ResolvedMethod> src)
            => new ResolvedMethods(src);

        public ResolvedMethods(ReadOnlySpan<ResolvedMethod> src)
        {
            var count = src.Length;
            Data = alloc<Element>(count);
            ref var dst = ref Data.First;
            for(var i=0; i<count; i++)
                seek(dst,i) = new Element(skip(src,i));
            Data.Sort();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        internal ref readonly Element Lookup(uint index)
            => ref Data[index];

        public Contained this[uint index]
        {
            [MethodImpl(Inline)]
            get => new Contained(this,index);
        }

        public static explicit operator ResolvedMethods(ReadOnlySpan<ResolvedMethod> src)
            => create(src);

        public readonly struct Contained : IComparable<Contained>
        {
            readonly ResolvedMethods Container;

            readonly uint Index;

            [MethodImpl(Inline)]
            internal Contained(ResolvedMethods src, uint index)
            {
                Container = src;
                Index = index;
            }

            public string Description
            {
                [MethodImpl(Inline)]
                get => Container.Lookup(Index).Description;
            }

            public MemoryAddress Address
            {
                [MethodImpl(Inline)]
                get => Container.Lookup(Index).Address;
            }

            [MethodImpl(Inline), Ignore]
            public int CompareTo(Contained src)
                => Address.CompareTo(src.Address);

            [MethodImpl(Inline), Ignore]
            public string Format()
                => Description;

            public override string ToString()
                => Format();
        }

        internal struct Element : IComparable<Element>
        {
            public ResolvedMethod Method;

            public MemoryAddress Address
            {
                [MethodImpl(Inline)]
                get => Method.EntryPoint;
            }

            public ClrAssemblyName Component
            {
                [MethodImpl(Inline)]
                get => Method.Component;
            }

            public string Description
                => Method.Format();

            [MethodImpl(Inline)]
            public Element(ResolvedMethod method)
            {
                Method = method;
            }

            [MethodImpl(Inline)]
            public int CompareTo(Element src)
                => Address.CompareTo(src.Address);
        }
    }
}