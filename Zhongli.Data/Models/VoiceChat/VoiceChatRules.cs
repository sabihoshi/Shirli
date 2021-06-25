using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Zhongli.Data.Models.Discord;

namespace Zhongli.Data.Models.VoiceChat
{
    public class VoiceChatRules
    {
        public Guid Id { get; set; }

        public bool PurgeEmpty { get; set; }

        public bool ShowJoinLeave { get; set; }

        [ForeignKey(nameof(GuildId))] public virtual GuildEntity Guild { get; set; }

        public virtual ICollection<VoiceChatLink> VoiceChats { get; set; } = new List<VoiceChatLink>();

        public ulong GuildId { get; set; }

        public ulong HubVoiceChannelId { get; set; }

        public ulong VoiceChannelCategoryId { get; set; }

        public ulong VoiceChatCategoryId { get; set; }
    }
}