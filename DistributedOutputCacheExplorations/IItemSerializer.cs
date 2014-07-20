using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedOutputCacheExplorations
{
    public interface IItemSerializer
    {
        byte[] Serialize(object item);
        object Deserialize(byte[] itemBytes);
    }
}
