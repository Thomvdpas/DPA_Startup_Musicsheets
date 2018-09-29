using DPA_Musicsheets.Managers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DPA_Musicsheets.ViewModels
{
    /// <summary>
    /// The viewmodel for playing midi sequences.
    /// It supports starting, stopping and restarting.
    /// </summary>
    public class MidiPlayerViewModel : ViewModelBase
    {
        private readonly MidiPlayer _midiPlayer;

        public MidiPlayerViewModel(ImprovedMusicLoader musicLoader)
        {
            _midiPlayer = new MidiPlayer();
            musicLoader.MidiLoaded += (_, args) => _midiPlayer.MidiSequencer = args;

            // TODO: Can we use some sort of eventing system so the managers layer doesn't have to know the viewmodel layer?
            musicLoader.MidiPlayerViewModel = this;
        }

        private void UpdateButtons()
        {
            PlayCommand.RaiseCanExecuteChanged();
            PauseCommand.RaiseCanExecuteChanged();
            StopCommand.RaiseCanExecuteChanged();
        }

        #region buttons for play, stop, pause
        public RelayCommand PlayCommand => new RelayCommand(() =>
        {
            _midiPlayer.Start();
            UpdateButtons();
        }, () => !_midiPlayer.IsRunning);

        public RelayCommand StopCommand => new RelayCommand(() =>
        {
            _midiPlayer.Stop();
            UpdateButtons();
        }, () => _midiPlayer.IsRunning);

        public RelayCommand PauseCommand => new RelayCommand(() =>
        {
            _midiPlayer.Pause();
            UpdateButtons();
        }, () => _midiPlayer.IsRunning);

        #endregion buttons for play, stop, pause

        /// <summary>
        /// Stop the player and clear the sequence on cleanup.
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
            _midiPlayer.Cleanup();
        }
    }
}
