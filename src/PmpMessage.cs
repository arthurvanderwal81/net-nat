﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makaretu.Nat
{
    /// <summary>
    ///   A Port Mapping Protocol message.
    /// </summary>
    public class PmpMessage : NatMessage
    {
        /// <summary>
        ///   The protocol version.
        /// </summary>
        /// <value>
        ///   Defaults to zero, <see cref="NatPmp.ProtocolVersion"/>.
        /// </value>
        public byte Version { get; set; } = NatPmp.ProtocolVersion;

        /// <summary>
        ///   The operatation.
        /// </summary>
        /// <value>
        ///   One of the <see cref="PmpOpcode"/> or <see cref="PcpOpcode"/> values.
        /// </value>
        public byte Opcode { get; set; }

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
            var opcode = Opcode;
            if (IsResponse)
            {
                opcode |= 80;
            }
            writer.WriteByte(opcode);
        }
    }
}
