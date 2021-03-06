﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makaretu.Nat.Pmp
{
    /// <summary>
    ///   A Port Mapping Protocol message.
    /// </summary>
    public class Message : NatMessage
    {
        /// <summary>
        ///   The protocol version.
        /// </summary>
        /// <value>
        ///   Defaults to zero, <see cref="Client.ProtocolVersion"/>.
        /// </value>
        public byte Version { get; set; } = Client.ProtocolVersion;

        /// <summary>
        ///   The operatation.
        /// </summary>
        /// <value>
        ///   One of the <see cref="Opcode"/> values.
        /// </value>
        public Opcode Opcode { get; set; }

        /// <summary>
        ///   Indicates that the message is a response.
        /// </summary>
        /// <value>
        ///   Defaults to <b>false</b>, e.g. its a request.
        /// </value>
        public bool IsResponse { get; set; }

        /// <inheritdoc />
        public override void Write(NatWriter writer)
        {
            writer.WriteByte(Version);
            byte opcode = (byte)Opcode;
            if (IsResponse)
            {
                opcode |= 0x80;
            }
            writer.WriteByte(opcode);
        }

        /// <inheritdoc />
        public override void Read(NatReader reader)
        {

        }
    }
}
