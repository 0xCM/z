import {Tk} from "../imports"
export type Bin<R extends string> = `${R}/${Tk.Bin}`

export type Include<R extends string> = `${R}/${Tk.Include}`
export type Lib<R extends string> = `${R}/${Tk.Lib}`
export type Paths<R extends string> = {
    bin:Bin<R>
    include:Include<R>
    lib:Lib<R>
}