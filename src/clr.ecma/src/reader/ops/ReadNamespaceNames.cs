//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        public ReadOnlySeq<string> ReadNamespaceNames()
        {
            var src = TypeDefHandles();
            var dst = hashset<string>();
            iter(src, handle => {
                var def = MD.GetTypeDefinition(handle);
                if((def.Attributes & TypeAttributes.Public) == TypeAttributes.Public)
                {
                    var ns = String(def.Namespace);
                    if(nonempty(ns))
                        dst.Add(ns);
                }
            });

            return dst.Array().Sort();
        }
    }
}