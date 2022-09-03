//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AssemblyRef : IAssemblyRef<ClrAssemblyName>, IDataType<AssemblyRef>
    {
        public readonly ClrAssemblyName Source;

        public readonly ClrAssemblyName Target;

        [MethodImpl(Inline)]
        public AssemblyRef(ClrAssemblyName src, ClrAssemblyName dst)
        {
            Source = src;
            Target = dst;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty || Target.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty && Target.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Format());
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AssemblyRef src)
            => Source == src.Source && Target == src.Target;

        public string Format()
            => $"{Source.SimpleName} -> {Target.SimpleName}";

        public override string ToString()
            => Format();

        public int CompareTo(AssemblyRef src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = Target.CompareTo(src.Target);
            return result;
        }

        ClrAssemblyName IArrow<ClrAssemblyName, ClrAssemblyName>.Source
            => Source;

        ClrAssemblyName IArrow<ClrAssemblyName, ClrAssemblyName>.Target
            => Target;

        public static AssemblyRef Empty => new AssemblyRef(ClrAssemblyName.Empty,ClrAssemblyName.Empty);
    }
}