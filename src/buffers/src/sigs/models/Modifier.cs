//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static NativeSigs.ModifierKind;

partial class NativeSigs
{
    public readonly record struct Modifier
    {
        readonly ModifierKind Kind;

        [MethodImpl(Inline)]
        public Modifier(ModifierKind src)
        {
            Kind = src;
        }

        public bool IsPointer
        {
            [MethodImpl(Inline)]
            get => (Kind & Pointer) != 0;
        }

        public bool IsConst
        {
            [MethodImpl(Inline)]
            get => (Kind & Const) != 0;
        }

        public bool IsRef
        {
            [MethodImpl(Inline)]
            get => (Kind & Ref) != 0;
        }

        public bool IsIn
        {
            [MethodImpl(Inline)]
            get => (Kind & In) != 0;
        }

        public bool IsOut
        {
            [MethodImpl(Inline)]
            get => (Kind & Out) != 0;
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
            get => Kind == 0;
        }

        public override int GetHashCode()
            => (int)Kind;

        [MethodImpl(Inline)]
        public bool Equals(Modifier src)
            => Kind == src.Kind;

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Modifier(ModifierKind src)
            => new Modifier(src);

        [MethodImpl(Inline)]
        public static implicit operator ModifierKind(Modifier src)
            => src.Kind;

        public static Modifier Empty => default;
    }       
}

