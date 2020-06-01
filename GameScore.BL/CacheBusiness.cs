using GameScore.BL.Interfaces;
using GameScore.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameScore.BL
{
    public class CacheBusiness : ICacheBusiness
    {
        private readonly IMemoryCache _cache;

        public CacheBusiness(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Dictionary<int, Game> GetGamesByIndex(string entry)
        {
            return _cache.Get(entry) as Dictionary<int, Game>;
        }

        public void SetSearchedGames(string keyword)
        {
            var gamesByIndex = GetGamesByIndex("_GamesEntry").Values.ToList();
            var listOfSearchedGames = gamesByIndex
                .Where(x => x.Name
                    .ToLower()
                    .Contains(keyword
                        .ToLower()))
                .ToList();

            var gameIndex = 1;
            var searchedGamestByIndex = listOfSearchedGames.ToDictionary(x => gameIndex++, x => x);

            _cache.Set("_SearchListEntry", searchedGamestByIndex, new MemoryCacheEntryOptions());
        }

        public void SetListOfGames(IEnumerable<Game> listOfGames)
        {
            var index = 1;
            var gamesByIndex = listOfGames
                .ToDictionary(g => index++, g => g);

            _cache.Set("_GamesEntry", gamesByIndex, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(60)));
        }
    }
}
