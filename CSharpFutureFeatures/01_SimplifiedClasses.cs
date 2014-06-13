using System;
using System.Collections.Generic;
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

    // After

    public class ProductCS6(int id, long downloadSize, string name)  // primary constructor
    {
        public int Id { get; } = id;  // get-only auto property, auto property initialiser
        public long DownloadSize { get; } = downloadSize;
        public string Name { get; } = name;

        // Planned: 'initialisation scope'
        //private long downloadSize = downloadSize;

        //public long GetEstimatedDownloadTime(long transferRate)
        //{
        //    return downloadSize / transferRate;
        //}

        // PLANNED
        //public long GetEstimatedDownloadTime(long transferRate) => downloadSize / transferRate;
    }

    public class FileTransferCS6(long totalBytes)
    {
        // PLANNED
        //[field: NonSerialized]  // refers to backing field
        public long BytesRemaining { get; set; } = totalBytes;
    }

    // Forthcoming: primary constructor body

    public class TextElement(string text)
    {
        // constructor body

        //{
        //    if (text == null)
        //    {
        //        throw new ArgumentNullException("text");
        //    }
        //}
    }


}
