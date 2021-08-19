﻿using Konata.Core.Attributes;
using Konata.Core.Events;
using Konata.Core.Events.Model;
using Konata.Core.Packets;
using Konata.Core.Packets.SvcRequest;
using Konata.Core.Packets.SvcResponse;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Konata.Core.Services.Friendlist
{
    [EventSubscribe(typeof(PullFriendListEvent))]
    [Service("friendlist.getFriendGroupList", "Pull friend group list")]
    public class GetFriendGroupList : IService
    {
        public bool Parse(SSOFrame input, BotKeyStore signInfo, out ProtocolEvent output)
        {
            var response = new SvcRspGetFriendListResp(input.Payload.GetBytes());

            output = new PullFriendListEvent
            {
                ResultCode = response.Result,
                ErrorCode = response.ErrorCode,
                FriendInfo = response.Friends,
                TotalFriendCount = response.TotalFriendCount
            };

            return true;
        }

        public bool Build(Sequence sequence, PullFriendListEvent input,
            BotKeyStore signInfo, BotDevice device, out int newSequence, out byte[] output)
        {
            output = null;
            newSequence = sequence.NewSequence;

            var svcRequest = new SvcReqGetFriendListReq
                (input.SelfUin, input.StartIndex, input.LimitNum);

            if (SSOFrame.Create("friendlist.getFriendGroupList", PacketType.TypeB,
                newSequence, sequence.Session, svcRequest, out var ssoFrame))
            {
                if (ServiceMessage.Create(ssoFrame, AuthFlag.D2Authentication,
                    signInfo.Account.Uin, signInfo.Session.D2Token, signInfo.Session.D2Key, out var toService))
                {
                    return ServiceMessage.Build(toService, device, out output);
                }
            }

            return false;
        }

        public bool Build(Sequence sequence, ProtocolEvent input,
            BotKeyStore signInfo, BotDevice device, out int newSequence, out byte[] output)
            => Build(sequence, (PullFriendListEvent) input, signInfo, device, out newSequence, out output);
    }
}
