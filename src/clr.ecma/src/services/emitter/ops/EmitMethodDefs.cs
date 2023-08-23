//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaEmitter
    {
        public void EmitMethodDefs(ReadOnlySeq<Assembly> src, IDbArchive dst)
            => iter(src, a => EmitMethodDefs(a.GetAssemblyFile(), dst), PllExec);

        void EmitMethodDefs(AssemblyFile src, IDbArchive dst)
        {
            void Exec()
            {
                using var file = Ecma.file(src.Path);
                var reader = file.EcmaReader();
                Channel.TableEmit(reader.ReadMethodDefs().Array().Sort(), dst.PrefixedTable<EcmaMethodInfo>(src.AssemblyName.Name));
            }

            Try(Exec);
        }
    }
}