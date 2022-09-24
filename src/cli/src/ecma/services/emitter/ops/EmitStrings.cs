//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitStrings(IApiPack dst)
        {
            exec(true,
            () => EmitSystemStrings(dst),
            () => EmitUserStrings(dst)
            );
        }

        public void EmitUserStrings(IApiPack dst)
            => EmitUserStrings(ApiMd.Parts, dst);

        public void EmitUserStrings(ReadOnlySpan<Assembly> src, IApiPack dst)
            => iter(src, a => EmitUserStrings(a, dst), true);

        public void EmitUserStrings(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var reader = EcmaReader.create(src);
                TableEmit(reader.ReadUserStringDetail(), dst.Metadata(EcmaSections.UserStrings).PrefixedTable<CliString>(src.GetSimpleName()), UTF16);
            }

            Try(Exec);
        }

        public void EmitSystemStrings(IApiPack dst)
            => EmitSystemStrings(ApiMd.Parts, dst);

        public void EmitSystemStrings(ReadOnlySpan<Assembly> src, IApiPack dst)
            => iter(src, a => EmitSystemStrings(a, dst), true);

        public void EmitSystemStrings(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(EcmaSections.SystemStrings).PrefixedTable<CliString>(src.GetSimpleName());
                using var reader = PeReader.create(FS.path(src.Location));
                TableEmit(reader.ReadSystemStringDetail(), path, UTF16);
            }
            Try(Exec);
        }
    }
}