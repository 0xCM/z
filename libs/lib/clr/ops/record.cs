//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ClrFieldRecord record(FieldInfo src)
        {
            var data = adapt(src);
            var dst = new ClrFieldRecord();
            dst.Key = ClrArtifacts.reference(src);
            dst.DeclaringType = data.DeclaringType.Token;
            dst.CilType = data.FieldType.Token;
            dst.Attributes = data.Attributes;
            dst.Address = data.Address;
            dst.IsStatic = data.IsStatic;
            return dst;
        }
    }
}