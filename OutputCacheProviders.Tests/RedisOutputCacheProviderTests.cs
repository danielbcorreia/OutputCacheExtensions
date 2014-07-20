using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistributedOutputCacheExplorations;
using System.Threading.Tasks;

namespace OutputCacheProviders.Tests
{
    [TestClass]
    public class RedisOutputCacheProviderTests
    {
        [TestMethod]
        public void CanAddAndGetAndSetAndRemoveItem()
        {
            var key = "mykey" + Guid.NewGuid();
            var provider = new RedisOutputCacheProvider();

            // test add and get

            provider.Add(key, "myvalue", DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)));

            var value = (string)provider.Get(key);

            Assert.AreEqual("myvalue", value);

            // test set and get

            provider.Set(key, "anothervalue", DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)));

            var valueAfterSet = (string)provider.Get(key);

            Assert.AreEqual("anothervalue", valueAfterSet);

            // test remove and get

            provider.Remove(key);

            var valueAfterRemove = (string)provider.Get(key);

            Assert.IsNull(valueAfterRemove);
        }

        [TestMethod]
        public async Task EntryExpiresAfterAbsoluteTime()
        {
            var key = "mykey" + Guid.NewGuid();
            var provider = new RedisOutputCacheProvider();

            // add the value and check that it is in cache

            provider.Add(key, "myvalue", DateTime.UtcNow.Add(TimeSpan.FromSeconds(3)));
            var value = (string)provider.Get(key);
            Assert.AreEqual("myvalue", value);

            await Task.Delay(3000);

            var valueAfterExpiration = (string)provider.Get(key);
            Assert.IsNull(valueAfterExpiration);
        }
    }
}
