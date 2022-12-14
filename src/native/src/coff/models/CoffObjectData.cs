//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffObjectData : FileData<CoffObject>
    {
        public CoffObjectData(Dictionary<FilePath,CoffObject> src)
            : base(src)
        {

        }

        public static implicit operator CoffObjectData(Dictionary<FilePath,CoffObject> src)
            => new CoffObjectData(src);
    }
}