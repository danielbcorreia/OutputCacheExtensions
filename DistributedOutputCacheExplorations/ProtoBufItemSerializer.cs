using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DistributedOutputCacheExplorations
{
    public class ProtoBufItemSerializer : IItemSerializer
    {
        public byte[] Serialize(object entry)
        {
            var item = new CacheItem { Value = entry };

            byte[] itemBytes;

            using (var ms = new MemoryStream())
            {
                Serializer.Serialize<CacheItem>(ms, item);
                itemBytes = ms.ToArray();
            }

            return itemBytes;
        }

        public object Deserialize(byte[] bytes)
        {
            CacheItem item;
            using (var ms = new MemoryStream(bytes))
            {
                item = Serializer.Deserialize<CacheItem>(ms);
            }

            return item.Value;
        }

        [ProtoContract]
        public class CacheItem
        {
            [ProtoMember(1, DynamicType = true)]
            public object Value { get; set; }
        }
    }
}
