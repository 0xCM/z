//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaEmitter
    {
        public void EmitMethodDefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMethodDefs(a, dst), PllExec);

        void EmitMethodDefs(Assembly src, IDbArchive dst)
        {
            void Exec()
            {
                var reader = EcmaReader.create(src);
                var buffer = list<EcmaMethodInfo>();
                reader.ReadMethodDefs(buffer);
                Channel.TableEmit(buffer.ViewDeposited(), dst.PrefixedTable<EcmaMethodInfo>(src.GetSimpleName()));
            }

            Try(Exec);
        }

        public void EmitMethodDefs(IEnumerable<AssemblyFile> src, IDbArchive dst)
            => iter(src, a => EmitMethodDefs(a, dst), PllExec);

        void EmitMethodDefs(AssemblyFile src, IDbArchive dst)
        {
            using var file = Ecma.file(src.Path);
            var reader = file.EcmaReader();
            var buffer = list<EcmaMethodInfo>();
            reader.ReadMethodDefs(buffer);
            Channel.TableEmit(buffer.ViewDeposited(), dst.PrefixedTable<EcmaMethodInfo>(src.AssemblyName));
        }
    }
}