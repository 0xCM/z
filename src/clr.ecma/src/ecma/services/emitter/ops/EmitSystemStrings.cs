//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitSystemStrings(IApiPack dst)
            => EmitSystemStrings(ApiMd.Parts, dst);

        public void EmitSystemStrings(ReadOnlySeq<Assembly> src, IApiPack dst)
            => iter(src, a => EmitSystemStrings(a, dst), true);

        public void EmitSystemStrings(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var path = dst.Metadata(EcmaSections.SystemStrings).PrefixedTable<EcmaStringDetail>(src.GetSimpleName());
                using var reader = PeReader.create(FS.path(src.Location));
                TableEmit(reader.ReadSystemStringDetail(), path, UTF16);
            }
            Try(Exec);
        }

        public void EmitSystemStrings(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitSystemStrings(a, dst), PllExec);

        public void EmitSystemStrings(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                using var reader = PeReader.create(FS.path(src.Location));
                TableEmit(reader.ReadSystemStringDetail(), dst.Path($"{src.GetSimpleName()}.ecma.strings.system", FileKind.Csv), UTF16);
            }
            Try(Exec);
        }
    }
}