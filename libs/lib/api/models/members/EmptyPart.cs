//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EmptyPart : PartId<EmptyPart> 
    {
        public EmptyPart()
            : base(PartId.None)
        {
            
        }
    }
}