﻿using NUnit.Framework;
using pBot.Model.Core;
using Autofac;
using pBotTests.Model.Commands.Marshaller;

namespace pBotTests.Model.Commands.CommandEquality
{
    [TestFixture]
    public class CacheTest
    {
        CachedResponse cachedResponse;

        [SetUp]
        public void SetUp()
        {
            cachedResponse = new CachedResponse();
        }


        [Test]
        public void CheckResponseUniquenes()
        {
            cachedResponse.SetLastResponse(CommandMarshallerConst.Show_Author_Command,"");
            cachedResponse.SetLastResponse(CommandMarshallerConst.Show_Author_Command, "4334331433");

            Assert.True(cachedResponse.IsResponseUnique(CommandMarshallerConst.Show_Author_Command,"jreoiueoiujfsdoiue09"));
        }

        [Test]
        public void RemoveFromCache()
        {
            cachedResponse.SetLastResponse(CommandMarshallerConst.Show_Author_Command,"");
            cachedResponse.Remove(CommandMarshallerConst.Show_Author_Command);
            Assert.False(cachedResponse.ContainsCommand(CommandMarshallerConst.Show_Author_Command));
        }

        [Test]
        public void IsExistAtCache()
        {
            cachedResponse.SetLastResponse(CommandMarshallerConst.Show_Author_Command,"");
            cachedResponse.SetLastResponse(CommandMarshallerConst.Show_Author_Command, "Test");

            string expectedNull = "";
            cachedResponse.DoWhenResponseIsNotLikeLastResponse(CommandMarshallerConst.Show_Author_Command, null , x =>
            {
                expectedNull = x;
                Assert.Pass();
            });

            Assert.IsNull(expectedNull);
        }
    }
}