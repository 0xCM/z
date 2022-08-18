//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class HexFileData : FileData<Index<HexDataRow>>
    {
        public HexFileData(Dictionary<FS.FilePath,Index<HexDataRow>> src)
            : base(src)
        {

        }

        public static implicit operator HexFileData(Dictionary<FS.FilePath,Index<HexDataRow>> src)
            => new HexFileData(src);
    }
}