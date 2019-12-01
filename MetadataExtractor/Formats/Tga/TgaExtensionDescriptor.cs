﻿// Copyright (c) Drew Noakes and contributors. All Rights Reserved. Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace MetadataExtractor.Formats.Tga
{
    /// <author>Dmitry Shechtman</author>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class TgaExtensionDescriptor : TagDescriptor<TgaExtensionDirectory>
    {
        public TgaExtensionDescriptor(TgaExtensionDirectory directory)
            : base(directory)
        {
        }

        public override string? GetDescription(int tagType)
        {
            return tagType switch
            {
                TgaExtensionDirectory.TagAttributesType => GetAttributesTypeDescription(),
                _ => base.GetDescription(tagType),
            };
        }

        private string? GetAttributesTypeDescription()
        {
            return GetIndexedDescription(
                TgaExtensionDirectory.TagAttributesType,
                "No alpha data included",
                "Undefined alpha data; ignore",
                "Undefined alpha data; retain",
                "Useful alpha data",
                "Pre-multiplied alpha data");
        }
    }
}
