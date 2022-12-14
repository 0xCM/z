//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public class RuleTableDeps
        {
            public static Index<FieldUsage> fields(CellTables src)
            {
                var buffer = sys.bag<FieldUsage>();
                iter(src.View, table => collect(table,buffer),true);
                return buffer.Index().Sort();
            }

            static void collect(in CellTable src, ConcurrentBag<FieldUsage> dst)
            {
                ref readonly var rows = ref src.Rows;
                var usage = hashset<FieldUsage>();
                var sig = src.Sig;
                for(var i=0; i<rows.Count; i++)
                {
                    ref readonly var row = ref rows[i];
                    var antecedants = row.Antecedants();
                    for(var j=0; j<antecedants.Length; j++)
                    {
                        ref readonly var antecedant = ref skip(antecedants,j);
                        if(antecedant.Field != 0)
                            usage.Add(FieldUsage.left(sig, antecedant.Field));
                    }

                    var consequents = row.Consequents();
                    for(var j=0; j<consequents.Length; j++)
                    {
                        ref readonly var consequent = ref skip(consequents,j);
                        if(consequent.Field != 0)
                            usage.Add(FieldUsage.right(sig, consequent.Field));
                    }
                }

                iter(usage, u => dst.Add(u));
            }
        }
    }
}