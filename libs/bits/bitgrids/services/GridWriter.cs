//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct GridWriter
    {
        public static GridWriter Create()
            => default(GridWriter);

        public void Save(int segwidth, int kMinSegs, int mkMaxSgs, FS.FolderPath dst)
        {
            var filename = FS.file($"GridMap{segwidth}.csv");
            var dstpath = dst + filename;
            Save(segwidth,kMinSegs,mkMaxSgs, dstpath);
        }

        public void Save(int segwidth, int kMinSegs, int mkMaxSgs, FS.FilePath path)
        {
            using var writer = path.Writer();
            var buffer = text.buffer();
            GridFormatter.render(segwidth,kMinSegs,mkMaxSgs,buffer);
            writer.Write(buffer.Emit());
        }
    }
}