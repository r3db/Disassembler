using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class TableShellDescriptor
    {
        private readonly IList<TableShellItemDescriptor> _descriptors = new List<TableShellItemDescriptor>();

        internal void Add(string name, string format)
        {
            Add(name, format, name.Length + 1);
        }

        internal void Add(string name, int length)
        {
            Add(name, "{0}", length);
        }

        internal void Add(string name, string format, int length)
        {
            _descriptors.Add(new TableShellItemDescriptor
            {
                Name   = name,
                Format = format,
                Size   = length,
            });
        }

        internal IList<TableShellItemDescriptor> Descriptors => _descriptors;
    }
}