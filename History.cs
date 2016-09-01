using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizr.API;

namespace Vizr
{
    [Obsolete("History is no longer supported. Use Hitcounts to determine how often item hashes are exectued.")]
    public class History
    {
        private static readonly string _historyFilePath = System.IO.Path.Combine(Workspace.Root.FullName, "history.json");

        [Obsolete("History is no longer supported. Use Hitcounts to determine how often item hashes are exectued.")]
        private List<HistoryItem> _historyItems = new List<HistoryItem>();

        [Obsolete("History is no longer supported. Use Hitcounts to determine how often item hashes are exectued.")]
        public IEnumerable<Hash> Items { get { return _historyItems.Select(x => Hash.Parse(x.ID)); } }

        public History()
        {
            ReadHistoryFile();
        }

        public void Add(IResult result, string query)
        {
            _historyItems.Add(new HistoryItem(result.ID, query));
            SaveHistoryFile();
        }

        [Obsolete("History is no longer supported. Use Hitcounts to determine how often item hashes are exectued.")]
        private void ReadHistoryFile()
        {
            if (!File.Exists(_historyFilePath))
                SaveHistoryFile();

            var historyData = File.ReadAllText(_historyFilePath);
            _historyItems = JsonConvert.DeserializeObject<List<HistoryItem>>(historyData) ?? new List<HistoryItem>();
        }

        [Obsolete("History is no longer supported. Use Hitcounts to determine how often item hashes are exectued.")]
        private void SaveHistoryFile()
        {
            File.WriteAllText(_historyFilePath, JsonConvert.SerializeObject(_historyItems, Formatting.Indented));
        }

        [Obsolete("History is no longer supported. Use Hitcounts to determine how often item hashes are exectued.")]
        private class HistoryItem
        {
            public string ID;
            public string Query;
            public DateTime Date;

            public HistoryItem()
            {
            }

            public HistoryItem(Hash id, string query)
            {
                this.ID = id.ToString();
                this.Query = query;
                this.Date = DateTime.UtcNow;
            }
        }
    }
}
