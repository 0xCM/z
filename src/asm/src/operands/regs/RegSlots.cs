//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public sealed class RegSlots
{
    readonly Seq<RegSlot> r64;

    readonly Seq<RegSlot> r512;

    public RegSlots(uint g = 16, int v = 32)
    {
        r64 = new RegSlot[g];
        r512 = new RegSlot[v];   
        Init();
    }

    void Init()
    {
        for(var i=z8i; i<r64.Count; i++)
            r64[i] = new (-1,NativeSize.W64);

        for(var i=z8i; i<r512.Count; i++)
            r64[i] = new (-1,NativeSize.W512);            
    }
    
    public RegSlot Rent(NativeSize size)
    {
        var slot = RegSlot.Empty;
        switch(size.Code)
        {
            case NativeSizeCode.W64:
            {
                for(var i=z8i; i<r64.Count; i++)
                {
                    slot = r64[i];
                    if(slot.Index < 0)
                    {
                        slot = new (i, slot.Size);
                        break;
                    }
                }
            }    
            break;
            case NativeSizeCode.W512:
            {
                for(var i=z8i; i<r512.Count; i++)
                {
                    slot = r512[i];
                    if(slot.Index < 0)
                    {
                        slot = new (i, slot.Size);
                        break;
                    }
                }
            }                
            break;
        }
        return slot;        
    }
    
    public void Return(RegSlot slot)
    {
        switch(slot.Size.Code)
        {
            case NativeSizeCode.W64:
                r64[slot.Index] = new (-1, slot.Size);
            break;
            case NativeSizeCode.W512:
                r512[slot.Index] = new (-1, slot.Size);
            break;
        }
    }
}
