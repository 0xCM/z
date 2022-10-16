//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextTemplateChecker
    {
        public Outcome Check1()
        {
            const string Pattern = "{0} {1} {2} {3}({4},{5});";
            var result = Outcome.Success;
            var template = TextTemplates.template(Pattern, "public", "static", "uint", "f", "x", "y");
            return result;
        }
    }
            
    public partial class TextTemplates
    {
        [MethodImpl(Inline), Op]
        public static ScriptTemplate script(string name, string content)
            => new ScriptTemplate(name, content);
    }
    
}