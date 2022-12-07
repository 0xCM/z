//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AssemblyRef : IAssemblyRef<AssemblyFile>, IDataType<AssemblyRef>
    {
        public readonly BinaryCode Token;

        public readonly AssemblyFile Source;

        public readonly AssemblyFile Target;

        [MethodImpl(Inline)]
        public AssemblyRef(BinaryCode token, AssemblyFile src, AssemblyFile dst)
        {
            Token = token;
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
            get => sys.hash(Format());
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AssemblyRef src)
            => Source == src.Source && Target == src.Target;

        public string Format()
            => $"{Source.Name} -> {Target.Name}";

        public override string ToString()
            => Format();

        public int CompareTo(AssemblyRef src)
        {
            var result = Source.CompareTo(src.Source);
            if(result == 0)
                result = Target.CompareTo(src.Target);
            return result;
        }

        AssemblyFile IArrow<AssemblyFile, AssemblyFile>.Source
            => Source;

        AssemblyFile IArrow<AssemblyFile, AssemblyFile>.Target
            => Target;

        public static AssemblyRef Empty => new AssemblyRef(BinaryCode.Empty, AssemblyFile.Empty,AssemblyFile.Empty);
    }
}