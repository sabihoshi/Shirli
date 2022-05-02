using System.Collections.Generic;
using Discord;
using Discord.Commands;

namespace HuTao.Services.Core.TypeReaders.Commands;

public static class TypeReaderExtensions
{
    public static void AddEnumerableTypeReader<TResult>(
        this CommandService commands, TypeReader typeReader)
    {
        var reader = new EnumerableTypeReader<TResult>(typeReader);

        commands.AddTypeReader<IEnumerable<TResult>>(reader);

        commands.AddTypeReader<List<TResult>>(reader);
        commands.AddTypeReader<IList<TResult>>(reader);
        commands.AddTypeReader<IReadOnlyList<TResult>>(reader);

        commands.AddTypeReader<TResult[]>(reader);
        commands.AddTypeReader<ICollection<TResult>>(reader);
        commands.AddTypeReader<IReadOnlyCollection<TResult>>(reader);
    }

    public static void AddTypeReaders<TResult>(this CommandService commands, params TypeReader[] readers)
        => commands.AddTypeReader<TResult>(new TypeReaderCollection(readers));

    public static void AddTypeReaders<TResult>(this CommandService commands, IEnumerable<TypeReader> readers)
        => commands.AddTypeReader<TResult>(new TypeReaderCollection(readers));

    public static void AddUserTypeReader<TUser>(this CommandService commands,
        CacheMode cacheMode = CacheMode.AllowDownload, bool useRest = true) where TUser : class, IUser
        => commands.AddTypeReader<TUser>(new UserTypeReader<TUser>(cacheMode, useRest));
}