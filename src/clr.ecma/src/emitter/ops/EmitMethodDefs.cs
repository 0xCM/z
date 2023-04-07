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
                Channel.TableEmit(reader.ReadMethodInfo(), dst.PrefixedTable<EcmaMethodInfo>(src.GetSimpleName()));
            }

            Try(Exec);
        }

        // public void EmitMethodInfo(IEnumerable<AssemblyFile> src, IDbArchive dst)
        //     => iter(src, a => EmitMethodInfo(a, dst), PllExec);

        // void EmitMethodInfo(AssemblyFile src, IDbArchive dst)
        // {
        //     using var file = Ecma.file(src.Path);
        //     var reader = file.EcmaReader();
        //     var buffer = list<EcmaMethodInfo>();
        //     Channel.TableEmit(reader.ReadMethodInfo(), dst.PrefixedTable<EcmaMethodInfo>(src.AssemblyName.Format()));
        // }
    }
}