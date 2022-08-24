//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class CliEmitter
    {
        public void EmitStrings(IApiPack dst)
        {
            exec(true,
            () => EmitSystemStrings(dst),
            () => EmitUserStrings(dst)
            );
        }

        public void EmitUserStrings(IApiPack dst)
            => EmitUserStrings(ApiMd.Assemblies, dst);

        public void EmitUserStrings(ReadOnlySpan<Assembly> src, IApiPack dst)
            => iter(src, a => EmitUserStrings(a, dst), true);

        public void EmitUserStrings(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var reader = CliReader.create(src);
                TableEmit(reader.ReadUserStringDetail(), dst.Metadata(CliSections.UserStrings).PrefixedTable<CliString>(src.GetSimpleName()), UTF16);
            }

            Try(Exec);
        }

        public void EmitSystemStrings(IApiPack dst)
            => EmitSystemStrings(ApiMd.Assemblies, dst);

        public void EmitSystemStrings(ReadOnlySpan<Assembly> src, IApiPack dst)
            => iter(src, a => EmitSystemStrings(a, dst), true);

        public void EmitSystemStrings(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(CliSections.SystemStrings).PrefixedTable<CliString>(src.GetSimpleName());
                using var reader = PeReader.create(FS.path(src.Location));
                TableEmit(reader.ReadSystemStringDetail(), path, UTF16);
            }
            Try(Exec);
        }
    }
}