//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class IntrinsicsDoc
{
    public readonly record struct FunctionName : IComparable<FunctionName>
    {
        public static FunctionName parse(string src)
        {
            var prefix = EmptyString;
            for(var i=0; i<src.Length; i++)
            {
                if(src[i] == Chars.Underscore)
                    prefix += Chars.Underscore;
                else
                    break;
            }

            return new(prefix, text.split(text.trim(src,Chars.Underscore), Chars.Underscore));
        }

        readonly string Prefix;

        public readonly ReadOnlySeq<string> Components;

        public FunctionName(string prefix, params string[] parts)
        {
            Prefix = prefix;
            if(parts.Length == 0)
                Components = new string[]{""};
            else
                Components = parts;
        }

        public bool IsFp
        {
            get => Components.Last == "ph"
                || Components.Last == "pd"
                || Components.Last == "ps"
                ;
        }

        public bool IsStore
        {
            get => Components.Contains("store")
                || Components.Contains("storeu")
                || Components.Contains("storeu2")
                ;
        }

        public bool IsLoad
        {
            get => Components.Contains("load")
            || Components.Contains("loadu")
            || Components.Contains("load1")
            || Components.Contains("loadh")
            || Components.Contains("loadl")
            || Components.Contains("loadr")
            || Components.Contains("storeu2")
            ;
        }

        public bool IsShift
        {
            get => Components.Contains("sll")
                || Components.Contains("slli")
                || Components.Contains("sllv")
                || Components.Contains("sra")
                || Components.Contains("srlv")
                || Components.Contains("srai")
                || Components.Contains("srav")
                ;
        }
        public bool IsShuffle
        {
            get => Components.Contains("shuffle")
                || Components.Contains("shufflehi")
                || Components.Contains("shufflelo")
            ;
        }

        public bool IsBlend
        {
            get => Components.Contains("blend") || Components.Contains("blendv");
        }

        public bool IsBroadcast
        {
            get => Components.Contains("broadcast") 
                || Components.Contains("broadcastb")
                || Components.Contains("broadcastw")
                || Components.Contains("broadcastd")
                || Components.Contains("broadcastq")
                || Components.Contains("broadcastss")
                || Components.Contains("broadcastsd")
                ;
        }

        public bool IsCompare
        {
            get => Components.Contains("cmp") 
                || Components.Contains("cmpeq")
                || Components.Contains("cmpneq")
                || Components.Contains("cmpge")
                || Components.Contains("cmpgt")
                || Components.Contains("cmpngt")
                || Components.Contains("cmpord")
                || Components.Contains("cmplt")
                || Components.Contains("cmpnlt")
                || Components.Contains("cmple")
                || Components.Contains("cmpnle")
                ;
        }

        public bool IsScatter
        {
            get => Components.Contains("i32scatter")            
                || Components.Contains("i32loscatter")
                || Components.Contains("i32extscatter")
                || Components.Contains("i32loextscatter")
                || Components.Contains("i64scatter")
            ;
        }

        public bool IsGather
        {
            get => Components.Contains("i32gather")
                || Components.Contains("i32logather")
                || Components.Contains("i32extgather")
                || Components.Contains("i32loextgather")
                || Components.Contains("i64gather")
                ;                
        }

        public bool IsDiv
        {
            get=> Components.Contains("div");
        }

        public bool IsSub
        {
            get => Components.Contains("sub")
                || Components.Contains("subs")
                || Components.Contains("hsub")
                ;
        }

        public bool IsMul
        {
            get=> Components.Contains("mul");
        }

        public bool IsAdd
        {
            get => Components.Contains("add")
                || Components.Contains("adds")
                || Components.Contains("hadd")
            ;
        }

        public bool IsTest
        {
            get => Components.Contains("test")
                || Components.Contains("testn")
                || Components.Contains("testc")
                || Components.Contains("testz")
                || Components.Contains("testznc")
            ;
        }

        public bool IsSet
        {
            get => Components.Contains("set") 
                || Components.Contains("setr")
                || Components.Contains("set1")
                || Components.Contains("set4")
                || Components.Contains("setr4")
                || Components.Contains("setzero")
                ;
        }

        public bool IsXor
        {
            get => Components.Contains("xor");
        }

        public bool IsOr
        {
            get => Components.Contains("or");
        }

        public bool IsAbs
        {
            get => Components.Contains("abs");
        }

        public bool IsMax
        {
            get => Components.Contains("max");
        }

        public bool IsMin
        {
            get => Components.Contains("min");
        }

        public Hash32 Hash
        {
            get => sys.hash(Format());
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Prefix + string.Join(Chars.Underscore, Components);

        public override string ToString()
            => Format();

        public int CompareTo(FunctionName src)
            => Format().CompareTo(src.Format());
    }
}
