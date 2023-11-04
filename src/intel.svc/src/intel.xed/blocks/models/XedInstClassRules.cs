//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using static XedRules;

public class XedInstClassRules
{
    public static bool rules(MachineMode mode, XedInstForm form, out HashSet<InstBlockPattern> dst)
    {
        if(Instance.FormRules.TryGetValue(form, out dst))
        {
            if(dst.Count > 1)
            {
                var narrowed = hashset<InstBlockPattern>();
                foreach(var pattern in dst)
                {
                    if(pattern.Mode == MachineMode.Not64)
                        continue;

                    if(mode == MachineMode.Mode64)
                    {
                        if(pattern.Mode == MachineMode.Mode32x64 || pattern.Mode == MachineMode.Mode64)
                        {
                            narrowed.Add(pattern);
                        }
                    }
                }
                dst = narrowed;
            }
        }
        return dst.Count != 0;
    }

    public static bool rules(XedInstClass @class, out HashSet<InstBlockPattern> dst)
        => Instance.ClassRules.TryGetValue(@class, out dst);

    public static IEnumerable<XedInstForm> forms()
        => Instance.FormRules.Keys;
        
    static readonly XedInstClassRules Instance;

    readonly InstructionRules Rules;
    
    readonly Dictionary<XedInstForm,XedInstClass> FormClasses;

    readonly ReadOnlySeq<FormImport> FormImports;

    readonly Dictionary<XedInstClass,HashSet<InstBlockPattern>> ClassRules;

    readonly Dictionary<XedInstForm, HashSet<InstBlockPattern>> FormRules;

    XedInstClassRules()
    {
        Rules = XedTables.Instructions();
        FormClasses = new();
        FormImports = XedTables.FormImports();
        ClassRules = new();
        FormRules = new();
        var classes = FormImports.Map(x => x.InstClass).ToHashSet();
        foreach(var @class in classes)
            ClassRules[@class] = new();

        foreach(var form in FormImports)
            FormClasses.TryAdd(form.InstForm,form.InstClass);

        foreach(var pattern in Rules.Patterns.View)
        {
            
            if(FormRules.ContainsKey(pattern.Form))
                FormRules[pattern.Form].Add(pattern);
            else
                FormRules[pattern.Form] = hashset(pattern);
            if(FormClasses.TryGetValue(pattern.Form, out var @class))
            {
                ClassRules[@class].Add(pattern);
            }
        }
    }

    static XedInstClassRules()
    {
        Instance = new();
    }
}
