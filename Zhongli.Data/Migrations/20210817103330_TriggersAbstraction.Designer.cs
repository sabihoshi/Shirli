﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Zhongli.Data;

namespace Zhongli.Data.Migrations
{
    [DbContext(typeof(ZhongliContext))]
    [Migration("20210817103330_TriggersAbstraction")]
    partial class TriggersAbstraction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Zhongli.Data.Models.Authorization.AuthorizationGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Access")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ActionId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("GuildEntityId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Scope")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("GuildEntityId");

                    b.ToTable("AuthorizationGroup");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Criteria.Criterion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorizationGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CensorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizationGroupId");

                    b.HasIndex("CensorId");

                    b.ToTable("Criterion");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Criterion");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.GuildEntity", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid?>("GenshinRulesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GenshinRulesId");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.GuildUserEntity", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DiscriminatorValue")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id", "GuildId");

                    b.HasIndex("GuildId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.TemporaryRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActionId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("EndedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("ExpireAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("GuildEntityId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<TimeSpan?>("Length")
                        .HasColumnType("interval");

                    b.Property<decimal>("RoleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTimeOffset>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("GuildEntityId");

                    b.ToTable("TemporaryRole");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Logging.LoggingRules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("ModerationChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("NotifyReprimands")
                        .HasColumnType("integer");

                    b.Property<int>("Options")
                        .HasColumnType("integer");

                    b.Property<string>("ReprimandAppealMessage")
                        .HasColumnType("text");

                    b.Property<int>("ShowAppealOnReprimands")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("LoggingRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.AntiSpamRules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan?>("DuplicateMessageTime")
                        .HasColumnType("interval");

                    b.Property<int?>("DuplicateTolerance")
                        .HasColumnType("integer");

                    b.Property<long?>("EmojiLimit")
                        .HasColumnType("bigint");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<long?>("MessageLimit")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan?>("MessageSpamTime")
                        .HasColumnType("interval");

                    b.Property<long?>("NewlineLimit")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("AntiSpamRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ReprimandAction");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ReprimandAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("ModeratorId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("ModeratorId", "GuildId");

                    b.ToTable("ModerationAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Reprimand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid?>("ModifiedActionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid?>("TriggerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("GuildId");

                    b.HasIndex("ModifiedActionId");

                    b.HasIndex("TriggerId");

                    b.HasIndex("UserId", "GuildId");

                    b.ToTable("Reprimand");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Reprimand");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Triggers.Trigger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActionId")
                        .HasColumnType("uuid");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Mode")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ModerationRulesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ModerationRulesId");

                    b.ToTable("Trigger");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Trigger");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.ModerationRules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AntiSpamRulesId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan?>("CensorTimeRange")
                        .HasColumnType("interval");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("MuteRoleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<TimeSpan?>("NoticeAutoPardonLength")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("WarningAutoPardonLength")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("AntiSpamRulesId");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("ModerationRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.TimeTracking.GenshinTimeTrackingRules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AmericaChannelId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AsiaChannelId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("EuropeChannelId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SARChannelId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ServerStatusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AmericaChannelId");

                    b.HasIndex("AsiaChannelId");

                    b.HasIndex("EuropeChannelId");

                    b.HasIndex("SARChannelId");

                    b.HasIndex("ServerStatusId");

                    b.ToTable("GenshinTimeTrackingRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.TimeTracking.TimeTracking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("TimeTrackingRules");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TimeTracking");
                });

            modelBuilder.Entity("Zhongli.Data.Models.VoiceChat.VoiceChatLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("OwnerId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("TextChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("VoiceChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid?>("VoiceChatRulesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("VoiceChatRulesId");

                    b.HasIndex("OwnerId", "GuildId");

                    b.ToTable("VoiceChatLink");
                });

            modelBuilder.Entity("Zhongli.Data.Models.VoiceChat.VoiceChatRules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("HubVoiceChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("PurgeEmpty")
                        .HasColumnType("boolean");

                    b.Property<bool>("ShowJoinLeave")
                        .HasColumnType("boolean");

                    b.Property<decimal>("VoiceChannelCategoryId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("VoiceChatCategoryId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("VoiceChatRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Criteria.ChannelCriterion", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Criteria.Criterion");

                    b.Property<decimal>("ChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("IsCategory")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("ChannelCriterion");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Criteria.PermissionCriterion", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Criteria.Criterion");

                    b.Property<int>("Permission")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("PermissionCriterion");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Criteria.RoleCriterion", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Criteria.Criterion");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("RoleId")
                        .HasColumnType("numeric(20,0)");

                    b.HasDiscriminator().HasValue("RoleCriterion");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Criteria.UserCriterion", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Criteria.Criterion");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasDiscriminator().HasValue("UserCriterion");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.BanAction", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction");

                    b.Property<long>("DeleteDays")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan?>("Length")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("interval")
                        .HasColumnName("Length");

                    b.HasDiscriminator().HasValue("BanAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.KickAction", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction");

                    b.HasDiscriminator().HasValue("KickAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.MuteAction", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction");

                    b.Property<TimeSpan?>("Length")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("interval")
                        .HasColumnName("Length");

                    b.HasDiscriminator().HasValue("MuteAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.NoteAction", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction");

                    b.HasDiscriminator().HasValue("NoteAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.NoticeAction", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction");

                    b.HasDiscriminator().HasValue("NoticeAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Actions.WarningAction", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction");

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("WarningAction");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.ExpirableReprimand", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Reprimand");

                    b.Property<DateTimeOffset?>("EndedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndedAt");

                    b.Property<DateTimeOffset?>("ExpireAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("Length")
                        .HasColumnType("interval")
                        .HasColumnName("Length");

                    b.Property<DateTimeOffset>("StartedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("StartedAt");

                    b.HasDiscriminator().HasValue("ExpirableReprimand");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Kick", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Reprimand");

                    b.HasDiscriminator().HasValue("Kick");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Note", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Reprimand");

                    b.HasDiscriminator().HasValue("Note");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Censors.Censor", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Triggers.Trigger");

                    b.Property<int>("Options")
                        .HasColumnType("integer");

                    b.Property<string>("Pattern")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ReprimandId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("uuid")
                        .HasColumnName("ReprimandId");

                    b.HasIndex("ReprimandId");

                    b.HasDiscriminator().HasValue("Censor");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Triggers.ReprimandTrigger", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Triggers.Trigger");

                    b.Property<Guid?>("ReprimandId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("uuid")
                        .HasColumnName("ReprimandId");

                    b.Property<int>("Source")
                        .HasColumnType("integer");

                    b.HasIndex("ReprimandId");

                    b.HasDiscriminator().HasValue("ReprimandTrigger");
                });

            modelBuilder.Entity("Zhongli.Data.Models.TimeTracking.ChannelTimeTracking", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.TimeTracking.TimeTracking");

                    b.Property<decimal>("ChannelId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("ChannelTimeTracking_ChannelId");

                    b.HasDiscriminator().HasValue("ChannelTimeTracking");
                });

            modelBuilder.Entity("Zhongli.Data.Models.TimeTracking.MessageTimeTracking", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.TimeTracking.TimeTracking");

                    b.Property<decimal>("ChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("MessageId")
                        .HasColumnType("numeric(20,0)");

                    b.HasDiscriminator().HasValue("MessageTimeTracking");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Ban", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.ExpirableReprimand");

                    b.Property<long>("DeleteDays")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("Ban");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Censored", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.ExpirableReprimand");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Censored");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Mute", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.ExpirableReprimand");

                    b.HasDiscriminator().HasValue("Mute");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Notice", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.ExpirableReprimand");

                    b.HasDiscriminator().HasValue("Notice");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Warning", b =>
                {
                    b.HasBaseType("Zhongli.Data.Models.Moderation.Infractions.Reprimands.ExpirableReprimand");

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("Warning");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Authorization.AuthorizationGroup", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", null)
                        .WithMany("AuthorizationGroups")
                        .HasForeignKey("GuildEntityId");

                    b.Navigation("Action");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Criteria.Criterion", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Authorization.AuthorizationGroup", null)
                        .WithMany("Collection")
                        .HasForeignKey("AuthorizationGroupId");

                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.Censors.Censor", null)
                        .WithMany("Exclusions")
                        .HasForeignKey("CensorId");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.GuildEntity", b =>
                {
                    b.HasOne("Zhongli.Data.Models.TimeTracking.GenshinTimeTrackingRules", "GenshinRules")
                        .WithMany()
                        .HasForeignKey("GenshinRulesId");

                    b.Navigation("GenshinRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.GuildUserEntity", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.TemporaryRole", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", null)
                        .WithMany("TemporaryRoles")
                        .HasForeignKey("GuildEntityId");

                    b.Navigation("Action");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Logging.LoggingRules", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithOne("LoggingRules")
                        .HasForeignKey("Zhongli.Data.Models.Logging.LoggingRules", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.AntiSpamRules", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zhongli.Data.Models.Discord.GuildUserEntity", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");

                    b.Navigation("Moderator");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Reprimands.Reprimand", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithMany("ReprimandHistory")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", "ModifiedAction")
                        .WithMany()
                        .HasForeignKey("ModifiedActionId");

                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.Triggers.Trigger", "Trigger")
                        .WithMany()
                        .HasForeignKey("TriggerId");

                    b.HasOne("Zhongli.Data.Models.Discord.GuildUserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Guild");

                    b.Navigation("ModifiedAction");

                    b.Navigation("Trigger");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Triggers.Trigger", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.ModerationAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("Zhongli.Data.Models.Moderation.ModerationRules", null)
                        .WithMany("Triggers")
                        .HasForeignKey("ModerationRulesId");

                    b.Navigation("Action");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.ModerationRules", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.AntiSpamRules", "AntiSpamRules")
                        .WithMany()
                        .HasForeignKey("AntiSpamRulesId");

                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithOne("ModerationRules")
                        .HasForeignKey("Zhongli.Data.Models.Moderation.ModerationRules", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AntiSpamRules");

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Zhongli.Data.Models.TimeTracking.GenshinTimeTrackingRules", b =>
                {
                    b.HasOne("Zhongli.Data.Models.TimeTracking.ChannelTimeTracking", "AmericaChannel")
                        .WithMany()
                        .HasForeignKey("AmericaChannelId");

                    b.HasOne("Zhongli.Data.Models.TimeTracking.ChannelTimeTracking", "AsiaChannel")
                        .WithMany()
                        .HasForeignKey("AsiaChannelId");

                    b.HasOne("Zhongli.Data.Models.TimeTracking.ChannelTimeTracking", "EuropeChannel")
                        .WithMany()
                        .HasForeignKey("EuropeChannelId");

                    b.HasOne("Zhongli.Data.Models.TimeTracking.ChannelTimeTracking", "SARChannel")
                        .WithMany()
                        .HasForeignKey("SARChannelId");

                    b.HasOne("Zhongli.Data.Models.TimeTracking.MessageTimeTracking", "ServerStatus")
                        .WithMany()
                        .HasForeignKey("ServerStatusId");

                    b.Navigation("AmericaChannel");

                    b.Navigation("AsiaChannel");

                    b.Navigation("EuropeChannel");

                    b.Navigation("SARChannel");

                    b.Navigation("ServerStatus");
                });

            modelBuilder.Entity("Zhongli.Data.Models.VoiceChat.VoiceChatLink", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zhongli.Data.Models.VoiceChat.VoiceChatRules", null)
                        .WithMany("VoiceChats")
                        .HasForeignKey("VoiceChatRulesId");

                    b.HasOne("Zhongli.Data.Models.Discord.GuildUserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Zhongli.Data.Models.VoiceChat.VoiceChatRules", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Discord.GuildEntity", "Guild")
                        .WithOne("VoiceChatRules")
                        .HasForeignKey("Zhongli.Data.Models.VoiceChat.VoiceChatRules", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Censors.Censor", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction", "Reprimand")
                        .WithMany()
                        .HasForeignKey("ReprimandId");

                    b.Navigation("Reprimand");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Triggers.ReprimandTrigger", b =>
                {
                    b.HasOne("Zhongli.Data.Models.Moderation.Infractions.Actions.ReprimandAction", "Reprimand")
                        .WithMany()
                        .HasForeignKey("ReprimandId");

                    b.Navigation("Reprimand");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Authorization.AuthorizationGroup", b =>
                {
                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Discord.GuildEntity", b =>
                {
                    b.Navigation("AuthorizationGroups");

                    b.Navigation("LoggingRules")
                        .IsRequired();

                    b.Navigation("ModerationRules")
                        .IsRequired();

                    b.Navigation("ReprimandHistory");

                    b.Navigation("TemporaryRoles");

                    b.Navigation("VoiceChatRules");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.ModerationRules", b =>
                {
                    b.Navigation("Triggers");
                });

            modelBuilder.Entity("Zhongli.Data.Models.VoiceChat.VoiceChatRules", b =>
                {
                    b.Navigation("VoiceChats");
                });

            modelBuilder.Entity("Zhongli.Data.Models.Moderation.Infractions.Censors.Censor", b =>
                {
                    b.Navigation("Exclusions");
                });
#pragma warning restore 612, 618
        }
    }
}
