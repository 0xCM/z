//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public readonly struct ClrAssembly : IRuntimeObject<ClrAssembly,Assembly>
    {
        public readonly Assembly Definition;

        [MethodImpl(Inline)]
        public ClrAssembly(Assembly src)
            => Definition = src;

        public ClrArtifactKind Kind
            => ClrArtifactKind.Assembly;

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Definition.Id();
        }

        public bool IsPart
        {
            [MethodImpl(Inline)]
            get => Definition.Id() != 0;
        }

        public string SimpleName
        {
            [MethodImpl(Inline)]
            get => Definition.GetSimpleName();
        }

        public MemorySeg Metadata
        {
            [MethodImpl(Inline)]
            get => Clr.metadata(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ClrAssemblyName Name
            => Definition;

        static ReadOnlySpan<ClrAssemblyName> references(Assembly src)
            => recover<AssemblyName, ClrAssemblyName>(src.GetReferencedAssemblies().ToSpan());

        public ReadOnlySpan<ClrAssemblyName> ReferencedAssemblies
            => references(Definition);

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.ManifestModule.MetadataToken;
        }

        public ReadOnlySpan<byte> RawMetadata
        {
            [MethodImpl(Inline)]
            get => Clr.metaspan(Definition);
        }

        string IClrArtifact.Name
            => Definition.FullName;

        Assembly IRuntimeObject<Assembly>.Definition
            => Definition;

        [MethodImpl(Inline)]
        public static implicit operator Assembly(ClrAssembly src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrAssembly(Assembly src)
            => new ClrAssembly(src);
    }
}