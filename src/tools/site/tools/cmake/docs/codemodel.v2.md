
# Codemodel V2

```json
{
  "kind": "codemodel",
  "version": { "major": 2, "minor": 4 },
  "paths": {
    "source": "/path/to/top-level-source-dir",
    "build": "/path/to/top-level-build-dir"
  },
  "configurations": [
    {
      "name": "Debug",
      "directories": [
        {
          "source": ".",
          "build": ".",
          "childIndexes": [ 1 ],
          "projectIndex": 0,
          "targetIndexes": [ 0 ],
          "hasInstallRule": true,
          "minimumCMakeVersion": {
            "string": "3.14"
          },
          "jsonFile": "<file>"
        },
        {
          "source": "sub",
          "build": "sub",
          "parentIndex": 0,
          "projectIndex": 0,
          "targetIndexes": [ 1 ],
          "minimumCMakeVersion": {
            "string": "3.14"
          },
          "jsonFile": "<file>"
        }
      ],
      "projects": [
        {
          "name": "MyProject",
          "directoryIndexes": [ 0, 1 ],
          "targetIndexes": [ 0, 1 ]
        }
      ],
      "targets": [
        {
          "name": "MyExecutable",
          "directoryIndex": 0,
          "projectIndex": 0,
          "jsonFile": "<file>"
        },
        {
          "name": "MyLibrary",
          "directoryIndex": 1,
          "projectIndex": 0,
          "jsonFile": "<file>"
        }
      ]
    }
  ]
}
```

paths
A JSON object containing members:

source
A string specifying the absolute path to the top-level source directory, represented with forward slashes.

build
A string specifying the absolute path to the top-level build directory, represented with forward slashes.

configurations
A JSON array of entries corresponding to available build configurations. On single-configuration generators there is one entry for the value of the CMAKE_BUILD_TYPE variable. For multi-configuration generators there is an entry for each configuration listed in the CMAKE_CONFIGURATION_TYPES variable. Each entry is a JSON object containing members:

name
A string specifying the name of the configuration, e.g. Debug.

directories
A JSON array of entries each corresponding to a build system directory whose source directory contains a CMakeLists.txt file. The first entry corresponds to the top-level directory. Each entry is a JSON object containing members:

source
A string specifying the path to the source directory, represented with forward slashes. If the directory is inside the top-level source directory then the path is specified relative to that directory (with . for the top-level source directory itself). Otherwise the path is absolute.

build
A string specifying the path to the build directory, represented with forward slashes. If the directory is inside the top-level build directory then the path is specified relative to that directory (with . for the top-level build directory itself). Otherwise the path is absolute.

parentIndex
Optional member that is present when the directory is not top-level. The value is an unsigned integer 0-based index of another entry in the main directories array that corresponds to the parent directory that added this directory as a subdirectory.

childIndexes
Optional member that is present when the directory has subdirectories. The value is a JSON array of entries corresponding to child directories created by the add_subdirectory() or subdirs() command. Each entry is an unsigned integer 0-based index of another entry in the main directories array.

projectIndex
An unsigned integer 0-based index into the main projects array indicating the build system project to which the this directory belongs.

targetIndexes
Optional member that is present when the directory itself has targets, excluding those belonging to subdirectories. The value is a JSON array of entries corresponding to the targets. Each entry is an unsigned integer 0-based index into the main targets array.

minimumCMakeVersion
Optional member present when a minimum required version of CMake is known for the directory. This is the <min> version given to the most local call to the cmake_minimum_required(VERSION) command in the directory itself or one of its ancestors. The value is a JSON object with one member:

string
A string specifying the minimum required version in the format:

<major>.<minor>[.<patch>[.<tweak>]][<suffix>]
Each component is an unsigned integer and the suffix may be an arbitrary string.

hasInstallRule
Optional member that is present with boolean value true when the directory or one of its subdirectories contains any install() rules, i.e. whether a make install or equivalent rule is available.

jsonFile
A JSON string specifying a path relative to the codemodel file to another JSON file containing a "codemodel" version 2 "directory" object.

This field was added in codemodel version 2.3.

