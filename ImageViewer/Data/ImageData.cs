﻿using System;

namespace ImageViewer.Data
{
    public class ImageData
    {
        public ImageData() => Id = Guid.NewGuid();

        public Guid Id { get; set; }

        public string OriginalFileName { get; set; }

        public string OriginalType { get; set; }

        public byte[] OriginalContent { get; set; }

        public byte[] FullscreenContent { get; set; }

        public byte[] ThumbnailContent { get; set; }
    }
}
