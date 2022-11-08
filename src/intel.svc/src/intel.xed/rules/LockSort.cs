//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct LockSort : IComparable<LockSort>
        {
            readonly bit Lockable;

            readonly bit LockValue;

            [MethodImpl(Inline)]
            public LockSort(LockIndicator @lock)
            {
                Lockable = @lock.Lockable;
                LockValue = @lock.Locked;
            }

            [MethodImpl(Inline)]
            public LockSort(bit lockable, bit lockval)
            {
                Lockable = lockable;
                LockValue = lockval;
            }

            public int CompareTo(LockSort src)
            {
                var result = 0;
                if(!Lockable && !src.Lockable)
                    result = 0;
                else
                {
                    if(!Lockable)
                    {
                        if(src.Lockable)
                            result = -1;
                    }
                    else
                    {
                        if(Lockable && !src.Lockable)
                            result = 1;
                        else if(Lockable && src.Lockable)
                            result = ((byte)LockValue).CompareTo((byte)src.LockValue);
                    }
                }
                return result;
            }
        }
    }
}