// Guids.cs
// MUST match guids.h
using System;

namespace lot224.FileSwap
{
    static class GuidList
    {
        public const string guidFileSwapPkgString = "176037d5-fb02-4fc2-b601-598159fe71d2";
        public const string guidFileSwapCmdSetString = "806f30f8-af76-4f72-b215-324906456e62";
        public const string guidOptionsString = "40A2E3AD-28DC-43BF-BA78-058BA6EF29DB";

        public static readonly Guid guidFileSwapCmdSet = new Guid(guidFileSwapCmdSetString);
    };
}