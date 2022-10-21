//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{ 

    public interface ITaskMap<S,T>
    {
        Task<Outcome<T>> Map(S src);
    }

    partial class Tools
    {
        public sealed class CMake : Tool<CMake>    
        {
            public const string ToolName = "cmake";

            public CMake()
                : base(ToolName)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

            public abstract record class Node<N,K>
                where N : Node<N,K>, new()
            {
                protected static K _Kind;


                protected static N _Empty = new();

                public static ref readonly K Kind => ref _Kind;
            }

            public class Cache 
            {

                


            }
            
            public abstract record class CacheNode<T> : Node<T,Type>
                where T : CacheNode<T>, new()
            {
                static CacheNode()
                {
                    _Kind = _Empty.GetType();
                }
            }


            public sealed record class SettingHelp : CacheNode<SettingHelp>
            {


            }

            public sealed record class CommentBlock : CacheNode<CommentBlock>
            {

            }

            public interface ISettingValue
            {

            }
            public interface IValued<K,V>
            {
                K Kind {get;}

                V Value {get;}
            }

            public abstract record class SettingVar<T>
                where T : SettingVar<T>, new()
            {
                public DataType Type {get;}

                public string Name {get;}

                public SettingVar(DataType type, string name)
                {
                    Type = type;
                    Name = name;
                }

                static T _Empty = new();

                public ref readonly T Empty => ref _Empty;
            }

            public enum DataType : byte
            {   
                None,

                Bool,

                String,

                File,

                Folder,

                Auto
            }

            public enum Visiblity : byte
            {
                Public,

                Internal
            }

            public enum Class : byte
            {
                Default,

                Advanced
            }

            public readonly struct Facets
            {
                public readonly DataType DataType {get;}

                public readonly Visiblity Visiblity {get;}

                public readonly Class Class {get;}
            }

            public record class BoolVar : SettingVar<BoolVar>
            {                   
                public BoolVar()
                    : base(DataType.Bool, @string.Empty)
                {

                }

                public BoolVar(string name, bit value)
                    : base(DataType.Bool, name)
                {
                    Value = value;
                }

                public bit Value {get;}

                
            }


            public record class Setting<T> : CacheNode<Setting<T>>
            {                
                public string Name {get;}

                public T Value {get;}

                public SettingHelp Description {get;}

                public Facets Facets {get;}
            }

            class CacheParser : ITaskMap<FileUri, Cache>
            {
                public Task<Outcome<Cache>> Map(FileUri src)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}