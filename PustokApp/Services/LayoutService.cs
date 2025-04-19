using PustokApp.Data;
using PustokApp.Models;
using System.Linq;

namespace PustokApp.Services
{
    public class LayoutService(PustokDbContext pustokDbContext)
    {
        public Dictionary<string, string> GetSettings()
        {
            return pustokDbContext.Settings
                .ToDictionary(x => x.Key, x => x.Value);
        }
        public List<Genre> GetGenres()
        {
            return pustokDbContext.Genres.ToList();
        }
    }
}
