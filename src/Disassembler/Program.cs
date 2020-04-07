using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PeUtility
{
    // Todo: Rename!
    [Flags]
    internal enum CorTypeAttr
    {
        // Use this mask to retrieve the type visibility information.

        tdVisibilityMask = 0x00000007,
        tdNotPublic = 0x00000000,
        // Class is not public scope.

        tdPublic = 0x00000001,
        // Class is public scope.

        tdNestedPublic = 0x00000002,
        // Class is nested with public visibility.

        tdNestedPrivate = 0x00000003,
        // Class is nested with private visibility.

        tdNestedFamily = 0x00000004,
        // Class is nested with family visibility.

        tdNestedAssembly = 0x00000005,
        // Class is nested with assembly visibility.

        tdNestedFamANDAssem = 0x00000006,
        // Class is nested with family and assembly visibility.

        tdNestedFamORAssem = 0x00000007,
        // Class is nested with family or assembly visibility.


        // Use this mask to retrieve class layout information

        tdLayoutMask = 0x00000018,
        tdAutoLayout = 0x00000000,
        // Class fields are auto-laid out

        tdSequentialLayout = 0x00000008,
        // Class fields are laid out sequentially

        tdExplicitLayout = 0x00000010,
        // Layout is supplied explicitly

        // end layout mask


        // Use this mask to retrieve class semantics information.

        tdClassSemanticsMask = 0x00000060,
        tdClass = 0x00000000,
        // Type is a class.

        tdInterface = 0x00000020,
        // Type is an interface.

        // end semantics mask


        // Special semantics in addition to class semantics.

        tdAbstract = 0x00000080,
        // Class is abstract

        tdSealed = 0x00000100,
        // Class is concrete and may not be extended

        tdSpecialName = 0x00000400,
        // Class name is special. Name describes how.


        // Implementation attributes.

        tdImport = 0x00001000,
        // Class / interface is imported

        tdSerializable = 0x00002000,
        // The class is Serializable.


        // Use tdStringFormatMask to retrieve string information for native interop

        tdStringFormatMask = 0x00030000,
        tdAnsiClass = 0x00000000,
        // LPTSTR is interpreted as ANSI in this class

        tdUnicodeClass = 0x00010000,
        // LPTSTR is interpreted as UNICODE

        tdAutoClass = 0x00020000,
        // LPTSTR is interpreted automatically

        tdCustomFormatClass = 0x00030000,
        // A non-standard encoding specified by CustomFormatMask

        tdCustomFormatMask = 0x00C00000,
        // Use this mask to retrieve non-standard encoding 

        // information for native interop. 

        // The meaning of the values of these 2 bits is unspecified.


        // end string format mask


        tdBeforeFieldInit = 0x00100000,
        // Initialize the class any time before first static field access.

        tdForwarder = 0x00200000,
        // This ExportedType is a type forwarder.


        // Flags reserved for runtime use.

        tdReservedMask = 0x00040800,
        tdRTSpecialName = 0x00000800,
        // Runtime should check name encoding.

        tdHasSecurity = 0x00040000,
        // Class has security associate with it.

    }

    // Todo: Rename!
    [Flags]
    internal enum CorFieldAttr
    {
        // member access mask - Use this mask to retrieve 

        // accessibility information.

        fdFieldAccessMask = 0x0007,
        fdPrivateScope = 0x0000,
        // Member not referenceable.

        fdPrivate = 0x0001,
        // Accessible only by the parent type.

        fdFamANDAssem = 0x0002,
        // Accessible by sub-types only in this Assembly.

        fdAssembly = 0x0003,
        // Accessibly by anyone in the Assembly.

        fdFamily = 0x0004,
        // Accessible only by type and sub-types.

        fdFamORAssem = 0x0005,
        // Accessibly by sub-types anywhere, plus anyone in assembly.

        fdPublic = 0x0006,
        // Accessibly by anyone who has visibility to this scope.

        // end member access mask

        // field contract attributes.

        fdStatic = 0x0010,
        // Defined on type, else per instance.

        fdInitOnly = 0x0020,
        // Field may only be initialized, not written to after init.

        fdLiteral = 0x0040,
        // Value is compile time constant.

        fdNotSerialized = 0x0080,
        // Field does not have to be serialized when type is remoted.

        fdSpecialName = 0x0200,
        // field is special. Name describes how.

        // interop attributes

        fdPinvokeImpl = 0x2000,
        // Implementation is forwarded through pinvoke.

        // Reserved flags for runtime use only.

        fdReservedMask = 0x9500,
        fdRTSpecialName = 0x0400,
        // Runtime(metadata internal APIs) should check name encoding.

        fdHasFieldMarshal = 0x1000,
        // Field has marshalling information.

        fdHasDefault = 0x8000,
        // Field has default.

        fdHasFieldRVA = 0x0100,
        // Field has RVA.

    }

    // Todo: Rename!
    [Flags]
    internal enum CorMethodAttr
    {
        // member access mask - Use this mask to retrieve 

        // accessibility information.

        mdMemberAccessMask = 0x0007,
        mdPrivateScope = 0x0000,
        // Member not referenceable.

        mdPrivate = 0x0001,
        // Accessible only by the parent type.

        mdFamANDAssem = 0x0002,
        // Accessible by sub-types only in this Assembly.

        mdAssem = 0x0003,
        // Accessibly by anyone in the Assembly.

        mdFamily = 0x0004,
        // Accessible only by type and sub-types.

        mdFamORAssem = 0x0005,
        // Accessibly by sub-types anywhere, plus anyone in assembly.

        mdPublic = 0x0006,
        // Accessibly by anyone who has visibility to this scope.

        // end member access mask


        // method contract attributes.

        mdStatic = 0x0010,
        // Defined on type, else per instance.

        mdFinal = 0x0020,
        // Method may not be overridden.

        mdVirtual = 0x0040,
        // Method virtual.

        mdHideBySig = 0x0080,
        // Method hides by name+sig, else just by name.


        // vtable layout mask - Use this mask to retrieve vtable attributes.

        mdVtableLayoutMask = 0x0100,
        mdReuseSlot = 0x0000,     // The default.

        mdNewSlot = 0x0100,
        // Method always gets a new slot in the vtable.

        // end vtable layout mask


        // method implementation attributes.

        mdCheckAccessOnOverride = 0x0200,
        // Overridability is the same as the visibility.

        mdAbstract = 0x0400,
        // Method does not provide an implementation.

        mdSpecialName = 0x0800,
        // Method is special. Name describes how.


        // interop attributes

        mdPinvokeImpl = 0x2000,
        // Implementation is forwarded through pinvoke.

        mdUnmanagedExport = 0x0008,
        // Managed method exported via thunk to unmanaged code.


        // Reserved flags for runtime use only.

        mdReservedMask = 0xd000,
        mdRTSpecialName = 0x1000,
        // Runtime should check name encoding.

        mdHasSecurity = 0x4000,
        // Method has security associate with it.

        mdRequireSecObject = 0x8000,
        // Method calls another method containing security code.


    }

    // Todo: Rename!
    [Flags]
    internal enum CorMethodImpl
    {
        // code impl mask
        miCodeTypeMask = 0x0003,   // Flags about code type.
        miIL = 0x0000,   // Method impl is IL.
        miNative = 0x0001,   // Method impl is native.
        miOPTIL = 0x0002,   // Method impl is OPTIL
        miRuntime = 0x0003,   // Method impl is provided by the runtime.
                              // end code impl mask

        // managed mask
        miManagedMask = 0x0004,   // Flags specifying whether the code is managed
                                  // or unmanaged.
        miUnmanaged = 0x0004,   // Method impl is unmanaged, otherwise managed.
        miManaged = 0x0000,   // Method impl is managed.
                              // end managed mask

        // implementation info and interop
        miForwardRef = 0x0010,   // Indicates method is defined; used primarily
                                 // in merge scenarios.
        miPreserveSig = 0x0080,   // Indicates method sig is not to be mangled to
                                  // do HRESULT conversion.

        miInternalCall = 0x1000,   // Reserved for internal use.

        miSynchronized = 0x0020,   // Method is single threaded through the body.
        miNoInlining = 0x0008,   // Method may not be inlined.
        miMaxMethodImplVal = 0xffff,   // Range check value
    }

    // Todo: Rename!
    [Flags]
    internal enum CorParamAttr
    {
        pdIn = 0x0001,     // Param is [In]

        pdOut = 0x0002,     // Param is [out]

        pdOptional = 0x0010,     // Param is optional


        // Reserved flags for Runtime use only.

        pdReservedMask = 0xf000,
        pdHasDefault = 0x1000,     // Param has default value.

        pdHasFieldMarshal = 0x2000,     // Param has FieldMarshal.


        pdUnused = 0xcfe0,
    }

    // Todo: Rename!
    [Flags]
    internal enum CorEventAttr
    {
        evSpecialName = 0x0200,
        // event is special. Name describes how.


        // Reserved flags for Runtime use only.

        evReservedMask = 0x0400,
        evRTSpecialName = 0x0400,
        // Runtime(metadata internal APIs) should check name encoding.

    }

    // Todo: Rename!
    [Flags]
    internal enum CorPropertyAttr
    {
        prSpecialName = 0x0200,
        // property is special. Name describes how.


        // Reserved flags for Runtime use only.

        prReservedMask = 0xf400,
        prRTSpecialName = 0x0400,
        // Runtime(metadata internal APIs) should check name encoding.

        prHasDefault = 0x1000,     // Property has default


        prUnused = 0xe9ff,
    }

    // Todo: Rename!
    [Flags]
    internal enum CorMethodSemanticsAttr
    {
        msSetter = 0x0001,     // Setter for property

        msGetter = 0x0002,     // Getter for property

        msOther = 0x0004,     // other method for property or event

        msAddOn = 0x0008,     // AddOn method for event

        msRemoveOn = 0x0010,     // RemoveOn method for event

        msFire = 0x0020,     // Fire method for event

    }

    // Todo: Rename!
    [Flags]
    internal enum CorPinvokeMap
    {
        pmNoMangle = 0x0001,
        // Pinvoke is to use the member name as specified.


        // Use this mask to retrieve the CharSet information.

        pmCharSetMask = 0x0006,
        pmCharSetNotSpec = 0x0000,
        pmCharSetAnsi = 0x0002,
        pmCharSetUnicode = 0x0004,
        pmCharSetAuto = 0x0006,

        pmBestFitUseAssem = 0x0000,
        pmBestFitEnabled = 0x0010,
        pmBestFitDisabled = 0x0020,
        pmBestFitMask = 0x0030,

        pmThrowOnUnmappableCharUseAssem = 0x0000,
        pmThrowOnUnmappableCharEnabled = 0x1000,
        pmThrowOnUnmappableCharDisabled = 0x2000,
        pmThrowOnUnmappableCharMask = 0x3000,

        pmSupportsLastError = 0x0040,
        // Information about target function. Not relevant for fields.


        // None of the calling convention flags is relevant for fields.

        pmCallConvMask = 0x0700,
        pmCallConvWinapi = 0x0100,
        // Pinvoke will use native callconv appropriate to target windows platform.

        pmCallConvCdecl = 0x0200,
        pmCallConvStdcall = 0x0300,
        pmCallConvThiscall = 0x0400,
        // In M9, pinvoke will raise exception.

        pmCallConvFastcall = 0x0500,

        pmMaxValue = 0xFFFF,
    }

    // Todo: Rename!
    [Flags]
    internal enum CorAssemblyFlags
    {
        afPublicKey = 0x0001,
        // The assembly ref holds the full (unhashed) public key.


        afPA_None = 0x0000,
        // Processor Architecture unspecified

        afPA_MSIL = 0x0010,
        // Processor Architecture: neutral (PE32)

        afPA_x86 = 0x0020,
        // Processor Architecture: x86 (PE32)

        afPA_IA64 = 0x0030,
        // Processor Architecture: Itanium (PE32+)

        afPA_AMD64 = 0x0040,
        // Processor Architecture: AMD X64 (PE32+)

        afPA_Specified = 0x0080,
        // Propagate PA flags to AssemblyRef record

        afPA_Mask = 0x0070,
        // Bits describing the processor architecture

        afPA_FullMask = 0x00F0,
        // Bits describing the PA incl. Specified

        afPA_Shift = 0x0004,
        // NOT A FLAG, shift count in PA flags <--> index conversion


        afEnableJITcompileTracking = 0x8000, // From "DebuggableAttribute".

        afDisableJITcompileOptimizer = 0x4000, // From "DebuggableAttribute".


        afRetargetable = 0x0100,
        // The assembly can be retargeted (at runtime) to an

        //  assembly from a different publisher.

    }

    // Todo: Rename!
    [Flags]
    internal enum CorFileFlags
    {
        ffContainsMetaData = 0x0000,
        // This is not a resource file

        ffContainsNoMetaData = 0x0001,
        // This is a resource file or other non-metadata-containing file

    }

    // Todo: Rename!
    [Flags]
    internal enum CorManifestResourceFlags
    {
        mrVisibilityMask = 0x0007,
        mrPublic = 0x0001,
        // The Resource is exported from the Assembly.

        mrPrivate = 0x0002,
        // The Resource is private to the Assembly.
    }

    // Todo: Rename!
    [Flags]
    internal enum CorGenericParamAttr
    {
        // Variance of type parameters, only applicable to generic parameters 
        // for generic interfaces and delegates
        gpVarianceMask = 0x0003,
        gpNonVariant = 0x0000,
        gpCovariant = 0x0001,
        gpContravariant = 0x0002,

        // Special constraints, applicable to any type parameters
        gpSpecialConstraintMask = 0x001C,
        gpNoSpecialConstraint = 0x0000,
        gpReferenceTypeConstraint = 0x0004,      // type argument must be a reference type
        gpNotNullableValueTypeConstraint = 0x0008,      // type argument must be a value
                                                        // type but not Nullable
        gpDefaultConstructorConstraint = 0x0010, // type argument must have a public
                                                 // default constructor
    }

    internal class Program
    {
        // Todo: Remove!
        private static IList<CoffSectionHeader> _coffSectionHeaders;

        private static readonly IDictionary<int, string> _metadataTables = new Dictionary<int, string>
        {
            { 00, "Module"                 },
            { 01, "TypeRef"                },
            { 02, "TypeDef"                },
            { 03, "FieldPtr"               },
            { 04, "Field"                  },
            { 05, "MethodPtr"              },
            { 06, "MethodDef"              },
            { 07, "ParamPtr"               },
            { 08, "Param"                  },
            { 09, "InterfaceImpl"          },
            { 10, "MemberRef"              },
            { 11, "Constant"               },
            { 12, "CustomAttribute"        },
            { 13, "FieldMarshal"           },
            { 14, "DeclSecurity"           },
            { 15, "ClassLayout"            },
            { 16, "FieldLayout"            },
            { 17, "StandAloneSig"          },
            { 18, "EventMap"               },
            { 19, "EventPtr"               },
            { 20, "Event"                  },
            { 21, "PropertyMap"            },
            { 22, "PropertyPtr"            },
            { 23, "Property"               },
            { 24, "MethodSemantics"        },
            { 25, "MethodImpl"             },
            { 26, "ModuleRef"              },
            { 27, "TypeSpec"               },
            { 28, "ImplMap"                },
            { 29, "FieldRVA"               },
            { 30, "ENCLog"                 },
            { 31, "ENCMap"                 },
            { 32, "Assembly"               },
            { 33, "AssemblyProcessor"      },
            { 34, "AssemblyOS"             },
            { 35, "AssemblyRef"            },
            { 36, "AssemblyRefProcessor"   },
            { 37, "AssemblyRefOS"          },
            { 38, "File"                   },
            { 39, "ExportedType"           },
            { 40, "ManifestResource"       },
            { 41, "NestedClass"            },
            { 42, "GenericParam"           },
            { 43, "MethodSpec"             },
            { 44, "GenericParamConstraint" },
        };

        private static void Main()
        {
            //const string path = @"C:\Users\r3db\Desktop\dll\odbc32.dll";
            const string path = "PeUtility.dll";

            ReadPe(path);
        }

        // Helpers
        private static void ReadPe(string file)
        {
            using (var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                var dosHeader                   = ReadDosHeader(br, false);
                var coffHeader                  = ReadCoffHeader(br, dosHeader.Lfanew, false);

                if (coffHeader.SizeOfOptionalHeader == 0)
                {
                    throw new NotSupportedException();
                }

                var coffOptionalHeader          = ReadCoffOptionalHeader(br, false);
                var coffOptionalDataDirectories = ReadCoffOptionalDataDirectories(br, coffOptionalHeader.NumberOfRvaAndSizes, false);
                var coffSectionHeaders          = ReadCoffSectionHeaders(br, coffHeader.NumberOfSections, false);

                _coffSectionHeaders = coffSectionHeaders;

                var directoryTables             = ReadCoffDirectoryTables(br, coffOptionalHeader, coffOptionalDataDirectories, false);
            }
        }

        private static DosHeader ReadDosHeader(BinaryReader reader, bool present)
        {
            var result = DosHeaderReader.Read(reader);
            
            if (present)
            {
                DosHeaderPresenter.Present(result);
            }

            return result;
        }

        private static CoffHeader ReadCoffHeader(BinaryReader reader, uint lfanewOffset, bool present)
        {
            var result = CoffHeaderReader.Read(lfanewOffset, reader);
            
            if (present)
            {
                CoffHeaderPresenter.Present(result);
            }

            return result;
        }

        private static CoffOptionalHeader ReadCoffOptionalHeader(BinaryReader reader, bool present)
        {
            var result = CoffOptionalHeaderReader.Read(reader);
            
            if (present)
            {
                CoffOptionalHeaderPresenter.Present(result);
            }

            return result;
        }

        private static IList<CoffOptionalDataDirectory> ReadCoffOptionalDataDirectories(BinaryReader reader, uint numberOfRvaAndSizes, bool present)
        {
            var result = CoffOptionalDataDirectoryReader.Read(reader, numberOfRvaAndSizes);

            if (present)
            {
                CoffOptionalDataDirectoryPresenter.Present(result);
            }

            return result;
        }

        private static IList<CoffSectionHeader> ReadCoffSectionHeaders(BinaryReader reader, uint numberOfSections, bool present)
        {
            var result = new List<CoffSectionHeader>();

            for (int i = 0; i < numberOfSections; i++)
            {
                result.Add(CoffSectionHeaderReader.Read(reader));
            }

            if (present)
            {
                CoffSectionHeaderPresenter.Present(result);
            }

            return result;
        }

        private static IList<CoffDirectoryTable> ReadCoffDirectoryTables(BinaryReader reader, CoffOptionalHeader optionalHeader, IList<CoffOptionalDataDirectory> directories, bool present)
        {
            var result = new List<CoffDirectoryTable>();

            foreach (var item in directories)
            {
                if (item.VirtualAddress == 0 || item.Size == 0)
                {
                    continue;
                }

                reader.BaseStream.Position = Rva2Offset(item.VirtualAddress);

                switch (item.Kind)
                {
                    case CoffOptionalDataDirectoryKind.ExportTable:
                    {
                        var table = CoffDirectoryTableExportReader.Read(reader, x => Rva2Offset(x));
                        result.Add(table);

                        if (present)
                        {
                            CoffDirectoryTableExportPresenter.Present(table);
                        }

                        break;
                    }
                    case CoffOptionalDataDirectoryKind.ImportTable:
                    {
                        var table = CoffDirectoryTableImportReader.Read(reader, optionalHeader, x => Rva2Offset(x));
                        result.Add(table);

                        if (present)
                        {
                            CoffDirectoryTableImportPresenter.Present(table);
                        }

                        break;
                    }
                    case CoffOptionalDataDirectoryKind.ClrRuntimeHeader:
                    {
                        var cliHeader = ReadCoffClrRuntimeTableHeader(reader, present);
                        break;
                    }
                }
            }

            return result;
        }







        // https://www.codeproject.com/Articles/12585/The-NET-File-Format
        private static CoffDirectoryTableExport ReadCoffClrRuntimeTableHeader(BinaryReader reader, bool present)
        {
            var cliHeader         = ReadCliHeader(reader, false);
            var cliMetadataHeader = ReadCliMetadataHeader(cliHeader, reader, false);

            var offset = reader.BaseStream.Position;

            var streamHeaders     = ReadCliMetadataStreamHeaders(reader, cliMetadataHeader.NumberOfStreams, true);

            foreach (var item in streamHeaders)
            {
                //reader.BaseStream.Position = offset + streamHeaders[0].Offset;

                Shell.WriteHeader("CLI Metadata Table Stream Header");
                var reserved   = reader.ReadUInt32();   // Always 0
                var major      = reader.ReadByte();
                var minor      = reader.ReadByte();
                var heapSizes  = reader.ReadByte();     // => For now always 2, ushort!
                var rid        = reader.ReadByte();     // Reserved
                var maskValid  = reader.ReadUInt64();   // Valid
                var maskSorted = reader.ReadUInt64();   // Sorted

                var indexSize               = 2;
                var maskValidBitArray       = ToBitArray(maskValid);
                var maskSortedBitArray      = ToBitArray(maskSorted);
                var maskValidBitArrayCount  = maskValidBitArray.Count(x => x == true);
                var maskSortedBitArrayCount = maskSortedBitArray.Count(x => x == true);

                Console.WriteLine("Total: {0}", maskValidBitArrayCount);

                var rowCount = new List<uint>();

                for (int i = 0; i < maskValidBitArrayCount; i++)
                {
                    rowCount.Add(reader.ReadUInt32());
                    Console.WriteLine(rowCount.Last());
                }

                for (int i = 0, k = 0; i < maskValidBitArray.Count; i++)
                {
                    if (maskValidBitArray[i] == true && _metadataTables.ContainsKey(i))
                    {
                        Console.WriteLine("{0} ({1}) {2}", _metadataTables[i], rowCount[k++], maskSortedBitArray[i]);
                    }
                }

                for (int i = 0, k = 0; i < maskValidBitArray.Count; i++)
                {
                    if (maskValidBitArray[i] == true && _metadataTables.ContainsKey(i))
                    {
                        Console.WriteLine(_metadataTables[i]);
                        var w = rowCount[k++];

                        switch (_metadataTables[i])
                        {
                            case "Module":                  // 00
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var generation = reader.ReadUInt16();
                                    var name       = ReadIndex(reader, indexSize);
                                    var mvid       = ReadIndex(reader, indexSize);
                                    var encId      = ReadIndex(reader, indexSize);
                                    var encBaseId  = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tGeneration: {0:x4}", generation);
                                    Console.WriteLine("\tName:       {0:x4}", name);
                                    Console.WriteLine("\tMvid:       {0:x4}", mvid);
                                    Console.WriteLine("\tEncId:      {0:x4}", encId);
                                    Console.WriteLine("\tEncBaseId:  {0:x4}", encBaseId);
                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "TypeRef":                 // 01
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var resolutionScope = ReadIndex(reader, indexSize);
                                    var typeName        = ReadIndex(reader, indexSize);
                                    var typeNamespace   = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tResolutionScope: {0:x4}", resolutionScope);
                                    Console.WriteLine("\tTypeName:        {0:x4}", typeName);
                                    Console.WriteLine("\tTypeNamespace:   {0:x4}", typeNamespace);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "TypeDef":                 // 02
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags           = reader.ReadUInt32();              // Todo: Enum!
                                    var typeName        = ReadIndex(reader, indexSize);
                                    var typeNamespace   = ReadIndex(reader, indexSize);
                                    var extends         = ReadIndex(reader, indexSize);
                                    var fieldList       = ReadIndex(reader, indexSize);
                                    var methodList      = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags:         {0:x4} {1}", flags, ((CorTypeAttr)flags).ToString().Substring(0, Math.Min(((CorTypeAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tTypeName:      {0:x4}", typeName);
                                    Console.WriteLine("\tTypeNamespace: {0:x4}", typeNamespace);
                                    Console.WriteLine("\tExtends:       {0:x4}", extends);
                                    Console.WriteLine("\tFieldList:     {0:x4}", fieldList);
                                    Console.WriteLine("\tMethodLists:   {0:x4}", methodList);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "FieldPtr":                // 03
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "Field":                   // 04
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags     = reader.ReadUInt16();              // Todo: Enum!
                                    var name      = ReadIndex(reader, indexSize);
                                    var signature = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags:     {0:x4} {1}", flags, ((CorFieldAttr)flags).ToString().Substring(0, Math.Min(((CorFieldAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:      {0:x4}", name);
                                    Console.WriteLine("\tSignature: {0:x4}", signature);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "MethodPtr":               // 05
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "MethodDef":               // 06
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var rva       = reader.ReadUInt32();
                                    var implFlags = reader.ReadUInt16();
                                    var flags     = reader.ReadUInt16();
                                    var name      = ReadIndex(reader, indexSize);
                                    var signature = ReadIndex(reader, indexSize);
                                    var paramList = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tRVA:       {0:x8}", rva);
                                    Console.WriteLine("\tImplFlags: {0:x4} {1}", implFlags, ((CorMethodImpl)implFlags).ToString().Substring(0, Math.Min(((CorMethodImpl)implFlags).ToString().Length, 40)));
                                    Console.WriteLine("\tFlags:     {0:x4} {1}", flags, ((CorMethodAttr)flags).ToString().Substring(0, Math.Min(((CorMethodAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:      {0:x4}", name);
                                    Console.WriteLine("\tSignature: {0:x4}", signature);
                                    Console.WriteLine("\tParamList: {0:x4}", paramList);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ParamPtr":                // 07
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "Param":                   // 08
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags     = reader.ReadUInt16();
                                    var name      = ReadIndex(reader, indexSize);
                                    var sequence  = reader.ReadUInt16();

                                    Console.WriteLine("\tFlags:    {0:x4} {1}", flags, ((CorParamAttr)flags).ToString().Substring(0, Math.Min(((CorParamAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:     {0:x4}", name);
                                    Console.WriteLine("\tSequence: {0:x4}", sequence);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "InterfaceImpl":           // 09
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var @class     = ReadIndex(reader, indexSize);
                                    var @interface = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tClass:     {0:x4}", @class);
                                    Console.WriteLine("\tInterface: {0:x4}", @interface);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "MemberRef":               // 10
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var @class    = ReadIndex(reader, indexSize);
                                    var name      = ReadIndex(reader, indexSize);
                                    var signature = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tClass:     {0:x4}", @class);
                                    Console.WriteLine("\tName:      {0:x4}", name);
                                    Console.WriteLine("\tSignature: {0:x4}", signature);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "Constant":                // 11
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var type   = reader.ReadUInt16();
                                    var parent = ReadIndex(reader, indexSize);
                                    var value  = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tType:   {0:x4}", type);
                                    Console.WriteLine("\tParent: {0:x4}", parent);
                                    Console.WriteLine("\tValue:  {0:x4}", value);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "CustomAttribute":         // 12
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var parent = ReadIndex(reader, indexSize);
                                    var type   = ReadIndex(reader, indexSize);
                                    var value  = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tParent: {0:x4}", parent);
                                    Console.WriteLine("\tType:   {0:x4}", type);
                                    Console.WriteLine("\tValue:  {0:x4}", value);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }   
                            case "FieldMarshal":            // 13
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var parent     = ReadIndex(reader, indexSize);
                                    var nativeType = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tParent:     {0:x4}", parent);
                                    Console.WriteLine("\tNativeType: {0:x4}", nativeType);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "DeclSecurity":            // 14
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var action        = reader.ReadUInt16();
                                    var parent        = ReadIndex(reader, indexSize);
                                    var permissionSet = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tAction:        {0:x4}", action);
                                    Console.WriteLine("\tParent:        {0:x4}", parent);
                                    Console.WriteLine("\tPermissionSet: {0:x4}", permissionSet);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ClassLayout":             // 15
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var packingSize = reader.ReadUInt16();
                                    var classSize   = reader.ReadUInt32();
                                    var parent      = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tPackingSize: {0:x4}", packingSize);
                                    Console.WriteLine("\tClassSize:   {0:x4}", classSize);
                                    Console.WriteLine("\tParent:      {0:x4}", parent);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "FieldLayout":             // 16
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var offset_1 = reader.ReadUInt32();
                                    var field    = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tOffset: {0:x8}", offset_1);
                                    Console.WriteLine("\tField:  {0:x4}", field);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "StandAloneSig":           // 17
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var signature = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tSignature: {0:x4}", signature);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "EventMap":                // 18
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var parent    = ReadIndex(reader, indexSize);
                                    var eventList = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tParent:    {0:x4}", parent);
                                    Console.WriteLine("\tEventList: {0:x4}", eventList);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "EventPtr":                // 19
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "Event":                   // 20
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags = reader.ReadUInt16();
                                    var name  = ReadIndex(reader, indexSize);
                                    var type  = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags: {0:x4} {1}", flags, ((CorEventAttr)flags).ToString().Substring(0, Math.Min(((CorEventAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:  {0:x4}", name);
                                    Console.WriteLine("\tType:  {0:x4}", type);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "PropertyMap":             // 21
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var parent       = ReadIndex(reader, indexSize);
                                    var propertyList = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tParent:       {0:x4}", parent);
                                    Console.WriteLine("\tPropertyList: {0:x4}", propertyList);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "PropertyPtr":             // 22
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "Property":                // 23
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags = reader.ReadUInt16();
                                    var name  = ReadIndex(reader, indexSize);
                                    var type  = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags: {0:x4} {1}", flags, ((CorPropertyAttr)flags).ToString().Substring(0, Math.Min(((CorPropertyAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:  {0:x4}", name);
                                    Console.WriteLine("\tType:  {0:x4}", type);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "MethodSemantics":         // 24
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var semantics   = reader.ReadUInt16();
                                    var method      = ReadIndex(reader, indexSize);
                                    var association = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags: {0:x4} {1}",    semantics, ((CorMethodSemanticsAttr)semantics).ToString().Substring(0, Math.Min(((CorMethodSemanticsAttr)semantics).ToString().Length, 40)));
                                    Console.WriteLine("\tMethod:  {0:x4}",      method);
                                    Console.WriteLine("\tAssociation:  {0:x4}", association);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "MethodImpl":              // 25
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var @class            = ReadIndex(reader, indexSize);
                                    var methodBody        = ReadIndex(reader, indexSize);
                                    var methodDeclaration = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tClass:             {0:x4}", @class);
                                    Console.WriteLine("\tMethodBody:        {0:x4}", methodBody);
                                    Console.WriteLine("\tMethodDeclaration: {0:x4}", methodDeclaration);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ModuleRef":               // 26
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var name = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tName: {0:x4}", name);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "TypeSpec":                // 27
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var signature = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tSignature: {0:x4}", signature);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ImplMap":                 // 28
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var mappingFlags    = reader.ReadUInt16();
                                    var memberForwarded = ReadIndex(reader, indexSize);
                                    var importName      = ReadIndex(reader, indexSize);
                                    var importScope     = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags:           {0:x4} {1}", mappingFlags, ((CorPinvokeMap)mappingFlags).ToString().Substring(0, Math.Min(((CorPinvokeMap)mappingFlags).ToString().Length, 40)));
                                    Console.WriteLine("\tMemberForwarded: {0:x4}", memberForwarded);
                                    Console.WriteLine("\tImportName:      {0:x4}", importName);
                                    Console.WriteLine("\tImportScope:     {0:x4}", importScope);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "FieldRVA":                // 29
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var rva   = reader.ReadUInt32();
                                    var field = ReadIndex(reader, indexSize);
                                    
                                    Console.WriteLine("\tRVA:   {0:x8}", rva);
                                    Console.WriteLine("\tField: {0:x4}", field);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ENCLog":                  // 30
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "ENCMap":                  // 31
                            {
                                // Todo: Complete!
                                throw new NotSupportedException();
                            }
                            case "Assembly":                // 32
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var hashAlgId      = reader.ReadUInt32();
                                    var majorVersion   = reader.ReadUInt16();
                                    var minorVersion   = reader.ReadUInt16();
                                    var buildNumber    = reader.ReadUInt16();
                                    var revisionNumber = reader.ReadUInt16();
                                    var flags          = reader.ReadUInt32();
                                    var publickKey     = ReadIndex(reader, indexSize);
                                    var name           = ReadIndex(reader, indexSize);
                                    var culture        = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tHashAlgId:      {0:x4} {1}", hashAlgId, ((AssemblyHashAlgorithm)hashAlgId).ToString().Substring(0, Math.Min(((AssemblyHashAlgorithm)hashAlgId).ToString().Length, 40)));
                                    Console.WriteLine("\tMajorVersion:   {0:x4}", majorVersion);
                                    Console.WriteLine("\tMinorVersion:   {0:x4}", minorVersion);
                                    Console.WriteLine("\tBuildNumber:    {0:x4}", buildNumber);
                                    Console.WriteLine("\tRevisionNumber: {0:x4}", revisionNumber);
                                    Console.WriteLine("\tFlags:          {0:x4} {1}", flags, ((CorAssemblyFlags)flags).ToString().Substring(0, Math.Min(((CorAssemblyFlags)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tAssociation:    {0:x4}", publickKey);
                                    Console.WriteLine("\tName:           {0:x4}", name);
                                    Console.WriteLine("\tCulture:        {0:x4}", culture);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "AssemblyProcessor":       // 33
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var processor = reader.ReadUInt32();
  
                                    Console.WriteLine("\tProcessor: {0:x4}", processor);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "AssemblyOS":              // 34
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var oSPlatformID   = reader.ReadUInt32();
                                    var oSMajorVersion = reader.ReadUInt32();
                                    var oSMinorVersion = reader.ReadUInt32();

                                    Console.WriteLine("\toSPlatformID:   {0:x8}", oSPlatformID);
                                    Console.WriteLine("\toSMajorVersion: {0:x8}", oSMajorVersion);
                                    Console.WriteLine("\toSMinorVersion: {0:x8}", oSMinorVersion);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "AssemblyRef":             // 35
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var majorVersion     = reader.ReadUInt16();
                                    var minorVersion     = reader.ReadUInt16();
                                    var buildNumber      = reader.ReadUInt16();
                                    var revisionNumber   = reader.ReadUInt16();
                                    var flags            = reader.ReadUInt32();
                                    var publicKeyOrToken = ReadIndex(reader, indexSize);
                                    var name             = ReadIndex(reader, indexSize);
                                    var culture          = ReadIndex(reader, indexSize);
                                    var hashValue        = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tMajorVersion:     {0:x4}", majorVersion);
                                    Console.WriteLine("\tMinorVersion:     {0:x4}", minorVersion);
                                    Console.WriteLine("\tBuildNumber:      {0:x4}", buildNumber);
                                    Console.WriteLine("\tRevisionNumber:   {0:x4}", revisionNumber);
                                    Console.WriteLine("\tFlags:            {0:x4} {1}", flags, ((CorFileFlags)flags).ToString().Substring(0, Math.Min(((CorFileFlags)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tPublicKeyOrToken: {0:x4}", publicKeyOrToken);
                                    Console.WriteLine("\tName:             {0:x4}", name);
                                    Console.WriteLine("\tCulture:          {0:x4}", culture);
                                    Console.WriteLine("\tHashValue:        {0:x4}", hashValue);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "AssemblyRefProcessor":    // 36
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var processor   = reader.ReadUInt32();
                                    var assemblyRef = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tProcessor:   {0:x8}", processor);
                                    Console.WriteLine("\tAssemblyRef: {0:x4}", assemblyRef);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "AssemblyRefOS":           // 37
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var oSPlatformId   = reader.ReadUInt32();
                                    var oSMajorVersion = reader.ReadUInt32();
                                    var oSMinorVersion = reader.ReadUInt32();
                                    var assemblyRef    = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\toSPlatformId:   {0:x8}", oSPlatformId);
                                    Console.WriteLine("\toSMajorVersion: {0:x8}", oSMajorVersion);
                                    Console.WriteLine("\toSMinorVersion: {0:x8}", oSMinorVersion);
                                    Console.WriteLine("\tAssemblyRef:    {0:x4}", assemblyRef);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "File":                    // 38
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags     = reader.ReadUInt32();
                                    var name      = ReadIndex(reader, indexSize);
                                    var hashValue = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags:     {0:x4} {1}", flags, ((CorFileFlags)flags).ToString().Substring(0, Math.Min(((CorFileFlags)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:      {0:x8}", name);
                                    Console.WriteLine("\tHashValue: {0:x8}", hashValue);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ExportedType":            // 39
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var flags          = reader.ReadUInt32();
                                    var typeDefId      = ReadIndex(reader, 4);
                                    var typeName       = ReadIndex(reader, indexSize);
                                    var typeNamespace  = ReadIndex(reader, indexSize);
                                    var implementation = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tFlags:          {0:x4} {1}", flags, ((TypeAttributes)flags).ToString().Substring(0, Math.Min(((TypeAttributes)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tTypeDefId:      {0:x8}", typeDefId);
                                    Console.WriteLine("\ttypeName:       {0:x4}", typeName);
                                    Console.WriteLine("\tTypeNamespace:  {0:x4}", typeNamespace);
                                    Console.WriteLine("\tImplementation: {0:x4}", implementation);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "ManifestResource":        // 40
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var offset_1       = reader.ReadUInt32();
                                    var flags          = reader.ReadUInt32();
                                    var name           = ReadIndex(reader, indexSize);
                                    var implementation = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tOffset:         {0:x8}", offset_1);
                                    Console.WriteLine("\tFlags:          {0:x4} {1}", flags, ((CorManifestResourceFlags)flags).ToString().Substring(0, Math.Min(((CorManifestResourceFlags)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tName:           {0:x4}", name);
                                    Console.WriteLine("\tImplementation: {0:x4}", implementation);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "NestedClass":             // 41
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var nestedClass    = ReadIndex(reader, indexSize);
                                    var enclosingClass = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tNestedClass:    {0:x4}", nestedClass);
                                    Console.WriteLine("\tEnclosingClass: {0:x4}", enclosingClass);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "GenericParam":            // 42
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var number = reader.ReadUInt16();
                                    var flags  = reader.ReadUInt16();
                                    var owner  = ReadIndex(reader, indexSize);
                                    var name   = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tNumber: {0:x4}", number);
                                    Console.WriteLine("\tFlags:  {0:x4} {1}", flags, ((CorGenericParamAttr)flags).ToString().Substring(0, Math.Min(((CorGenericParamAttr)flags).ToString().Length, 40)));
                                    Console.WriteLine("\tOwner:  {0:x4}", owner);
                                    Console.WriteLine("\tName:   {0:x4}", name);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "MethodSpec":              // 43
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var method     = ReadIndex(reader, indexSize);
                                    var signature = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tMethod:    {0:x4}", method);
                                    Console.WriteLine("\tSignature: {0:x4}", signature);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            case "GenericParamConstraint":  // 44
                            {
                                for (int _ = 0; _ < w; _++)
                                {
                                    var owner      = ReadIndex(reader, indexSize);
                                    var constraint = ReadIndex(reader, indexSize);

                                    Console.WriteLine("\tOwner:      {0:x4}", owner);
                                    Console.WriteLine("\tConstraint: {0:x4}", constraint);

                                    Console.WriteLine("\t- - - - - - - - - - - - - - - - - - -");
                                }

                                break;
                            }
                            default:
                            {
                                throw new NotImplementedException();
                            }
                        }
                    }
                }

                // Todo: Remove!
                break;
            }

            return null;
        }







        // Done!
        private static CliHeader ReadCliHeader(BinaryReader reader, bool present)
        {
            var header = CliHeaderReader.Read(reader);

            if(present)
            {
                CliHeaderPresenter.Present(header);
            }

            return header;
        }

        private static CliMetadataHeader ReadCliMetadataHeader(CliHeader cliHeader, BinaryReader reader, bool present)
        {
            reader.BaseStream.Position = Rva2Offset(cliHeader.MetadataRva);

            var header = CliMetadataHeaderReader.Read(reader);

            if (present)
            {
                CliMetadataHeaderPresenter.Present(header);
            }

            return header;
        }

        private static IList<CliMetadataStreamHeader> ReadCliMetadataStreamHeaders(BinaryReader reader, ushort numberOfStreams, bool present)
        {
            var result = CliMetadataStreamHeaderReader.Read(reader, numberOfStreams);

            if (present)
            {
                Shell.Table("CLI Stream Header", result, x =>
                {
                    x.Add(nameof(CliMetadataStreamHeader.Offset), "{0:x8}", 8);
                    x.Add(nameof(CliMetadataStreamHeader.Size), "{0:x8}", 8);
                    x.Add(nameof(CliMetadataStreamHeader.Name), "'{0}'", 65);
                });
            }

            return result;
        }

        private static uint ReadIndex(BinaryReader reader, int size)
        {
            switch (size)
            {
                case 2: return reader.ReadUInt16();
                case 4: return reader.ReadUInt16();
            }

            throw new ArgumentOutOfRangeException();
        }






        private static IList<bool> ToBitArray(ulong value)
        {
            var result = new List<bool>();

            for (int i = 0; i < sizeof(ulong) * 8; i++)
            {
                result.Add((value & 1) == 1);
                value >>= 1;
            }

            return result;
        }

        // Based on this one: https://www.codeproject.com/Articles/3262/A-NET-assembly-viewer
        private static uint Rva2Offset(uint rva)
        {
            foreach (var section in _coffSectionHeaders)
            {
                if (rva >= section.VirtualAddress && rva < section.VirtualAddress + section.SizeOfRawData)
                {
                    return section.PointerToRawData + (rva - section.VirtualAddress);
                }
            }

            throw new ArgumentOutOfRangeException("Invalid RVA address.");
        }
    }
}