//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IDivisionRing<T> : IRing<T>, IDivisive<T>, IReciprocative<T>
            where T : unmanaged
        {

        }
    }
}