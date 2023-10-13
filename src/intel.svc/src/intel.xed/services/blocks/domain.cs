//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static sys;

using N = XedZ.BlockFieldName;

partial class XedZ
{        
    public static BlockDomain domain(RuleBlocks src)
    {
        var imports = src.Imports;
        var domain = new BlockDomain();
        var counter = 0u;
        iter(imports, import => {                        
            var block = src.FormBlocks[import.Form];
            Require.notnull(block);
            if(parse(block, out List<RuleAttribute> rules))
            {
                foreach(var rule in rules)
                {
                    if(rule.IsNonEmpty)
                    {
                        if(parse(rule.Name, out N name))
                        {
                            var _rules = hashset<RuleAttribute>();
                            if(!domain.TryGetValue(name, out _rules))
                            {
                                _rules = hashset<RuleAttribute>();
                                domain[name] = _rules;
                            }

                            switch(name)
                            {
                                case N.attributes:
                                {
                                    if(parse(rule.Value, out InstAttribs value))          
                                    {
                                        domain.InstAttribs.AddRange(value);
                                    }   
                                }
                                break;
                                default:
                                    _rules.Add(rule);
                                break;
                            }                            
                        }

                    }
                }
                if(block.Count != rules.Count)
                    @throw("block.Count != _rules.Rules.Count");
            }
        });

        return domain;        
    }

}