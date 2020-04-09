using System;
using System.Collections.Generic;
using System.Linq;

namespace Disassembler
{
    internal static class CliMetadataTokenBasePresenter
    { 
        internal static void Present(IList<IList<CliMetadataTokenBase>> tokens, uint indexSize)
        {
            foreach (var item in tokens)
            {
                var first = item[0];

                switch (first.Kind)
                {
                    case CliMetadataToken.Module:
                    {
                        CliMetadataTokenModulePresenter.Present(first.Kind, item.OfType<CliMetadataTokenModule>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.TypeRef:
                    {
                        CliMetadataTokenTypeRefPresenter.Present(first.Kind, item.OfType<CliMetadataTokenTypeRef>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.TypeDef:
                    {
                        CliMetadataTokenTypeDefPresenter.Present(first.Kind, item.OfType<CliMetadataTokenTypeDef>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.FieldPtr:
                    {
                        throw new NotSupportedException();
                    }
                    case CliMetadataToken.Field:
                    {
                        CliMetadataTokenFieldPresenter.Present(first.Kind, item.OfType<CliMetadataTokenField>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.MethodPtr:
                    {
                        throw new NotSupportedException();
                    }
                    case CliMetadataToken.MethodDef:
                    {
                        CliMetadataTokenMethodDefPresenter.Present(first.Kind, item.OfType<CliMetadataTokenMethodDef>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.ParamPtr:
                    {
                        throw new NotSupportedException();
                    }
                    case CliMetadataToken.Param:
                    {
                        CliMetadataTokenParamPresenter.Present(first.Kind, item.OfType<CliMetadataTokenParam>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.InterfaceImpl:
                    {
                        CliMetadataTokenInterfaceImplPresenter.Present(first.Kind, item.OfType<CliMetadataTokenInterfaceImpl>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.MemberRef:
                    {
                        CliMetadataTokenMemberRefPresenter.Present(first.Kind, item.OfType<CliMetadataTokenMemberRef>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.Constant:
                    {
                        CliMetadataTokenConstantPresenter.Present(first.Kind, item.OfType<CliMetadataTokenConstant>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.CustomAttribute:
                    {
                        CliMetadataTokenCustomAttributePresenter.Present(first.Kind, item.OfType<CliMetadataTokenCustomAttribute>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.FieldMarshal:
                    {
                        CliMetadataTokenFieldMarshalPresenter.Present(first.Kind, item.OfType<CliMetadataTokenFieldMarshal>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.DeclSecurity:
                    {
                        CliMetadataTokenDeclSecurityPresenter.Present(first.Kind, item.OfType<CliMetadataTokenDeclSecurity>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.ClassLayout:
                    {
                        CliMetadataTokenClassLayoutPresenter.Present(first.Kind, item.OfType<CliMetadataTokenClassLayout>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.FieldLayout:
                    {
                        CliMetadataTokenFieldLayoutPresenter.Present(first.Kind, item.OfType<CliMetadataTokenFieldLayout>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.StandAloneSig:
                    {
                        CliMetadataTokenStandAloneSigPresenter.Present(first.Kind, item.OfType<CliMetadataTokenStandAloneSig>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.EventMap:
                    {
                        CliMetadataTokenEventMapPresenter.Present(first.Kind, item.OfType<CliMetadataTokenEventMap>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.EventPtr:
                    {
                        throw new NotSupportedException();
                    }
                    case CliMetadataToken.Event:
                    {
                        CliMetadataTokenEventPresenter.Present(first.Kind, item.OfType<CliMetadataTokenEvent>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.PropertyMap:
                    {
                        CliMetadataTokenPropertyMapPresenter.Present(first.Kind, item.OfType<CliMetadataTokenPropertyMap>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.PropertyPtr:
                    {
                        throw new NotSupportedException();
                    }
                    case CliMetadataToken.Property:
                    {
                        CliMetadataTokenPropertyPresenter.Present(first.Kind, item.OfType<CliMetadataTokenProperty>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.MethodSemantics:
                    {
                        CliMetadataTokenMethodSemanticsPresenter.Present(first.Kind, item.OfType<CliMetadataTokenMethodSemantics>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.MethodImpl:
                    {
                        CliMetadataTokenMethodImplPresenter.Present(first.Kind, item.OfType<CliMetadataTokenMethodImpl>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.ModuleRef:
                    {
                        CliMetadataTokenModuleRefPresenter.Present(first.Kind, item.OfType<CliMetadataTokenModuleRef>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.TypeSpec:
                    {
                        CliMetadataTokenTypeSpecPresenter.Present(first.Kind, item.OfType<CliMetadataTokenTypeSpec>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.ImplMap:
                    {
                        CliMetadataTokenImplMapPresenter.Present(first.Kind, item.OfType<CliMetadataTokenImplMap>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.FieldRva:
                    {
                        CliMetadataTokenFieldRvaPresenter.Present(first.Kind, item.OfType<CliMetadataTokenFieldRva>(), indexSize);
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
                        CliMetadataTokenAssemblyPresenter.Present(first.Kind, item.OfType<CliMetadataTokenAssembly>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.AssemblyProcessor:
                    {
                        CliMetadataTokenAssemblyProcessorPresenter.Present(first.Kind, item.OfType<CliMetadataTokenAssemblyProcessor>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.AssemblyOS:
                    {
                        CliMetadataTokenAssemblyOSPresenter.Present(first.Kind, item.OfType<CliMetadataTokenAssemblyOS>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.AssemblyRef:
                    {
                        CliMetadataTokenAssemblyRefPresenter.Present(first.Kind, item.OfType<CliMetadataTokenAssemblyRef>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.AssemblyRefProcessor:
                    {
                        CliMetadataTokenAssemblyRefProcessorPresenter.Present(first.Kind, item.OfType<CliMetadataTokenAssemblyRefProcessor>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.AssemblyRefOS:
                    {
                        CliMetadataTokenAssemblyRefOSPresenter.Present(first.Kind, item.OfType<CliMetadataTokenAssemblyRefOS>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.File:
                    {
                        CliMetadataTokenFilePresenter.Present(first.Kind, item.OfType<CliMetadataTokenFile>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.ExportedType:
                    {
                        CliMetadataTokenExportedTypePresenter.Present(first.Kind, item.OfType<CliMetadataTokenExportedType>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.ManifestResource:
                    {
                        CliMetadataTokenManifestResourcePresenter.Present(first.Kind, item.OfType<CliMetadataTokenManifestResource>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.NestedClass:
                    {
                        CliMetadataTokenNestedClassPresenter.Present(first.Kind, item.OfType<CliMetadataTokenNestedClass>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.GenericParam:
                    {
                        CliMetadataTokenGenericParamPresenter.Present(first.Kind, item.OfType<CliMetadataTokenGenericParam>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.MethodSpec:
                    {
                        CliMetadataTokenMethodSpecPresenter.Present(first.Kind, item.OfType<CliMetadataTokenMethodSpec>(), indexSize);
                        break;
                    }
                    case CliMetadataToken.GenericParamConstraint:
                    {
                        CliMetadataTokenGenericParamConstraintPresenter.Present(first.Kind, item.OfType<CliMetadataTokenGenericParamConstraint>(), indexSize);
                        break;
                    }
                    default:
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }
    }
}