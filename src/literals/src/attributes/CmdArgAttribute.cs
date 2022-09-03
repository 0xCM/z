//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class CmdArgAttribute : Attribute
    {
        public CmdArgAttribute(string expr, int @default = 0)
        {
            Expression = expr;
        }

        public CmdArgAttribute()
        {
            Expression = string.Empty;
        }


        public string Expression {get;}

        public virtual bool IsFlag {get;}
    }
}