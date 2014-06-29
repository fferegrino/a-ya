using Aya.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.ViewModel
{
    public class HubViewModel
    {
        public HubViewModel()
        {

        }

        public async void GetData()
        {
            
            _alphabet = await DataSource.GetAlphabetAsnc();
        }

        private Alphabet _alphabet;

        public Alphabet Alphabet
        {
            get {
                return _alphabet; }
        }

    }
}
