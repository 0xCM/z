//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeOpMods;

    public readonly record struct NativeOpMod
    {
        readonly NativeOpMods Data;

        [MethodImpl(Inline)]
        public NativeOpMod(NativeOpMods src)
        {
            Data = src;
        }

        public bool IsPointer
        {
            [MethodImpl(Inline)]
            get => (Data & Pointer) != 0;
        }

        public bool IsConst
        {
            [MethodImpl(Inline)]
            get => (Data & Const) != 0;
        }

        public bool IsRef
        {
            [MethodImpl(Inline)]
            get => (Data & Ref) != 0;
        }

        public bool IsIn
        {
            [MethodImpl(Inline)]
            get => (Data & In) != 0;
        }

        public bool IsOut
        {
            [MethodImpl(Inline)]
            get => (Data & Out) != 0;
        }

        public bool IsConstPointer
        {
            [MethodImpl(Inline)]
            get => IsPointer && IsConst;
        }

        public bool IsRefPointer
        {
            [MethodImpl(Inline)]
            get => IsPointer && IsRef;
        }

        public bool IsOutPointer
        {
            [MethodImpl(Inline)]
            get => IsPointer && IsOut;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public override int GetHashCode()
            => (int)Data;

        [MethodImpl(Inline)]
        public bool Equals(NativeOpMod src)
            => Data == src.Data;

        public string Format()
            => Data.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeOpMod(NativeOpMods src)
            => new NativeOpMod(src);

        [MethodImpl(Inline)]
        public static implicit operator NativeOpMods(NativeOpMod src)
            => (NativeOpMods)src.Data;

        public static NativeOpMod Empty => default;
    }
}