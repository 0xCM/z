//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [Op]
        public string String(UserStringHandle handle)
            => MD.GetUserString(handle);

        [Op]
        public string String(DocumentNameBlobHandle handle)
            => MD.GetString(handle);

        [Op]
        public string String(StringHandle handle)
            => MD.GetString(handle);
    }
}