using System;

namespace PeUtility
{
    internal static class DosHeaderPresenter
    {
        internal static void Present(DosHeader header)
        {
            Shell.WriteHeader("Dos Header");
            Shell.WriteItem(nameof(header.Magic),    header.Magic);
            Shell.WriteItem(nameof(header.Cblp),     header.Cblp);
            Shell.WriteItem(nameof(header.Cp),       header.Cp);
            Shell.WriteItem(nameof(header.Crlc),     header.Crlc);
            Shell.WriteItem(nameof(header.Cparhdr),  header.Cparhdr);
            Shell.WriteItem(nameof(header.Minalloc), header.Minalloc);
            Shell.WriteItem(nameof(header.Maxalloc), header.Maxalloc);
            Shell.WriteItem(nameof(header.Ss),       header.Ss);
            Shell.WriteItem(nameof(header.Sp),       header.Sp);
            Shell.WriteItem(nameof(header.CSum),     header.CSum);
            Shell.WriteItem(nameof(header.Ip),       header.Ip);
            Shell.WriteItem(nameof(header.Cs),       header.Cs);
            Shell.WriteItem(nameof(header.Lfarlc),   header.Lfarlc);
            Shell.WriteItem(nameof(header.Ovno),     header.Ovno);
            Shell.WriteItem(nameof(header.Res1),     header.Res1);
            Shell.WriteItem(nameof(header.Oemid),    header.Oemid);
            Shell.WriteItem(nameof(header.Oeminfo),  header.Oeminfo);
            Shell.WriteItem(nameof(header.Res2),     header.Res2);
            Shell.WriteItem(nameof(header.Lfanew),   header.Lfanew);
            Shell.WriteFooter();
        }
    }
}