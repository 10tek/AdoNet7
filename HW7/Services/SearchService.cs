using HW7.DataAccess;
using HW7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW7.Services
{
    public class SearchService
    {
        private const int COUNT_IN_PAGE = 3;
        private readonly Context context;

        public SearchService(Context context)
        {
            this.context = context;
        }

        public void ShowGames(int pageNumber = 1)
        {
            UpdateAllGames();
            var games = context.VideoGames.Skip(COUNT_IN_PAGE * --pageNumber).Take(COUNT_IN_PAGE).ToList();
            Console.Clear();
            games.ForEach(x => Console.WriteLine($"Name: {x.Name}\nDescription: {x.Description}\nAvg rating: {x.AvgRating}\n"));
            ShowPages(++pageNumber);
        }

        public void ShowPages(int pageNumber = 1)
        {
            Console.WriteLine($" {pageNumber} | {GetPageCount()}");
        }

        public int GetPageCount()
        {
            var allGames = context.VideoGames.ToList();
            return (int)Math.Ceiling(allGames.Count / (double)COUNT_IN_PAGE);
        }

        private void UpdateAllGames()
        {
            var games = context.VideoGames.ToList();
            games.ForEach(x => UpdateAvgRating(x));
        }

        private void UpdateAvgRating(VideoGame game)
        {
            var ratings = context.Ratings.Where(x=>x.VideoGame==game).ToList();
            var sumRating = 0;
            ratings.ForEach(x => sumRating += x.GameRating);
            game.AvgRating = sumRating / (double)ratings.Count;
            context.VideoGames.Update(game);
        }
    }
}
