/*
https://github.com/JetBrains/Refasmer
refasmer [options] <dll> [<dll> ...]
Options:
  -v                         increase verbosity
  -q, --quiet                be quiet
  -h, -?, --help             show help
  -c, --continue             continue on errors
  -O, --outputdir=VALUE      set output directory
  -o, --output=VALUE         set output file, for single file only
  -r, --refasm               make reference assembly, default action
  -w, --overwrite            overwrite source files
  -p, --public               drop non-public types even with InternalsVisibleTo
  -i, --internals            import public and internal types
      --all                  ignore visibility and import all
  -m, --mock                 make mock assembly instead of reference assembly
  -n, --noattr               omit reference assembly attribute
  -l, --list                 make file list xml
  -a, --attr=VALUE           add FileList tag attribute
*/