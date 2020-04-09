using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Disassembler
{
    // Todo: Refactor!
    internal static class Shell
    {
        // Internal Const Data
        private const int Length1 = 30;
        private const int Length2 = 90;
        private const int TruncateLength = 50;

        // Methods
        internal static void WriteHeader(string name)
        {
            WriteHeader(name, 0);
        }

        internal static void WriteHeader(string name, int padding)
        {
            var pad = new string(' ', padding);

            Console.WriteLine(pad + "|{0}|", new string('-', Length2 - 1));
            Console.Write(pad + "|");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(" {0}{1}", name, new string(' ', Length2 - (name.Length + 2)));
            Console.ResetColor();
            Console.WriteLine("|");
            Console.WriteLine(pad + "|{0}|", new string('-', Length2 - 1));
        }

        internal static void WriteFooter()
        {
            WriteFooter(0);
        }

        internal static void WriteFooter(int padding)
        {
            var pad = new string(' ', padding);

            Console.WriteLine(pad + "|{0}|", new string('-', Length2 - 1));
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

        internal static void WriteItem(string name, IList<ushort> value)
        {
            var items = value.Take(6).Select(x => $"{x:x4}").ToList();

            if (value.Count > 7)
            {
                items.Insert(5, "(...)");
            }

            var missing = value.Count > 7
                ? $"({value.Count}:{value.Count - 7})"
                : string.Empty;

            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| [{string.Join(", ", items)}] {missing}";
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

        internal static void WriteItem(string name, IList<uint> value)
        {
            var itemCount = 4;
            var items = value.Take(itemCount).Select(x => $"{x:x8}").ToList();

            if (value.Count > itemCount)
            {
                items.Insert(itemCount, "(...)");
            }

            var missing = value.Count > itemCount
                ? $"({value.Count}:{value.Count - itemCount})"
                : string.Empty;

            var a = $"| {name}{new string(' ', Length1 - (name.Length + 1))}| [{string.Join(", ", items)}] {missing}";
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

        internal static void Table<T>(string name, IEnumerable<T> sequence, Action<TableShellDescriptor> action)
        {
            Table(name, sequence, 0, action);
        }

        internal static void Table<T>(string name,  IEnumerable<T> sequence, int padding, Action<TableShellDescriptor> action) 
        {
            Shell.WriteHeader(name, padding);

            var descriptors = new TableShellDescriptor();
            action(descriptors);

            var pad = new string(' ', padding);

            var members = typeof(T)
                .GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property)
                .ToArray();

            Console.Write(pad);

            foreach (var d in descriptors.Descriptors)
            {
                var a = typeof(T).GetMember(d.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
                var x = "| " + d.Name + " " + new string(' ', d.Size - d.Name.Length);

                Console.Write(x);
            }

            Console.WriteLine("|");
            Console.WriteLine(pad + "|{0}|", new string('-', Length2 - 1));

            foreach (var item in sequence)
            {
                Console.Write(pad);
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

                    var realValue = value != null
                        ? value.GetType().IsEnum
                            ? (int)value
                            : value
                        : value;

                    var x = "| " + descriptor.Format + " " + new string(' ', descriptor.Size - string.Format(descriptor.Format, realValue).Length);
                    var w = string.Format(x, realValue);

                    Console.Write(w, value);
                }

                Console.WriteLine("|");              
            }

            Shell.WriteFooter(padding);
        }
    }
}