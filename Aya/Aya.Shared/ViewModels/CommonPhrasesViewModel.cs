using Aya.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aya.ViewModels
{
    public class CommonPhrasesViewModel : ViewModelBase
    {
        public CommonPhrasesViewModel()
        {
            if (IsInDesignMode)
            {
                PagePhraseGroup = new PhraseGroup("Cool phrase group");
                PagePhraseGroup.FullPhrases = new ObservableCollection<Phrase>();
                PagePhraseGroup.DisplayPhrases = new ObservableCollection<Phrase>();
                for (int jj = 0; jj < 30; jj++)
                {
                    PagePhraseGroup.FullPhrases.Add(new Phrase
                    {
                        Original = "Мне нужно в",
                        SAMPA = "mnye nuzh-na v",
                        Translated = "Necesito ir a",
                        Description = jj % 3 == 0 ? "Debes agregar el lugar al que quieres ir al final Debes agregar el lugar al que quieres ir al final Debes agregar el lugar al que quieres ir al final Debes agregar el lugar al que quieres ir al final Debes agregar el lugar al que quieres ir al final" : "Debes agregar el lugar al que quieres ir al final"
                    });
                    if (jj < 3)
                        PagePhraseGroup.DisplayPhrases.Add(PagePhraseGroup.FullPhrases[jj]);
                }
                SelectedPhrase = PagePhraseGroup.FullPhrases[0];
            }

            _loadDataCommand = new RelayCommand(() =>
            {
                PagePhraseGroup = (App.Current.Resources["Locator"] as ViewModelLocator).HubVM.SelectedPhraseGroup;
            });
        }

        #region Exposed properties
        private PhraseGroup _pagePhraseGroup;

        public PhraseGroup PagePhraseGroup
        {
            get { return _pagePhraseGroup; }
            set { _pagePhraseGroup = value; RaisePropertyChanged(); }
        }


        private Phrase _selectedPhrase;

        public Phrase SelectedPhrase
        {
            get { return _selectedPhrase; }
            set { _selectedPhrase = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Commandls
        private RelayCommand _loadDataCommand;

        public RelayCommand LoadDataCommand
        {
            get { return _loadDataCommand; }
        }
        #endregion
    }
}
