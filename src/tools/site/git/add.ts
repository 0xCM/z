import * as Env from "../env"
import {Tk} from "../core"

export type Add = 'add'

export type DryRun = '--dry-run'

export type Verbose = `--${Tk.Verbose}`

export type Syntax = `[${Verbose} | -v] [--dry-run | -n] [--force | -f] [--interactive | -i] [--patch | -p] [--edit | -e] [--[no-]all | --[no-]ignore-removal | [--update | -u]] [--sparse] [--intent-to-add | -N] [--refresh] [--ignore-errors] [--ignore-missing] [--renormalize] [--chmod=(+|-)x] [--pathspec-from-file=<file> [--pathspec-file-nul]] [--] [<pathspec>…​]`

/*
git add [--verbose | -v] [--dry-run | -n] [--force | -f] [--interactive | -i] [--patch | -p]
          [--edit | -e] [--[no-]all | --[no-]ignore-removal | [--update | -u]] [--sparse]
          [--intent-to-add | -N] [--refresh] [--ignore-errors] [--ignore-missing] [--renormalize]
          [--chmod=(+|-)x] [--pathspec-from-file=<file> [--pathspec-file-nul]]
          [--] [<pathspec>…​]
*/

export const Ref = `${Env.DevTools()}/gfw/mingw64/share/doc/git-doc/git-add.html`

