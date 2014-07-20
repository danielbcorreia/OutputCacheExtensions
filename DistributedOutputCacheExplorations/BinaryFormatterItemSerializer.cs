using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DistributedOutputCacheExplorations
{
    public class BinaryFormatterItemSerializer : IItemSerializer
    {
        public byte[] Serialize(object item)
        {
            var formatter = new BinaryFormatter();

            byte[] itemBytes;

            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                itemBytes = ms.ToArray();
            }

            return itemBytes;
        }

        public object Deserialize(byte[] bytes)
        {
            var formatter = new BinaryFormatter();

            object item;
            using (var ms = new MemoryStream(bytes))
            {
                item = formatter.Deserialize(ms);
            }

            return item;
        }
    }
}
