//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public interface IDataSource
    {


    }
    
    public interface IDataSource<T> : IDataSource
        where T : IEquatable<T>, IComparable<T>, new()
    {


    }
    
    public abstract record class AppSettings<S,T>
        where S : AppSettings<S,T>, new()
        where T : IEquatable<T>, IComparable<T>, new()
    {
        
    }


    public sealed class AppSettings : SettingLookup<Name,string>
    {
        static AppSettings _Service = load(path());

        public static AppSettings load(WfEmit channel)
            => load(path(), channel);

        public static FS.FilePath path()
            => FS.path(sys.controller().Location).FolderPath + FS.file("app.settings", FileKind.Csv);

        public static ref readonly AppSettings Default
        {
            [MethodImpl(Inline)]
            get => ref _Service;
        }

        public AppSettings()
        {

        }

        public AppSettings(Setting[] settings)
            : base(settings.Select(x => new Setting<Name, string>(x.Name,x.ValueText)))
        {

        }

        public AppSettings(Setting<Name,string>[] settings)
            : base(settings)
        {

        }

        public static AppSettings load(FS.FilePath src)
        {
            var data = src.ReadLines(true);
            var dst = sys.alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line, Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(sys.skip(parts,0)), text.trim(sys.skip(parts,1)));
            }

            return new AppSettings(dst);
        }

        public static AppSettings load(FS.FilePath src, WfEmit channel)
        {
            var flow = channel.Running($"Loading application settings from {src.ToUri()}");
            var dst = load(src);
            channel.Ran(flow,$"Read {dst.Length} settings from {src.ToUri()}");
            return dst;
        }

        public string Find(Name name)
            => Find(name, EmptyString);

        public Setting Setting(string name)
        {
            var dst = Z0.Setting.Empty;
            if(Find(name, out var x))
                dst = new Setting(name,x);
            return dst;
        }

        public override string Format()
        {
            var dst = text.emitter();            
            iter(Data, s => dst.AppendLine(s));
            return dst.Emit();
        }
    }
}