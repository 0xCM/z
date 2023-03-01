//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EcmaMethodImport
    {
        public EcmaMethodImport(string name, string dll, string declaringType, MethodSignature<string> methodSignature)
        {
            this.Name = name;
            this.Dll = dll;
            this.DeclaringType = declaringType;
            this.MethodSignature = methodSignature;
        }

        public string DeclaringType { get; private set; }

        public string Name { get; private set; }

        public string Dll { get; private set; }

        public MethodSignature<string> MethodSignature { get; }

        public override string ToString()
        {
            return $"{this.Name}({this.Dll})";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}