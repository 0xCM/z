//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using Commands;
    
    using static Ts;
    using static sys;

    public interface ICodeGen
    {
        ExecToken GenTokens(EnvId env, IDbArchive dst);
    }

    public interface ICodeGen<L> : ICodeGen
        where L : Language
    {

    }
    public interface ITsGen : ICodeGen<Ts>
    {
    }
    
    class TsGen : Channeled<TsGen>, ITsGen
    {
        static AppSettings AppSettings => AppSettings.Default;

        public ExecToken GenTokens(EnvId env, IDbArchive dst)
        {            
            var ts = lang.Ts;            
            var emitter = text.emitter();
            var report = Env.load(AppSettings.EnvDb(), env);
            iter(report.Vars, v => {
                var token = ts.DefineToken(v.Name, v.Value);
                emitter.AppendLine(token.Format());
            });    
            return Channel.FileEmit(emitter.Emit(),dst.Path("vars", TsExt));
        }

        public void Run(EnvGenCmd cmd)
        {            
            var ts = lang.Ts;            
            var dst = text.emitter();
            var report = Env.load(AppSettings.EnvDb(), cmd.Name);
            iter(report.Vars, v => {
                var token = ts.DefineToken(v.Name, v.Value);
                dst.AppendLine(token.Format());
            });    
            Channel.FileEmit(dst.Emit(), cmd.Target + FS.file("vars", FS.ext("ts")));

            iter(report.Tools, tool => {
                var name = $"{tool.Path.FileName.WithoutExtension.Format()}_path";
                var value = tool.Path.Format(PathSeparator.FS);
                var token = ts.DefineToken(name, value);
                dst.AppendLine(token.Format());
            });
            Channel.FileEmit(dst.Emit(),cmd.Target + FS.file("tools", FS.ext("ts")));
        }
    }
}