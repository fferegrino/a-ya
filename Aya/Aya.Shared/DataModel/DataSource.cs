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

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class DataSource
    {


        private static DataSource _sampleDataSource = new DataSource();
        private static Alphabet _alfabeto;
        private static List<Resource> _resources;
        
        public static async Task<Alphabet> GetAlphabetAsync()
        {
            if (_alfabeto == null)
            {
                await _sampleDataSource.GetDataAsync();
            }
            return _alfabeto;
        }

        public static async Task<List<Resource>> GetResourcesAsync()
        {
            if (_resources == null)
            {
                await _sampleDataSource.GetDataAsync();
            }
            return _resources;
        }

        private async Task GetDataAsync()
        {
            Uri uriAlfabeto = new Uri("ms-appx:///JSONData/idioma.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uriAlfabeto);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jObject = JsonObject.Parse(jsonText);
            #region Alfabeto
            _alfabeto = Alphabet.FromJsonObject(jObject["alphabet"].GetObject());
            #endregion
            #region Recursos
            _resources = new List<Resource>();
            JsonArray resourcesArray = jObject["resources"].GetArray();
            foreach (JsonValue jval in resourcesArray)
            {
                _resources.Add(Resource.FromJsonObject(jval.GetObject()));
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