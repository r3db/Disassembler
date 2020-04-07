using System;

namespace PeUtility
{
    internal enum CoffOptionalDataDirectoryKind
    {
        ExportTable           = 0,
        ImportTable           = 1,
        ResourceTable         = 2,
        ExceptionTable        = 3,
        CertificateTable      = 4,
        BaseRelocationTable   = 5,
        Debug                 = 6,
        Architecture          = 7,
        GlobalPtr             = 8,
        TLSTable              = 9,
        LoadConfigTable       = 10,
        BoundImport           = 11,
        IAT                   = 12,
        DelayImportDescriptor = 13,
        ClrRuntimeHeader      = 14,
        Reserved              = 15,
    }
}