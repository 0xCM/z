//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ObjSymCode;
    using static ObjSymKind;

    [ApiHost]
    public readonly record struct ObjSymCalcs
    {
        [Op]
        public static ObjSymKind kind(ObjSymCode code)
        {
            var kind = ObjSymKind.None;
            switch(code)
            {
                case a:
                case A:
                    kind = AbsoluteSymbol;
                break;
                case b:
                    kind = BssSection;
                break;
                case B:
                    kind = BssObject;
                break;
                case C:
                    kind = Common;
                break;
                case d:
                    kind = DataSection;
                break;
                case D:
                    kind = DataObject;
                break;
                case i:
                case l:
                case n:
                    kind = CoffDebugSymbol;
                break;

                case s:
                case S:
                    kind = DebugSymbol;
                break;
                case r:
                    kind = ReadOnlyDataSection;
                break;
                case R:
                    kind = ReadOnlyDataObject;
                break;
                case t:
                    kind = CodeSection;
                break;
                case T:
                    kind = CodeObject;
                break;
                case U:
                    kind = UndefinedSymbol;
                break;
                case V:
                case v:
                case w:
                case W:
                case N_STAB:
                    kind = Other;
                break;
            }
            return kind;
        }
    }
}