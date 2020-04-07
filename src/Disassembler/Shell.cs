using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace PeUtility
{
    internal static class Shell
    {
        // Internal Const Data
        private const int Length1 = 30;
        private const int Length2 = 90;
        private const int TruncateLength = 50;

        // Methods
        internal static void WriteHeader(string name)
        {
            Console.WriteLine("|{0}|", new string('-', Length2 - 1));
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(" {0}{1}", name, new string(' ', Length2 - (name.Length + 2)));
            Console.ResetColor();
            Console.WriteLine("|");
            Console.WriteLine("|{0}|", new string('-', Length2 - 1));
        }

        internal static void WriteFooter()
        {
            Console.WriteLine("|{0}|", new string('-', Length2 - 1));
            Console.WriteLine();
        }

        internal static void WriteItem<T>(string name, T value) where T : Enum
        {
            WriteItem(name, value.ToString());
        }

        internal static void WriteItem(string name, string value)
        {
            if (value.Length > TruncateLength)
            {
                value = value.Substring(0, TruncateLength) + "...";
            }

            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| '{value}'";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, byte value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x2}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, ushort value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x4}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, ushort[] value)
        {
            var w = value.Take(6).Select(x => $"{x:x4}").ToList();

            if (value.Length > 7)
            {
                w.Insert(5, "(...)");
            }

            var missing = value.Length > 7
                ? $"({value.Length}:{value.Length - 7})"
                : string.Empty;

            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| [{string.Join(", ", w)}] {missing}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, short value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x4}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, uint value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x8}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, int value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x8}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, ulong value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x16}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        internal static void WriteItem(string name, long value)
        {
            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| {value:x16}";
            var b = $"{a}{new string(' ', Length2 - a.Length)}|";

            Console.WriteLine(b);
        }

        // Todo: Refactor!
        internal static void Table<T>(string name,  IList<T> sequence, Action<TableShellDescriptor> action) 
        {
            Shell.WriteHeader(name);

            var descriptors = new TableShellDescriptor();
            action(descriptors);

            var members = typeof(T)
                .GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property)
                .ToArray();

            foreach (var d in descriptors.Descriptors)
            {
                var a = typeof(T).GetMember(d.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                var x = "| " + d.Name + " " + new string(' ', d.Size - d.Name.Length);

                Console.Write(x);
            }

            Console.WriteLine("|");
            Console.WriteLine("|{0}|", new string('-', Length2 - 1));

            foreach (var item in sequence)
            {
                for (int i = 0; i < descriptors.Descriptors.Count; i++)
                {
                    var descriptor = descriptors.Descriptors[i];
                    var a = typeof(T).GetMember(descriptor.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                    object value = null;

                    if (a != null && a is PropertyInfo)
                    {
                        value = ((PropertyInfo)a).GetValue(item);
                    }

                    if (a != null && a is FieldInfo)
                    {
                        value = ((FieldInfo)a).GetValue(item);
                    }

                    var x = "| " + descriptor.Format + " " + new string(' ', descriptor.Size - string.Format(descriptor.Format, value).Length);
                    var w = string.Format(x, value);

                    Console.Write(w, value);
                }

                Console.WriteLine("|");              
            }

            Shell.WriteFooter();
        }
    }

    // Todo: Move to own file!
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

    // Todo: Move to own file!
    internal sealed class TableShellItemDescriptor
    {
        public string Name   { get; set; }
        public string Format { get; set; }
        public int    Size   { get; set; }
    }
}