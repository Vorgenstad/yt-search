using System;
using System.Collections.Generic;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.YoutubeSearch;

public class Main : IPlugin
{
    public static string PluginID => "af5d01d01290452d9b26e15c2c8a64fe";

    public string Name => "YoutubeSearch";

    public string Description => "Search in Youtube using your default browser";

    private PluginInitContext? Context { get; set; }

    public void Init(PluginInitContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Result> Query(Query query)
    {
        throw new NotImplementedException();
    }
}