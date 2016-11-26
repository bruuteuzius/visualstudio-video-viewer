// Guids.cs
// MUST match guids.h
using System;

namespace DiederingBV.VsvvPackage
{
    static class GuidList
    {
        public const string guidVsvvPackagePkgString = "2f69073d-10f5-412a-a1e9-207504307c25";
        public const string guidVsvvPackageCmdSetString = "74638255-6286-49d0-9e34-80a04dbb17e2";
        public const string guidToolWindowPersistanceString = "04f81819-7727-40a0-b9b2-a6e07c436de8";

        public static readonly Guid guidVsvvPackageCmdSet = new Guid(guidVsvvPackageCmdSetString);
    };
}