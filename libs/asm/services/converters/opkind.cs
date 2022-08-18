//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct IceConverters
    {
     	/// <summary>
		/// Gets an operand's kind if it exists
		/// </summary>
		/// <param name="index">Operand number, 0-4</param>
        [MethodImpl(Inline), Op]
		public static IceOpKind opkind(in IceInstruction src, byte index)
        {
            if(index == 0)
                return src.Op0Kind;
            else if(index == 1)
                return src.Op1Kind;
            else if(index == 2)
                return src.Op2Kind;
            else if(index == 3)
                return src.Op3Kind;
            else if(index == 4)
                return src.Op4Kind;
            else
                return 0;
		}
    }
}