projects
A JSON array of entries corresponding to the top-level project and sub-projects defined in the build system. Each (sub-)project corresponds to a source directory whose CMakeLists.txt file calls the project() command with a project name different from its parent directory. The first entry corresponds to the top-level project.

Each entry is a JSON object containing members:

name
A string specifying the name given to the project() command.

parentIndex
Optional member that is present when the project is not top-level. The value is an unsigned integer 0-based index of another entry in the main projects array that corresponds to the parent project that added this project as a sub-project.

childIndexes
Optional member that is present when the project has sub-projects. The value is a JSON array of entries corresponding to the sub-projects. Each entry is an unsigned integer 0-based index of another entry in the main projects array.

directoryIndexes
A JSON array of entries corresponding to build system directories that are part of the project. The first entry corresponds to the top-level directory of the project. Each entry is an unsigned integer 0-based index into the main directories array.

targetIndexes
Optional member that is present when the project itself has targets, excluding those belonging to sub-projects. The value is a JSON array of entries corresponding to the targets. Each entry is an unsigned integer 0-based index into the main targets array.

targets
A JSON array of entries corresponding to the build system targets. Such targets are created by calls to add_executable(), add_library(), and add_custom_target(), excluding imported targets and interface libraries (which do not generate any build rules). Each entry is a JSON object containing members:

name
A string specifying the target name.

id
A string uniquely identifying the target. This matches the id field in the file referenced by jsonFile.

directoryIndex
An unsigned integer 0-based index into the main directories array indicating the build system directory in which the target is defined.

projectIndex
An unsigned integer 0-based index into the main projects array indicating the build system project in which the target is defined.

jsonFile
A JSON string specifying a path relative to the codemodel file to another JSON file containing a "codemodel" version 2 "target" object.

"codemodel" version 2 "directory" object
A codemodel "directory" object is referenced by a "codemodel" version 2 object's directories array. Each "directory" object is a JSON object with members:

paths
A JSON object containing members:

source
A string specifying the path to the source directory, represented with forward slashes. If the directory is inside the top-level source directory then the path is specified relative to that directory (with . for the top-level source directory itself). Otherwise the path is absolute.

build
A string specifying the path to the build directory, represented with forward slashes. If the directory is inside the top-level build directory then the path is specified relative to that directory (with . for the top-level build directory itself). Otherwise the path is absolute.

installers
A JSON array of entries corresponding to install() rules. Each entry is a JSON object containing members:

component
A string specifying the component selected by the corresponding install() command invocation.

destination
Optional member that is present for specific type values below. The value is a string specifying the install destination path. The path may be absolute or relative to the install prefix.

paths
Optional member that is present for specific type values below. The value is a JSON array of entries corresponding to the paths (files or directories) to be installed. Each entry is one of:

A string specifying the path from which a file or directory is to be installed. The portion of the path not preceded by a / also specifies the path (name) to which the file or directory is to be installed under the destination.

A JSON object with members:

from
A string specifying the path from which a file or directory is to be installed.

to
A string specifying the path to which the file or directory is to be installed under the destination.

In both cases the paths are represented with forward slashes. If the "from" path is inside the top-level directory documented by the corresponding type value, then the path is specified relative to that directory. Otherwise the path is absolute.

type
A string specifying the type of installation rule. The value is one of the following, with some variants providing additional members:

file
An install(FILES) or install(PROGRAMS) call. The destination and paths members are populated, with paths under the top-level source directory expressed relative to it. The isOptional member may exist. This type has no additional members.

directory
An install(DIRECTORY) call. The destination and paths members are populated, with paths under the top-level source directory expressed relative to it. The isOptional member may exist. This type has no additional members.

target
An install(TARGETS) call. The destination and paths members are populated, with paths under the top-level build directory expressed relative to it. The isOptional member may exist. This type has additional members targetId, targetIndex, targetIsImportLibrary, and targetInstallNamelink.

export
An install(EXPORT) call. The destination and paths members are populated, with paths under the top-level build directory expressed relative to it. The paths entries refer to files generated automatically by CMake for installation, and their actual values are considered private implementation details. This type has additional members exportName and exportTargets.

script
An install(SCRIPT) call. This type has additional member scriptFile.

