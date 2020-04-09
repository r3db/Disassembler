using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenBaseReader
    { 
        internal static IList<IList<CliMetadataTokenBase>> Read(MetadataStreamReader reader, CliMetadataTableHeader tableHeader, uint indexSize)
        {
            var result = new List<IList<CliMetadataTokenBase>>();

            for (int i = 0, k = 0; i < tableHeader.MaskValidArray.Count; i++)
            {
                var token = (CliMetadataToken)i;

                if (tableHeader.MaskValidArray[i] == true && Enum.IsDefined(typeof(CliMetadataToken), i))
                {
                    var rowCount = tableHeader.RowCount[k++];

                    switch (token)
                    {
                        case CliMetadataToken.Module:
                        {
                            result.Add(CliMetadataTokenModuleReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.TypeRef:
                        {
                            result.Add(CliMetadataTokenTypeRefReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.TypeDef:
                        {
                            result.Add(CliMetadataTokenTypeDefReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.FieldPtr:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.Field:
                        {
                            result.Add(CliMetadataTokenFieldReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.MethodPtr:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.MethodDef:
                        {
                            result.Add(CliMetadataTokenMethodDefReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ParamPtr:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.Param:
                        {
                            result.Add(CliMetadataTokenParamReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.InterfaceImpl:
                        {
                            result.Add(CliMetadataTokenInterfaceImplReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.MemberRef:
                        {
                            result.Add(CliMetadataTokenMemberRefReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.Constant:
                        {
                            result.Add(CliMetadataTokenConstantReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.CustomAttribute:
                        {
                            result.Add(CliMetadataTokenCustomAttributeReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.FieldMarshal:
                        {
                            result.Add(CliMetadataTokenFieldMarshalReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.DeclSecurity:
                        {
                            result.Add(CliMetadataTokenDeclSecurityReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ClassLayout:
                        {
                            result.Add(CliMetadataTokenClassLayoutReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.FieldLayout:
                        {
                            result.Add(CliMetadataTokenFieldLayoutReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.StandAloneSig:
                        {
                            result.Add(CliMetadataTokenStandAloneSigReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.EventMap:
                        {
                            result.Add(CliMetadataTokenEventMapReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.EventPtr:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.Event:
                        {
                            result.Add(CliMetadataTokenEventReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.PropertyMap:
                        {
                            result.Add(CliMetadataTokenPropertyMapReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.PropertyPtr:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.Property:
                        {
                            result.Add(CliMetadataTokenPropertyReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.MethodSemantics:
                        {
                            result.Add(CliMetadataTokenMethodSemanticsReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.MethodImpl:
                        {
                            result.Add(CliMetadataTokenMethodImplReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ModuleRef:
                        {
                            result.Add(CliMetadataTokenModuleRefReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.TypeSpec:
                        {
                            result.Add(CliMetadataTokenTypeSpecReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ImplMap:
                        {
                            result.Add(CliMetadataTokenImplMapReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.FieldRva:
                        {
                            result.Add(CliMetadataTokenFieldRvaReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ENCLog:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.ENCMap:
                        {
                            throw new NotSupportedException();
                        }
                        case CliMetadataToken.Assembly:
                        {
                            result.Add(CliMetadataTokenAssemblyReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.AssemblyProcessor:
                        {
                            result.Add(CliMetadataTokenAssemblyProcessorReader.Read(reader, rowCount));
                            break;
                        }
                        case CliMetadataToken.AssemblyOS:
                        {
                            result.Add(CliMetadataTokenAssemblyOSReader.Read(reader, rowCount));
                            break;
                        }
                        case CliMetadataToken.AssemblyRef:
                        {
                            result.Add(CliMetadataTokenAssemblyRefReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.AssemblyRefProcessor:
                        {
                            result.Add(CliMetadataTokenAssemblyRefProcessorReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.AssemblyRefOS:
                        {
                            result.Add(CliMetadataTokenAssemblyRefOSReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.File:
                        {
                            result.Add(CliMetadataTokenFileReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ExportedType:
                        {
                            result.Add(CliMetadataTokenExportedTypeReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.ManifestResource:
                        {
                            result.Add(CliMetadataTokenManifestResourceReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.NestedClass:
                        {
                            result.Add(CliMetadataTokenNestedClassReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.GenericParam:
                        {
                            result.Add(CliMetadataTokenGenericParamReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.MethodSpec:
                        {
                            result.Add(CliMetadataTokenMethodSpecReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        case CliMetadataToken.GenericParamConstraint:
                        {
                            result.Add(CliMetadataTokenGenericParamConstraintReader.Read(reader, rowCount, indexSize));
                            break;
                        }
                        default:
                        {
                            throw new NotImplementedException();
                        }
                    }
                }
            }

            return result;
        }
    }
}