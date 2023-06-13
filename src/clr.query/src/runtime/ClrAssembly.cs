//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct ClrAssembly : IRuntimeObject<ClrAssembly,Assembly>
    {
        /// <summary>
        /// Returns a <see cref='SegRef'/> to the cli metadata segment of the source
        /// </summary>
        /// <param name="src">The source assembly</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemorySegment metadata(Assembly src)
        {
            if(src.TryGetRawMetadata(out var ptr, out var len))
                return new MemorySegment(ptr,len);
            else
                return MemorySegment.Empty;
        }

        /// <summary>
        /// Returns a reference to the cli metadata for an assembly
        /// </summary>
        /// <param name="src">The source assembly</param>
        [Op]
        public static unsafe ReadOnlySpan<byte> metaspan(Assembly src, out ReadOnlySpan<byte> dst)
        {
            src.TryGetRawMetadata(out var ptr, out var size);
            dst = cover(ptr, size);
            return dst;
        }

        /// <summary>
        /// Returns a reference to the cli metadata for an assembly
        /// </summary>
        /// <param name="src">The source assembly</param>
        [Op]
        public static unsafe ReadOnlySpan<byte> metaspan(Assembly src)
        {
            src.TryGetRawMetadata(out var ptr, out var size);
            return cover(ptr, size);
        }

        public readonly Assembly Definition;

        [MethodImpl(Inline)]
        public ClrAssembly(Assembly src)
            => Definition = src;

        public ClrArtifactKind Kind
            => ClrArtifactKind.Assembly;

        public string SimpleName
        {
            [MethodImpl(Inline)]
            get => Definition.GetSimpleName();
        }

        public MemorySegment Metadata
        {
            [MethodImpl(Inline)]
            get => metadata(this);
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

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.ManifestModule.MetadataToken;
        }

        public ReadOnlySpan<byte> RawMetadata
        {
            [MethodImpl(Inline)]
            get => metaspan(Definition);
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