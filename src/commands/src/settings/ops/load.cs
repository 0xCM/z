//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Settings
    {
        public static Seq<Setting> load(FilePath src)
        {
            var data = src.ReadLines(true);
            var dst = sys.alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line, Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(sys.skip(parts,0)), text.trim(sys.skip(parts,1)));
            }

            return dst;
        }

    }
}