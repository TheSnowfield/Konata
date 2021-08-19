﻿using System.Threading.Tasks;
using System.Collections.Generic;
using Konata.Core.Entity;
using Konata.Core.Message;
using Konata.Core.Attributes;
using Konata.Core.Events.Model;
using Konata.Core.Components.Model;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global

namespace Konata.Core
{
    public partial class Bot : BaseEntity
    {
        /// <summary>
        /// Create a bot
        /// </summary>
        /// <param name="config"><b>[In]</b> Bot configuration</param>
        /// <param name="device"><b>[In]</b> Bot device definition</param>
        /// <param name="keystore"><b>[In]</b> Bot keystore</param>
        public Bot(BotConfig config,
            BotDevice device, BotKeyStore keystore)
        {
            // Load components
            LoadComponents<ComponentAttribute>();

            // Setup configs
            var component = GetComponent<ConfigComponent>();
            {
                component.LoadConfig(config);
                component.LoadDeviceInfo(device);
                component.LoadKeyStore(keystore, device.Model.IMEI);
            }
        }

        #region Bot Information

        public uint Uin
            => KeyStore.Account.Uin;

        public string Name
            => KeyStore.Account.Name;

        internal BusinessComponent BusinessComponent
            => GetComponent<BusinessComponent>();

        internal ConfigComponent ConfigComponent
            => GetComponent<ConfigComponent>();

        internal PacketComponent PacketComponent
            => GetComponent<PacketComponent>();

        internal ScheduleComponent ScheduleComponent
            => GetComponent<ScheduleComponent>();

        internal SocketComponent SocketComponent
            => GetComponent<SocketComponent>();

        internal HighwayComponent HighwayComponent
            => GetComponent<HighwayComponent>();

        public BotKeyStore KeyStore
            => ConfigComponent.KeyStore;

        #endregion

        #region Protocol Methods

        /// <summary>
        /// Bot login
        /// </summary>
        public Task<bool> Login()
            => BusinessComponent.Login();

        /// <summary>
        /// Disconnect the socket and logout
        /// </summary>
        /// <returns></returns>
        public Task<bool> Logout()
            => BusinessComponent.Logout();

        /// <summary>
        /// Submit Slider ticket while login
        /// </summary>
        /// <param name="ticket"><b>[In]</b> Slider ticket</param>
        public void SubmitSliderTicket(string ticket)
            => BusinessComponent.SubmitSliderTicket(ticket);

        /// <summary>
        /// Submit SMS code while login
        /// </summary>
        /// <param name="code"><b>[In]</b> SMS code</param>
        public void SubmitSmsCode(string code)
            => BusinessComponent.SubmitSmsCode(code);

        /// <summary>
        /// Kick the member in a given group
        /// </summary>
        /// <param name="groupUin"><b>[In]</b> Group uin being operated. </param>
        /// <param name="memberUin"><b>[In]</b> Member uin being operated. </param>
        /// <param name="preventRequest"><b>[In]</b> Flag to prevent member request or no. </param>
        public Task<int> GroupKickMember(uint groupUin, uint memberUin, bool preventRequest)
            => BusinessComponent.GroupKickMember(groupUin, memberUin, preventRequest);

        /// <summary>
        /// Mute the member in a given group
        /// </summary>
        /// <param name="groupUin"><b>[In]</b> Group uin being operated. </param>
        /// <param name="memberUin"><b>[In]</b> Member uin being operated. </param>
        /// <param name="timeSeconds"><b>[In]</b> Mute time. </param>
        public Task<int> GroupMuteMember(uint groupUin, uint memberUin, uint timeSeconds)
            => BusinessComponent.GroupMuteMember(groupUin, memberUin, timeSeconds);

        /// <summary>
        /// Promote the member to admin in a given group
        /// </summary>
        /// <param name="groupUin"><b>[In]</b> Group uin being operated. </param>
        /// <param name="memberUin"><b>[In]</b> Member uin being operated. </param>
        /// <param name="toggleAdmin"><b>[In]</b> Flag to toggle set or unset. </param>
        public Task<int> GroupPromoteAdmin(uint groupUin, uint memberUin, bool toggleAdmin)
            => BusinessComponent.GroupPromoteAdmin(groupUin, memberUin, toggleAdmin);

        /// <summary>
        /// Send the message to a given group
        /// </summary>
        /// <param name="groupUin"><b>[In]</b> Group uin.</param>
        /// <param name="message"><b>[In]</b> Message chain to be send.</param>
        /// <returns></returns>
        public Task<int> SendGroupMessage(uint groupUin, MessageChain message)
            => BusinessComponent.SendGroupMessage(groupUin, message);

        /// <summary>
        /// Send the message to a given frinend
        /// </summary>
        /// <param name="friendUin"><b>[In]</b> Friend uin.</param>
        /// <param name="message"><b>[In]</b> Message chain to be send.</param>
        /// <returns></returns>
        public Task<int> SendPrivateMessage(uint friendUin, MessageChain message)
            => BusinessComponent.SendPrivateMessage(friendUin, message);

        /// <summary>
        /// Get group list
        /// </summary>
        /// <returns></returns>
        public ICollection<BotGroup> GetGroupList()
            => ConfigComponent.GetGroupList();

        /// <summary>
        /// Get friend list
        /// </summary>
        /// <returns></returns>
        public ICollection<BotFriend> GetFriendList()
            => ConfigComponent.GetFriendList();

        /// <summary>
        /// Get online status
        /// </summary>
        /// <returns></returns>
        public OnlineStatusEvent.Type GetOnlineStatus()
            => BusinessComponent.GetOnlineStatus();

        /// <summary>
        /// Set online status
        /// </summary>
        /// <param name="status"><b>[In]</b> Online status</param>
        /// <returns></returns>
        public Task<bool> SetOnlineStatus(OnlineStatusEvent.Type status)
            => BusinessComponent.SetOnlineStatus(status);

        /// <summary>
        /// Is Online
        /// </summary>
        /// <returns></returns>
        public bool IsOnline()
            => GetOnlineStatus() != OnlineStatusEvent.Type.Offline;

        #endregion
    }
}
