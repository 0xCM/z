//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaMethodImport : IComparable<EcmaMethodImport>
    {
        const string TableId = "methods.pinvokes";

        public EcmaMethodImport()
        {
            MethodName = EmptyString;
            DeclaringType = EmptyString;
            Library = EmptyString;
            TargetName = EmptyString;
            MethodSignature = new MethodSignature<string>();
        }

        public @string DeclaringType;

        public @string MethodName;

        public @string TargetName;

        public @string Library;

        public MethodSignature<string> MethodSignature;

        public override string ToString()
            => $"{Library}::{MethodName} -> ${TargetName}";

        public override int GetHashCode()
            => this.ToString().GetHashCode();

        public int CompareTo(EcmaMethodImport src)
        {
            var result = Library.CompareTo(src.Library);
            if(result == 0)
            {
                result = MethodName.CompareTo(src.MethodName);
                if(result == 0)
                    result = DeclaringType.CompareTo(src.DeclaringType);
            }
            return result;
        }
        public static EcmaMethodImport Empty => new();
    }
}