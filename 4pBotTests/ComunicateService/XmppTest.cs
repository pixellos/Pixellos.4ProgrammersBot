﻿using NSubstitute;
using NUnit.Framework;
using pBot.Model.Commands.HighLevel;
using pBot.Model.ComunicateService;
using pBot.Model.Core.Abstract;
using pBot.Model.Core.Cache;
using pBot.Model.Core.Data;
using pBot.Model.Functions.HighLevel;

namespace pBotTests.ComunicateService
{
    [TestFixture]
    public class XmppTest
    {
        [SetUp]
        public void SetUp()
        {
            xmpp = Substitute.For<IXmpp>();
            Invoker = Substitute.For<ICommandInvoker>();
            _commandRepeater = new Repeater
            {
                Xmpp = xmpp,
                CommandInvoker = Invoker,
                CachedResponse = new CachedResponse<Command, string>()
            };

            //AutofacSetup.GetContainer().Resolve<Xmpp>();
        }

        private IXmpp xmpp;
        private Repeater _commandRepeater = new Repeater();
        private ICommandInvoker Invoker;

        [Test]
        public void Test()
        {
            _commandRepeater.DealWithRepeating(new Command("test", "Auto", Command.CommandType.Any, "10", "Check", "SO", "C#"));
            _commandRepeater.DealWithRepeating(new Command("test", "Auto", Command.CommandType.Negation, "10", "Check", "SO",
                "C#"));
        }
    }
}