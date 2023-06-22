//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffSectionHeaders : ReadOnlySeq<CoffSectionHeaders,CoffSectionHeader>
    {
        public readonly FilePath ObjectPath;

        public CoffSectionHeaders()
        {
            ObjectPath = FilePath.Empty;
        }

        public CoffSectionHeaders(FilePath image, CoffSectionHeader[] src)
            : base(src)
        {

        }
    }
}