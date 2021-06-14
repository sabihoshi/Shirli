﻿using Discord;

namespace Zhongli.Services.Utilities
{
    public static class MessageExtensions
    {
        public static string GetJumpUrlForEmbed(this IMessage message)
            => Format.Url($"#{message.Channel.Name} (click here)", message.GetJumpUrl());
    }
}