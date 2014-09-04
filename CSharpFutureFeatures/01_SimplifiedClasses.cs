using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    // Before

    public class ProductCS5
    {
        private readonly int _id;
        private readonly long _downloadSize;
        private readonly string _name;

        public ProductCS5(int id, long downloadSize, string name)
        {
            _id = id;
            _downloadSize = downloadSize;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
        }

        public long DownloadSize
        {
            get { return _downloadSize; }
        }

        public string Name
        {
            get { return _name; }
        }
    }

    public class FileTransferCS5
    {
        public FileTransferCS5(long totalBytes)
        {
            BytesRemaining = totalBytes;
        }

        public long BytesRemaining { get; set; }
    }

    public class RetryHandlerCS5
    {
        public RetryHandlerCS5()
        {
            RetryCount = 3;
        }

        public int RetryCount { get; set; }
    }

    // After

    public class RetryHandlerCS6
    {
        public int RetryCount { get; set; } = 3;
    }

    public class RetryHandlerCS6_ReadOnly
    {
        public int RetryCount { get; } = 3;

        // PLANNED
        //public RetryHandlerCS6_ReadOnly(int retryCount)
        //{
        //    RetryCount = retryCount;  // initialise RO autoproperty's backing field from within ctor
        //}
    }

    public class ProductCS6(int id, long downloadSize, string name)  // primary constructor
    {
        public int Id { get; } = id;  // get-only auto property, auto property initialiser
        public string Name { get; } = name;

        private long downloadSize = downloadSize;  // field initialiser

        // expression-bodied method
        public long GetEstimatedDownloadTime(long transferRate) => downloadSize / transferRate;

        // expression-bodied property
        public string CobolId => Id.ToString("D10", CultureInfo.InvariantCulture);
    }

    public class FileTransferCS6(long totalBytes)
    {
        // PLANNED
        // [field: NonSerialized]  // refers to backing field
        public long BytesRemaining { get; set; } = totalBytes;
    }

    public class TextElement(string text)
    {
        // primary constructor body
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
        }
    }


}
