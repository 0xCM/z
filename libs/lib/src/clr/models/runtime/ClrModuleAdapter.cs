//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using R = System.Reflection;

    public readonly struct ClrModuleAdapter : IClrArtifact<ClrModuleAdapter>
    {
        readonly R.Module Definition;

        [MethodImpl(Inline)]
        public ClrModuleAdapter(R.Module src)
            => Definition = src;

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrArtifactKind Kind
        {
            [MethodImpl(Inline)]
            get => ClrArtifactKind.Module;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Definition.Name;
        }

        public string FullName
        {
            [MethodImpl(Inline)]
            get => Definition.FullyQualifiedName;
        }

        public string ScopeName
        {
            [MethodImpl(Inline)]
            get => Definition.ScopeName;
        }

        // public bool IsEmpty
        // {
        //     [MethodImpl(Inline)]
        //     get => Definition is null;
        // }

        // public bool IsNonEmpty
        // {
        //     [MethodImpl(Inline)]
        //     get => !IsEmpty;
        // }

        [MethodImpl(Inline)]
        public static implicit operator ClrModuleAdapter(R.Module src)
            => new ClrModuleAdapter(src);

        [MethodImpl(Inline)]
        public static implicit operator R.Module(ClrModuleAdapter src)
            => src.Definition;
    }
}