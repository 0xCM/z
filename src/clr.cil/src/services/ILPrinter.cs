// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil;

using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Linq.Expressions;

using Z0;

public static class ILPrinter
{
    static CachedTypeFactory s_typeFactory = new CachedTypeFactory(typeof(IStrongBox), typeof(StrongBox<>));

    public static string GetIL(this MethodInfo method)
    {
        CultureInfo oldCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        try
        {
            var sw = new StringWriter();
            var typeFactory = s_typeFactory;
            AppendIL(method, sw, typeFactory);
            return sw.ToString();
        }
        catch(Exception e)
        {
            return e.ToString();
        }
        finally
        {
            CultureInfo.CurrentCulture = oldCulture;
        }
    }

    public static string GetIL(this Delegate d)
        => d.GetMethodInfo().GetIL();

    public static string GetIL(this LambdaExpression expression, bool appendInnerLambdas = false)
    {
        Delegate d = expression.Compile();

        MethodInfo method = d.GetMethodInfo();
        ICilTypeFactory typeFactory = GetTypeFactory(expression);

        CultureInfo oldCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        try
        {
            var sw = new StringWriter();

            AppendIL(method, sw, typeFactory);

            if(appendInnerLambdas)
            {
                var closure = (Closure)d.Target;

                int i = 0;
                foreach (object constant in closure.Constants)
                {
                    var innerMethod = constant as DynamicMethod;
                    if (innerMethod != null)
                    {
                        sw.WriteLine();
                        sw.WriteLine("// closure.Constants[" + i + "]");
                        AppendIL(innerMethod, sw, typeFactory);
                    }

                    i++;
                }
            }

            return sw.ToString();
        }
        finally
        {
            CultureInfo.CurrentCulture = oldCulture;
        }
    }

    static ICilTypeFactory GetTypeFactory(Expression src)
    {
        s_typeFactory.AddTypesFrom(src);
        return s_typeFactory;
    }

    static void AppendIL(MethodInfo method, StringWriter sw, ICilTypeFactory typeFactory)
    {
        ILReader reader = ILReaderFactory.Create(method);
        ExceptionInfo[] exceptions = reader.ILProvider.GetExceptionInfos();
        var writer = new RichILStringToTextWriter(sw, exceptions);

        sw.WriteLine(".method " + method.GetILSig());
        sw.WriteLine("{");
        sw.WriteLine("  .maxstack " + reader.ILProvider.MaxStackSize);

        byte[] sig = reader.ILProvider.GetLocalSignature();
        var lsp = new EcmaLocalSigParser(reader.Resolver, typeFactory);
        var locals = default(Type[]);
        if (lsp.Parse(sig, out locals) && locals.Length > 0)
        {
            sw.WriteLine("  .locals init (");

            for (var i = 0; i < locals.Length; i++)
            {
                sw.WriteLine($"    [{i}] {locals[i].GetILSig()}{(i != locals.Length - 1 ? "," : "")}");
            }

            sw.WriteLine("  )");
        }

        sw.WriteLine();

        writer.Indent();
        reader.Accept(new ReadableILStringVisitor(writer));
        writer.Dedent();

        sw.WriteLine("}");
    }
}

class CachedTypeFactory : DefaultTypeFactory
{
    static readonly PropertyInfo s_RuntimeTypeHandle_Value = typeof(RuntimeTypeHandle).GetProperty("Value");

    readonly Dictionary<IntPtr, Type> _cache = new Dictionary<IntPtr,Type>();

    public CachedTypeFactory(params Type[] types)
    {
        foreach(var type in types)
            AddType(type);
    }

    public void AddTypesFrom(Expression expression)
        => new TypeFinder(this).Visit(expression);

    public void AddType(Type type)
    {
        var handle = (IntPtr)s_RuntimeTypeHandle_Value.GetValue(type.TypeHandle);

        lock (_cache)
        {
            _cache.TryAdd(handle, type);
        }
    }

    public override Type FromHandle(IntPtr handle)
    {
        Type res;
        if (_cache.TryGetValue(handle, out res))
        {
            return res;
        }

        return base.FromHandle(handle);
    }

    class TypeFinder : ExpressionVisitor
    {
        readonly CachedTypeFactory _parent;

        public TypeFinder(CachedTypeFactory factory)
        {
            _parent = factory;
        }

        public override Expression Visit(Expression node)
        {
            if (node != null)
            {
                Visit(node.Type);
            }

            return base.Visit(node);
        }

        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {
            var property = node.Member as PropertyInfo;
            if (property != null)
            {
                Visit(property.PropertyType);
            }
            else
            {
                Visit(((FieldInfo)node.Member).FieldType);
            }

            return base.VisitMemberBinding(node);
        }

        void Visit(Type type)
        {
            TypeInfo ti = type.GetTypeInfo();

            if (ti.IsArray || ti.IsPointer || ti.IsByRef)
            {
                Visit(type.GetElementType());
            }
            else if (ti.IsGenericType && !ti.IsGenericTypeDefinition)
            {
                Visit(type.GetGenericTypeDefinition());
                foreach (var arg in type.GetGenericArguments())
                {
                    Visit(arg);
                }
            }
            else if (!ti.IsPrimitive)
            {
                _parent.AddType(type);
            }
        }
    }
}
