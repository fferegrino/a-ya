using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace Aya.DataModel
{
    /*
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class DataSource
    {
        public DataSource(String uniqueId, String title, String subtitle, String imagePath, String description, String content)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Content = content;
        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Content { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup
    {
        public SampleDataGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Items = new ObservableCollection<DataSource>();
        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public ObservableCollection<DataSource> Items { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
    */

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class DataSource
    {


        private static DataSource _sampleDataSource = new DataSource();
        public static Alphabet _alfabeto;
        public static async Task<Alphabet> GetAlphabetAsnc()
        {
            if (_alfabeto == null)
            {
                await _sampleDataSource.GetDataAsync();
            }
            return _alfabeto;
        }

        private async Task GetDataAsync()
        {
            #region Alfabeto
            Uri uriAlfabeto = new Uri("ms-appx:///JSONData/alfabeto.json");

            StorageFile fileA = await StorageFile.GetFileFromApplicationUriAsync(uriAlfabeto);
            string jsonTextA = await FileIO.ReadTextAsync(fileA);
            JsonObject jsonObjectA = JsonObject.Parse(jsonTextA);
            _alfabeto = new Alphabet(jsonObjectA["title"].GetString()
                , jsonObjectA["subtitle"].GetString()
                , jsonObjectA["description"].GetString());

            JsonArray simbolos = jsonObjectA["symbols"].GetArray();
            foreach (JsonValue simbolo in simbolos)
            {
                JsonObject simb = simbolo.GetObject();
                _alfabeto.AddSymbol(new Symbol()
                {
                    Lowercase = simb["lowercase"].GetString(),
                    Uppercase = simb["uppercase"].GetString() //,
                    //UniqueID = simb["uid"].GetString()
                });
            }
            #endregion
        }

        /*

        private ObservableCollection<SampleDataGroup> _groups = new ObservableCollection<SampleDataGroup>();
        public ObservableCollection<SampleDataGroup> Groups
        {
            get { return this._groups; }
        }
        public static async Task<IEnumerable<SampleDataGroup>> GetGroupsAsync()
        {
            await _sampleDataSource.GetSampleDataAsync();

            return _sampleDataSource.Groups;
        }
        */
        /*
        public static async Task<SampleDataGroup> GetGroupAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<DataSource> GetItemAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }
        */
    }
}