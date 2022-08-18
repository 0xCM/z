//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_grid_writer : t_bits<t_grid_writer>
    {
        public void write_maps()
        {
            var outdir = UnitDataDir;
            var writer = GridWriter.Create();
            writer.Save(8, 1, 256, outdir);
            writer.Save(16,1, 256, outdir);
            writer.Save(32,1, 256, outdir);
            writer.Save(64,1, 256, outdir);
        }
    }
}