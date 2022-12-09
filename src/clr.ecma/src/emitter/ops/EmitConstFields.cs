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
        public void EmitConstFields(ReadOnlySeq<Assembly> src,  IDbArchive dst)
            => iter(src, c => EmitConstFields(c, dst), true);

        public void EmitConstFields(Assembly src, IDbArchive dst)
        {
            try
            {
                var counter = 0u;
                var target = dst.Metadata(EcmaSections.ConstFields).PrefixedTable<EcmaConstInfo>(src.GetSimpleName());
                var flow = EmittingTable<EcmaConstInfo>(target);
                var formatter = Tables.formatter<EcmaConstInfo>();
                using var writer = target.Writer();
                writer.WriteLine(formatter.FormatHeader());
                using var reader = PeReader.create(src.Path());
                var constants = reader.Constants(ref counter);
                var count = constants.Length;
                for(var i=0; i<count; i++)
                    writer.WriteLine(formatter.Format(skip(constants,i)));
                EmittedTable(flow, counter);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }
    }
}