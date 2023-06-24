//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

public readonly struct XedLockSort : IComparable<XedLockSort>
{
    readonly bit Lockable;

    readonly bit LockValue;

    [MethodImpl(Inline)]
    public XedLockSort(LockIndicator @lock)
    {
        Lockable = @lock.Lockable;
        LockValue = @lock.Locked;
    }

    [MethodImpl(Inline)]
    public XedLockSort(bit lockable, bit lockval)
    {
        Lockable = lockable;
        LockValue = lockval;
    }

    public int CompareTo(XedLockSort src)
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
