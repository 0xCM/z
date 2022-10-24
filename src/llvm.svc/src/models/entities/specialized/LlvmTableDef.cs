//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class LlvmTableDef : Entity<string,RecordField>
    {
        public readonly LineRelations Def;

        public LlvmTableDef(LineRelations def, RecordField[] fields)
            : base(fields ?? sys.empty<RecordField>())
        {
            Def = def;
        }

        protected override Func<RecordField,string> KeyFunction
            => a => text.ifempty(a.Name,EmptyString);

        protected ref bit Parse(string attrib, out bit dst)
        {
            bit parse()
            {
                if(DataParser.parse(this[attrib], out bit data))
                    return data;
                else
                    return 0;
            }

            dst = Value(attrib, parse);

            return ref dst;
        }

        protected ref int Parse(string attrib, out int dst)
        {
            int parse()
            {
                if(DataParser.parse(this[attrib], out int data))
                    return data;
                else
                    return 0;
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref bits<N,T> Parse<N,T>(string attrib, out bits<N,T> dst)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            bits<N,T> parse()
            {
                if(BitParser.parse(this[attrib], out bits<N,T> b))
                    return b;
                else
                    return bits<N,T>.Zero;
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref list<string> Parse(string attrib, string type, out list<string> dst)
        {
            list<string> parse()
            {
                var result = LlvmTypes.parse(this[attrib], type, out var l);
                if(result)
                    return l;
                else
                    return list<string>.Empty;
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref dag<IExpr> Parse(string attrib, out dag<IExpr> dst)
        {
            dag<IExpr> parse()
            {
                var result = dag.parse(this[attrib], out var _dst);
                if(result)
                    return _dst;
                else
                    return new dag<IExpr>(@string.Empty, @string.Empty);
            }


            dst = Value(attrib, parse);
            return ref dst;
        }

        public Identifier EntityName
            => Def.Name;

        public Identifier ParentName
            => Def.ParentName;

        public new string this[string name]
            => text.ifempty(Attrib(name).Value, EmptyString);
    }
}