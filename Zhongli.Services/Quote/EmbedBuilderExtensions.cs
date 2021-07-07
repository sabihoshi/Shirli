using System.Linq;
using Discord;
using Humanizer.Bytes;
using Zhongli.Services.Utilities;

namespace Zhongli.Services.Quote
{
    public static class EmbedBuilderExtensions
    {
        public static bool TryAddImageAttachment(this EmbedBuilder embed, IMessage message)
        {
            var firstAttachment = message.Attachments.FirstOrDefault();
            if (firstAttachment?.Height is null)
                return false;

            embed.WithImageUrl(firstAttachment.Url);

            return true;
        }

        public static bool TryAddImageEmbed(this EmbedBuilder embed, IMessage message)
        {
            var imageEmbed = message.Embeds.Select(x => x.Image).FirstOrDefault(x => x is { });
            if (imageEmbed is null)
                return false;

            embed.WithImageUrl(imageEmbed.Value.Url);

            return true;
        }

        public static bool TryAddOtherAttachment(this EmbedBuilder embed, IMessage message)
        {
            var firstAttachment = message.Attachments.FirstOrDefault();
            if (firstAttachment is null) return false;

            embed.AddField($"Attachment (Size: {new ByteSize(firstAttachment.Size)})", firstAttachment.Url);

            return true;
        }

        public static EmbedBuilder? GetRichEmbed(this IMessage message, IMentionable executingUser)
        {
            var firstEmbed = message.Embeds.FirstOrDefault();
            if (firstEmbed?.Type != EmbedType.Rich) return null;

            var embed = message.Embeds
                .First()
                .ToEmbedBuilder()
                .AddField("Quoted by",
                    $"{executingUser.Mention} from {Format.Bold(message.GetJumpUrlForEmbed())}",
                    true);

            if (firstEmbed.Color is null) embed.Color = Color.DarkGrey;

            return embed;
        }

        public static bool TryAddThumbnailEmbed(this EmbedBuilder embed, IMessage message)
        {
            var thumbnailEmbed = message.Embeds.Select(x => x.Thumbnail).FirstOrDefault(x => x is { });
            if (thumbnailEmbed is null)
                return false;

            embed.WithImageUrl(thumbnailEmbed.Value.Url);

            return true;
        }

        public static void AddActivity(this EmbedBuilder embed, IMessage message)
        {
            if (message.Activity is null) return;

            embed
                .AddField("Invite Type", message.Activity.Type)
                .AddField("Party Id", message.Activity.PartyId);
        }

        public static EmbedBuilder AddContent(this EmbedBuilder embed, IMessage message) =>
            string.IsNullOrWhiteSpace(message.Content) ? embed : embed.WithDescription(message.Content);

        public static EmbedBuilder AddMeta(this EmbedBuilder embed, IMessage message, IMentionable executingUser) =>
            embed
                .WithUserAsAuthor(message.Author)
                .WithTimestamp(message.Timestamp)
                .WithColor(new Color(95, 186, 125))
                .AddField("Quoted by", $"{executingUser.Mention} from **{message.GetJumpUrlForEmbed()}**", true);

        public static EmbedBuilder AddOtherEmbed(this EmbedBuilder embed, IMessage message) => message.Embeds.Count == 0
            ? embed
            : embed.AddField("Embed Type", message.Embeds.First().Type);
    }
}