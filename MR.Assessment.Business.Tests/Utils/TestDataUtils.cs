using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Services.Standard.AdsWcfService;
using Newtonsoft.Json;

namespace MR.Assessment.Business.Tests.Utils
{
    public static class TestDataUtils
    {
        private static readonly string DataFileDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;

        public static class Ads
        {
            private const string DataFilePath = "DataFiles\\ads.json";

            public static Lazy<Task<IQueryable<Ad>>> AdsListValid = new Lazy<Task<IQueryable<Ad>>>(() =>
            {
                try
                {
                    return Task.Run(() =>
                    {
                        var dataFilePath = Path.Combine(DataFileDirectory, DataFilePath);
                        var jsonString = File.ReadAllText(dataFilePath);
                        var data = JsonConvert.DeserializeObject<IEnumerable<Ad>>(jsonString);

                        return data.AsQueryable();
                    });
                }
                catch (Exception exception)
                {
                    throw new Exception($"Unable to load ads from json file: {DataFilePath}", exception);
                }
            });
        }
    }
}
