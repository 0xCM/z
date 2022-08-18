//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a parametrically-identified clr type
    /// </summary>
    public readonly struct ClrTypeAdapter<T> : IRuntimeType<T>
    {
        static readonly Type TD = typeof(T);

        public Type Definition => TD;

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrTypeAdapter Untyped
        {
            [MethodImpl(Inline)]
            get => Definition;
        }

        public ReadOnlySpan<ClrTypeAdapter> NestedTypes
        {
            [MethodImpl(Inline)]
            get => Untyped.NestedTypes;
        }

        public ClrArtifactKind Kind
            => (ClrArtifactKind)Definition.Kind();

        string IClrArtifact.Name
            => Definition.Name;

        [MethodImpl(Inline)]
        public string Format()
            => Definition.FullName;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrTypeAdapter(ClrTypeAdapter<T> src)
            => src.Untyped;

        [MethodImpl(Inline)]
        public static implicit operator Type(ClrTypeAdapter<T> src)
            => src.Definition;
    }
}