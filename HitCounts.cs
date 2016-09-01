using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizr.API;
using Vizr.API.Extensions;

namespace Vizr
{
    public class HitCounts
    {
        private static readonly string _hitCountFilePath = System.IO.Path.Combine(Workspace.Root.FullName, "hits.json");
        private static readonly Dictionary<string, int> EmptyHitCounts = new Dictionary<string, int>();

        public Dictionary<string, int> Hits { get; private set; }

        public HitCounts()
        {
            ReadHitCountFile();
        }

        public void Add(IResult result, string query)
        {
            var key = result.ID.ToString();

            if (!Hits.ContainsKey(key))
                Hits.Add(key, 0);

            ++Hits[key];

            SaveHitCountFile();
        }

        public int GetHits(IResult result)
        {
            if (result == null)
                return 0;

            var key = result.ID.ToString();

            if (!Hits.ContainsKey(key))
                return 0;

            return Hits[key];
        }

        private void ReadHitCountFile()
        {
            if (!File.Exists(_hitCountFilePath))
                SaveHitCountFile();

            var historyData = File.ReadAllText(_hitCountFilePath);
            Hits = JsonConvert.DeserializeObject<Dictionary<string, int>>(historyData) ?? EmptyHitCounts;
        }

        private void SaveHitCountFile()
        {
            File.WriteAllText(_hitCountFilePath, JsonConvert.SerializeObject(Hits, Formatting.Indented));
        }
    }
}
