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

namespace Aya.Models
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
        private static ObservableCollection<Resource> _resources;
        
        public static async Task<Alphabet> GetAlphabetAsync()
        {
            if (_alfabeto == null)
            {
                await _sampleDataSource.GetDataAsync();
            }
            return _alfabeto;
        }

        public static async Task<ObservableCollection<Resource>> GetResourcesAsync()
        {
            if (_resources == null)
            {
                await _sampleDataSource.GetDataAsync();
            }
            return _resources;
        }

        private async Task GetDataAsync()
        {
            Uri uriAlfabeto = new Uri("ms-appx:///Data/idioma.json");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uriAlfabeto);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jObject = JsonObject.Parse(jsonText);
            #region Alfabeto
            _alfabeto = Alphabet.FromJsonObject(jObject["alphabet"].GetObject());
            #endregion
            #region Recursos
            _resources = new ObservableCollection<Resource>();
            JsonArray resourcesArray = jObject["resources"].GetArray();
            foreach (JsonValue jval in resourcesArray)
            {
                _resources.Add(Resource.FromJsonObject(jval.GetObject()));
            }

            #endregion
        }

    }
}