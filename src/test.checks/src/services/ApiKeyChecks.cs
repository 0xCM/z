//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiKeyChecks : Checker<ApiKeyChecks>
    {
        const GenericStateKind ng = GenericStateKind.Nongeneric;

        const GenericStateKind g = GenericStateKind.OpenGeneric;

        [CmdOp("apikeys/check")]
        public void RunAll()
        {
            var kinds = Symbols.index<ApiClassKind>().View;
            var catalog = Wf.ApiCatalog;
            //var hosts = @readonly(catalog.ApiHosts);
            var parts = @readonly(catalog.Parts);
            var count = parts.Length;

            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts, i);

                // var hosted = ApiQuery.operators(host, n2, ng);
                // var opcount = hosted.Length;
                // var methods = hosted.View;

                // for(var j=0; j<opcount; j++)
                // {
                //     ref readonly var method = ref skip(methods,j);
                //     var @class = ApiQuery.apiclass(method);
                //     var key = ApiKeys.key(host.PartId, (ushort)host.HostType.MetadataToken, @class);
                //     var sig = method.Definition.DisplaySig();
                //     var output = string.Format("{0} | {1,-12} | {2}", ApiKeyFormats.bitfield(key), @class, sig);
                // }
            }
        }
    }
}