//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    class ObjCmd : WfAppCmd<ObjCmd>
    {
        [CmdOp("obj/sections")]
        void ObjSections(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var index = FS.index(Archives.modules(src).Files());


            var objects = from entry in index.Distinct() select CoffObjects.@object(entry.Path);
            iter(objects, obj => {

                Channel.Row(obj.Header);

            });
            // iter(CoffObjects.sections(Channel, objects), headers => {
            //         iter(headers, header => {
            //             Channel.Row($"{headers.ObjectPath.Format().PadRight(120)} | {header.Name}");
            //         });
            // });

        }

    }
}