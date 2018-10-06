using DPA_Musicsheets.Managers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace DPA_Musicsheets.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MusicLoader _musicLoader;
        private readonly FileManager _fileManager;

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                RaisePropertyChanged(() => FileName);
            }
        }

        /// <summary>
        /// The current state can be used to display some text.
        /// "Rendering..." is a text that will be displayed for example.
        /// </summary>
        private string _currentState;
        public string CurrentState
        {
            get => _currentState;
            set { _currentState = value; RaisePropertyChanged(() => CurrentState); }
        }

        public MainViewModel(MusicLoader musicLoader)
        {
            // TODO: Can we use some sort of eventing system so the managers layer doesn't have to know the viewmodel layer?
            _musicLoader = musicLoader;
            _fileManager = new FileManager();
            FileName = @"Files/Alle-eendjes-zwemmen-in-het-water.mid";
        }

        public ICommand OpenFileCommand => new RelayCommand(() =>
        {
            FileName =_fileManager.OpenFile();
        });

        public ICommand LoadCommand => new RelayCommand(() =>
        {
            _fileManager.LoadFile(FileName);
        });

        #region Focus and key commands, these can be used for implementing hotkeys
        public ICommand OnLostFocusCommand => new RelayCommand(() =>
        {
            Console.WriteLine("Maingrid Lost focus");
        });

        public ICommand OnKeyDownCommand => new RelayCommand<KeyEventArgs>((e) =>
        {
            Console.WriteLine($"Key down: {e.Key}");
        });

        public ICommand OnKeyUpCommand => new RelayCommand(() =>
        {
            Console.WriteLine("Key Up");
        });

        public ICommand OnWindowClosingCommand => new RelayCommand(() =>
        {
            ViewModelLocator.Cleanup();
        });
        #endregion Focus and key commands, these can be used for implementing hotkeys
    }
}
