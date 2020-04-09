using System;

namespace Disassembler
{
    [Flags]
    internal enum CliMetadataGenericParamAttribute
    {
        // Variance of type parameters, only applicable to generic parameters for generic interfaces and delegates
        gpVarianceMask                   = 0x0003,
        gpNonVariant                     = 0x0000,
        gpCovariant                      = 0x0001,
        gpContravariant                  = 0x0002,

        // Special constraints, applicable to any type parameters
        gpSpecialConstraintMask          = 0x001C,
        gpNoSpecialConstraint            = 0x0000,
        gpReferenceTypeConstraint        = 0x0004, // type argument must be a reference type
        gpNotNullableValueTypeConstraint = 0x0008, // type argument must be a value type but not Nullable
        gpDefaultConstructorConstraint   = 0x0010, // type argument must have a public default constructor
    }
}