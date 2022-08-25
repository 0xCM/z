//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ClrAssemblyNames;

    public sealed record class ClrAssemblyName : IDataType<ClrAssemblyName>
    {
        public readonly FileUri CodeBase;

        public readonly string FullName;

        public readonly string SimpleName;

        public readonly AssemblyVersion Version;

        ClrAssemblyName()
        {
            CodeBase = FS.FilePath.Empty;
            FullName = EmptyString;
            SimpleName = EmptyString;
            Version = default;
        }

        [MethodImpl(Inline)]
        public ClrAssemblyName(AssemblyName src)
        {
            CodeBase = FS.path(src.CodeBase ?? EmptyString);
            FullName = src.FullName;
            SimpleName = src.SimpleName();
            Version = api.version(src);
        }

        [MethodImpl(Inline)]
        public ClrAssemblyName(Assembly src)
        {
            CodeBase = FS.path(src.GetName().CodeBase ?? EmptyString);
            FullName = src.GetName().FullName;
            SimpleName = src.GetName().SimpleName();
            Version = api.version(src.GetName());
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(FullName);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => SimpleName;

        public override string ToString()
            => Format();

        public int CompareTo(ClrAssemblyName src)
            => FullName.CompareTo(src.FullName);

        [MethodImpl(Inline)]
        public string Format(AssemblyNameKind kind)
            => api.format(this, kind);

        public bool Equals(ClrAssemblyName src)
            => FullName.Equals(src.FullName);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(FullName);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(FullName);
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrAssemblyName(AssemblyName src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrAssemblyName(Assembly src)
            => new ClrAssemblyName(src);

        public static ClrAssemblyName Empty
        {
            [MethodImpl(Inline)]
            get => new ClrAssemblyName();
        }
    }
}