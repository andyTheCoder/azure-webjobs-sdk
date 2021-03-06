﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    internal static class StoragePageBlobExtensions
    {
        public static void UploadEmptyPage(this IStoragePageBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            using (CloudBlobStream stream = blob.OpenWriteAsync(512, CancellationToken.None).GetAwaiter().GetResult())
            {
                stream.CommitAsync().Wait();
            }
        }
    }
}
