//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ImmOpRange
    {
        readonly Imm Min;

        readonly Imm Max;

        Imm Current;

        [MethodImpl(Inline)]
        public ImmOpRange(Imm min, Imm max)
        {
            Min = min;
            Max = max;
            Current = min;
        }

        [MethodImpl(Inline)]
        public Imm Next()
        {
            Next(out var dst);
            return dst;
        }

        [MethodImpl(Inline)]
        public bool Next(out Imm dst)
        {
            if(Current < Max)
            {
                dst = Current++;
                return true;
            }
            else
            {
                dst = Imm.Empty;
                return false;
            }
        }

    }
}