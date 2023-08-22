//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public sealed record class AssemblyFile : IBinaryModule<AssemblyFile>, IComparable<AssemblyFile>
{
    /// <summary>
    /// For a managed module, retrieves its name and returns true; otherwise, returns false
    /// </summary>
    /// <param name="src">The source path</param>
    public static bool name(FilePath src, out AssemblyName dst)
    {
        try
        {
            dst = System.Reflection.AssemblyName.GetAssemblyName(src.Name.Format(PathSeparator.BS));
            return true;
        }
        catch(Exception)
        {
            dst = null;
            return false;
        }
    }        

    public readonly FilePath Path;

    public readonly VersionedName AssemblyName;
    
    public AssemblyFile()
    {
        Path = FileUri.Empty;
        AssemblyName = VersionedName.Empty;
    }

    public AssemblyFile(FilePath path, VersionedName name)
    {
        Path = path;
        AssemblyName = name;
    }

    FilePath IBinaryModule.Path 
        => Path;

    public VersionedName Identifier
        => AssemblyName;

    public FileModuleKind ModuleKind 
        => FileModuleKind.Managed;

    public FilePath CommentsFile 
        => Path.ChangeExtension(FS.ext("xml"));

    public FilePath PdbFile
        => Path.ChangeExtension(FS.ext("pdb"));

    public bool HasComments 
        => CommentsFile.Exists;

    public bool HasPdb 
        => PdbFile.Exists;

    public bool Equals(AssemblyFile src)
        => Path == src.Path && AssemblyName == src.AssemblyName;

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Path.Hash;
    }

    public override int GetHashCode()
        => Hash;

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Path.IsEmpty && AssemblyName.IsEmpty;
    }
    
    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Path.IsNonEmpty || AssemblyName.IsNonEmpty;
    }

    public Assembly Load()
        => Assembly.LoadFrom(Path.Format());

    public string Format()
        => Path.IsNonEmpty ? Path.Format() : $"{AssemblyName}";

    public override string ToString()
        => Format();
        
    public int CompareTo(AssemblyFile src)
    {
        var result = AssemblyName.CompareTo(src.AssemblyName);
        if(result == 0)
            result = Path.CompareTo(src.Path);
        return result;
    }

    public static AssemblyFile Empty => new AssemblyFile();
}

partial class XTend
{
    public static AssemblyFile GetAssemblyFile(this Assembly src)
        =>  new AssemblyFile(src.Path(), src.GetName());    
}
