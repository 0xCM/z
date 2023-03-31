#pragma once

#include <phnt/phnt_windows.h>
#include <phnt/phnt.h>
#include <ImageHlp.h>
#include <DbgHelp.h>
#include <uchar.h>

HMODULE LoadLibrary(char16_t[] path)
{
    return LoadLibraryW(&path);
}