using DPA_Musicsheets.Managers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using DPA_Musicsheets.Command;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Piece _piece;

        public string FileName => FileHandlingCommand.MusicLoader.FilePath ?? string.Empty;
            
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

        public MainViewModel()
        {

        }

        private void OpenFile()
        {
            var openFileCommand = new OpenFileCommand();
            openFileCommand.Execute();
            RaisePropertyChanged(nameof(FileName));
        }

        private void LoadFile()
        {
            var loadFileCommand = new LoadFileCommand();
            loadFileCommand.Execute();
            _piece = loadFileCommand.Piece;
        }

        public ICommand OpenFileCommand => new RelayCommand(OpenFile);

        public ICommand LoadCommand => new RelayCommand(LoadFile);


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
