//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct EcmaMethodImport
    {
        const string TableId = "ecma.methods.imports";

        public EcmaMethodImport()
        {
            Name = EmptyString;
            DeclaringType = EmptyString;
            Dll = EmptyString;
            MethodSignature = new MethodSignature<string>();
        }

        public string DeclaringType;

        public string Name;

        public string Dll;

        public MethodSignature<string> MethodSignature;

        public override string ToString()
            => $"{this.Name}({this.Dll})";

        public override int GetHashCode()
            => this.ToString().GetHashCode();

        public static EcmaMethodImport Empty => new();
    }
}