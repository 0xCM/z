//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffObjectIndex : FileData<CoffObjectData>
    {
        public CoffObjectIndex(Dictionary<FilePath,CoffObjectData> src)
            : base(src)
        {

        }

        public static implicit operator CoffObjectIndex(Dictionary<FilePath,CoffObjectData> src)
            => new CoffObjectIndex(src);
    }
}