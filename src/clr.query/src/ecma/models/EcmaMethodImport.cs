//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaMethodImport : IComparable<EcmaMethodImport>
    {
        const string TableId = "ecma.methods.imports";

        public EcmaMethodImport()
        {
            Name = EmptyString;
            DeclaringType = EmptyString;
            Library = EmptyString;
            MethodSignature = new MethodSignature<string>();
        }

        public string DeclaringType;

        public string Name;

        public string Library;

        public MethodSignature<string> MethodSignature;

        public override string ToString()
            => $"{Library}::{Name}";

        public override int GetHashCode()
            => this.ToString().GetHashCode();

        public int CompareTo(EcmaMethodImport src)
        {
            var result = Library.CompareTo(src.Library);
            if(result == 0)
            {
                result = Name.CompareTo(src.Name);
                if(result == 0)
                    result = DeclaringType.CompareTo(src.DeclaringType);
            }
            return result;
        }
        public static EcmaMethodImport Empty => new();
    }
}