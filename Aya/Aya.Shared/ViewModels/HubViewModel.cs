using Aya.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aya.ViewModels
{
    public class HubViewModel : ViewModelBase
    {
        public HubViewModel()
        {
            if (IsInDesignMode)
            {
                #region Design mode alphabet
                _alphabet = new Alphabet("Alfabeto crílico", "Se usa el alfabeto crílico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum ante vel suscipit elementum. Donec lobortis felis ut erat rhoncus euismod. Curabitur commodo diam quis massa rutrum rhoncus. Nullam elementum.");
                for (int i = 0; i < 20; i++)
                {
                    _alphabet.AddSymbol(new Symbol()
                    {
                        Uppercase = "A",
                        Lowercase = "a",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum ante vel suscipit elementum.",
                        Origin = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum ante vel suscipit elementum.",
                        SAMPA = "/íj/"
                    });
                    _alphabet.AddNumber(new Number()
                    {
                        Name = "uno",
                        SAMPA = "/íjaasf/",
                        NumberString = "10",
                        NumberInteger = 10
                    }, i < 10);
                }
                for (int i = 0; i < 6; i++)
                {
                    PhraseGroup p = new PhraseGroup("Phrase group " + i);
                    p.FullPhrases = new ObservableCollection<Phrase>();
                    p.DisplayPhrases = new ObservableCollection<Phrase>();
                    for (int jj = 0; jj < 30; jj++)
                    {
                        p.FullPhrases.Add(new Phrase { Original = "Frase original asdopaksd", SAMPA = "[kahsdjhajkshd poaksdñlask apsd]" });
                        if (jj < 3)
                            p.DisplayPhrases.Add(p.FullPhrases[jj]);
                    }

                    _alphabet.AddPhraseGroup(p);
                }
                #endregion
                #region Designer mode resource list
                _resources = new ObservableCollection<Resource>();
                for (int i = 0; i < 20; i++)
                {
                    _resources.Add(new Resource()
                    {
                        Url = "http://google.com",
                        Name = "Recurso " + i
                    });
                }
                #endregion
            }
            else
            {

            }
            _clearSelectionsCommand = new RelayCommand(() => { SelectedPhraseGroup = null; });
            _loadDataCommand = new RelayCommand(() => { GetData(); });
        }

        #region Exposed properties
        private PhraseGroup _selectedPhraseGroup;

        public PhraseGroup SelectedPhraseGroup
        {
            get { return _selectedPhraseGroup; }
            set { _selectedPhraseGroup = value; RaisePropertyChanged(); }
        }

        private Alphabet _alphabet;
        public Alphabet Language
        {
            get { return _alphabet; }
            set { _alphabet = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Resource> _resources;

        public ObservableCollection<Resource> Resources
        {
            get { return _resources; }
            set { _resources = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Commands
        private RelayCommand _clearSelectionsCommand;

        public RelayCommand ClearSelectionsCommand
        {
            get { return _clearSelectionsCommand; }
        }

        private RelayCommand _loadDataCommand;

        public RelayCommand LoadDataCommand
        {
            get { return _loadDataCommand; }
        }
        #endregion

        #region GetDataMethods
        private async void GetData()
        {
            Language = await DataSource.GetAlphabetAsync();
            Resources = await DataSource.GetResourcesAsync();
        }
        #endregion
    }
}
