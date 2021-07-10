using System;
using Discord;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zhongli.Data.Models.Discord;
using Zhongli.Data.Models.Moderation.Infractions.Reprimands;

namespace Zhongli.Data.Models.Moderation.Infractions
{
    public interface IModerationAction
    {
        public ModerationAction Action { get; set; }
    }

    public class ModerationAction
    {
        protected ModerationAction() { }

        public ModerationAction(ReprimandDetails details) : this(details.Moderator) { }

        public ModerationAction(IGuildUser moderator)
        {
            Date = DateTimeOffset.UtcNow;

            GuildId     = moderator.Guild.Id;
            ModeratorId = moderator.Id;
        }

        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public virtual GuildEntity Guild { get; set; }

        public virtual GuildUserEntity Moderator { get; set; }

        public ulong GuildId { get; set; }

        public ulong ModeratorId { get; set; }
    }

    public class ModerationActionConfiguration : IEntityTypeConfiguration<ModerationAction>
    {
        public void Configure(EntityTypeBuilder<ModerationAction> builder)
        {
            builder.HasOne(r => r.Moderator)
                .WithMany().HasForeignKey(r => new { r.ModeratorId, r.GuildId });
        }
    }
}