code
An install(CODE) call. This type has no additional members.

importedRuntimeArtifacts
An install(IMPORTED_RUNTIME_ARTIFACTS) call. The destination member is populated. The isOptional member may exist. This type has no additional members.

runtimeDependencySet
An install(RUNTIME_DEPENDENCY_SET) call or an install(TARGETS) call with RUNTIME_DEPENDENCIES. The destination member is populated. This type has additional members runtimeDependencySetName and runtimeDependencySetType.

fileSet
An install(TARGETS) call with FILE_SET. The destination and paths members are populated. The isOptional member may exist. This type has additional members fileSetName, fileSetType, fileSetDirectories, and fileSetTarget.

This type was added in codemodel version 2.4.

isExcludeFromAll
Optional member that is present with boolean value true when install() is called with the EXCLUDE_FROM_ALL option.

isForAllComponents
Optional member that is present with boolean value true when install(SCRIPT|CODE) is called with the ALL_COMPONENTS option.

isOptional
Optional member that is present with boolean value true when install() is called with the OPTIONAL option. This is allowed when type is file, directory, or target.

targetId
Optional member that is present when type is target. The value is a string uniquely identifying the target to be installed. This matches the id member of the target in the main "codemodel" object's targets array.

targetIndex
Optional member that is present when type is target. The value is an unsigned integer 0-based index into the main "codemodel" object's targets array for the target to be installed.

targetIsImportLibrary
Optional member that is present when type is target and the installer is for a Windows DLL import library file or for an AIX linker import file. If present, it has boolean value true.

targetInstallNamelink
Optional member that is present when type is target and the installer corresponds to a target that may use symbolic links to implement the VERSION and SOVERSION target properties. The value is a string indicating how the installer is supposed to handle the symlinks: skip means the installer should skip the symlinks and install only the real file, and only means the installer should install only the symlinks and not the real file. In all cases the paths member lists what it actually installs.

exportName
Optional member that is present when type is export. The value is a string specifying the name of the export.

exportTargets
Optional member that is present when type is export. The value is a JSON array of entries corresponding to the targets included in the export. Each entry is a JSON object with members:

id
A string uniquely identifying the target. This matches the id member of the target in the main "codemodel" object's targets array.

index
An unsigned integer 0-based index into the main "codemodel" object's targets array for the target.

runtimeDependencySetName
Optional member that is present when type is runtimeDependencySet and the installer was created by an install(RUNTIME_DEPENDENCY_SET) call. The value is a string specifying the name of the runtime dependency set that was installed.

runtimeDependencySetType
Optional member that is present when type is runtimeDependencySet. The value is a string with one of the following values:

library
Indicates that this installer installs dependencies that are not macOS frameworks.

framework
Indicates that this installer installs dependencies that are macOS frameworks.

fileSetName
Optional member that is present when type is fileSet. The value is a string with the name of the file set.

This field was added in codemodel version 2.4.

fileSetType
Optional member that is present when type is fileSet. The value is a string with the type of the file set.

This field was added in codemodel version 2.4.

fileSetDirectories
Optional member that is present when type is fileSet. The value is a list of strings with the file set's base directories (determined by genex-evaluation of HEADER_DIRS or HEADER_DIRS_<NAME>).

This field was added in codemodel version 2.4.

fileSetTarget
Optional member that is present when type is fileSet. The value is a JSON object with members:

id
A string uniquely identifying the target. This matches the id member of the target in the main "codemodel" object's targets array.

index
An unsigned integer 0-based index into the main "codemodel" object's targets array for the target.

This field was added in codemodel version 2.4.

scriptFile
Optional member that is present when type is script. The value is a string specifying the path to the script file on disk, represented with forward slashes. If the file is inside the top-level source directory then the path is specified relative to that directory. Otherwise the path is absolute.

backtrace
Optional member that is present when a CMake language backtrace to the install() or other command invocation that added this installer is available. The value is an unsigned integer 0-based index into the backtraceGraph member's nodes array.

backtraceGraph
A "codemodel" version 2 "backtrace graph" whose nodes are referenced from backtrace members elsewhere in this "directory" object.