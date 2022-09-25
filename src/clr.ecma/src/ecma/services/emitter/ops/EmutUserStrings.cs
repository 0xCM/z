//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitUserStrings(IApiPack dst)
            => EmitUserStrings(ApiMd.Parts, dst);

        public void EmitUserStrings(ReadOnlySeq<Assembly> src, IApiPack dst)
            => iter(src, a => EmitUserStrings(a, dst), PllExec);

        public void EmitUserStrings(Assembly src, IApiPack dst)
        {
            void Exec()
            {
                var reader = EcmaReader.create(src);
                TableEmit(reader.ReadUserStringInfo(), dst.Metadata(EcmaSections.UserStrings).PrefixedTable<EcmaStringDetail>(src.GetSimpleName()), UTF16);
            }

            Try(Exec);
        }

        public void EmitUserStrings(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitUserStrings(a, dst), PllExec);

        public void EmitUserStrings(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                var reader = EcmaReader.create(src);
                TableEmit(reader.ReadUserStringInfo(), dst.Path($"{src.GetSimpleName()}.ecma.strings.user", FileKind.Csv), UTF16);
            }
            Try(Exec);
        }
    }
}