﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Makaretu.Nat.Pmp
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void Default()
        {
            var msg = new Message();
            Assert.AreEqual(0, msg.Version);
            Assert.AreEqual(0, (int)msg.Opcode);
            Assert.AreEqual(false, msg.IsResponse);
        }

        [TestMethod]
        public void Length()
        {
            var msg = new Message();
            Assert.AreEqual(2, msg.Length());
        }

    }
}
