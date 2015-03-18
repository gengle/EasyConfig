using System;
using EasyConfig.RaptorDbStorage.Infrastructure;

namespace EasyConfig.RaptorDbStorage
{
    public class RaptorDbConfigRepository
        :IConfigRepository
    {
        private readonly string _databasePath;

        public RaptorDbConfigRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        public RaptorDbConfigRepository()
            :this("data")
        {
            
        }

        public string GetOrCreateKey(ConfigKey key)
        {
            var db = RaptorDB.RaptorDB.Open(_databasePath);
            RaptorDB.Global.RequirePrimaryView = false;
            try
            {
                var id = GuidUtility.Create(GuidUtility.UrlNamespace, key.KeyName);
                var result = (KeyValueDoc)db.Fetch(id);
                if (result == null)
                    return key.DefaultValue;
                return result.KeyValue;
            }
            finally
            {
                db.Shutdown();
            }
            
        }

        public void SaveChanges(ConfigKey key, string value)
        {
            var db = RaptorDB.RaptorDB.Open(_databasePath);
            RaptorDB.Global.RequirePrimaryView = false;
            try
            {
                var document = new KeyValueDoc(key, value);
                var result = db.Save(document.Id, document);
                if (result == false)
                {
                    throw new InvalidOperationException("Unable to save");
                }
            }
            finally
            {
                db.Shutdown();
            }
        }
    }
}
