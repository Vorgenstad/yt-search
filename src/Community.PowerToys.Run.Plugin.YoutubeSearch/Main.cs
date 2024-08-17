using System;
using System.Collections.Generic;
using Wox.Infrastructure;
using Wox.Plugin;
using Wox.Plugin.Common;
using Wox.Plugin.Logger;

namespace Community.PowerToys.Run.Plugin.YoutubeSearch;

public class Main : IPlugin
{
    public static string PluginID => "af5d01d01290452d9b26e15c2c8a64fe";

    public string Name => "YoutubeSearch";

    public string Description => "Search in Youtube using your default browser";

    private PluginInitContext? Context { get; set; }

    private const string IconPath = "Images/YoutubeSearch.png";

    public void Init(PluginInitContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Result> Query(Query query) =>
    [
        new()
        {
            QueryTextDisplay = query.Search,
            IcoPath = IconPath,
            Title = query.Search,
            SubTitle = "Search on Youtube",
            Action = _ =>
            {
                Log.Info($"Searching for: {query.Search}", GetType());

                var url = $"https://www.youtube.com/results?search_query={query.Search}";

                if (!Helper.OpenCommandInShell(DefaultBrowserInfo.Path, DefaultBrowserInfo.ArgumentsPattern, url))
                {
                    Log.Error("Opening default browser failed", GetType());

                    Context?.API.ShowMsg($"Plugin: {Name}", "Opening default browser failed.");

                    return false;
                }

                return true;
            }
        },
    ];
}