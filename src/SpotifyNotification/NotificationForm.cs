using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpotifyNotification
{
    public partial class NotificationForm : Form
    {
        // determines the maximum opacity this window fades to
        private const double MAX_OPACITY = 0.9D;
        private const string SPOTIFY_WINDOW_TITLE_SEPERATOR = " - ";
        private const string SPOTIFY_WINDOW_TITLE_NO_PLAYBACK = "Spotify";
        private const int MAX_FADE_DELAY = 100;

        private SpotifyPlayInfo _currentlyPlaying;
        private bool _isPlaying = false;

        private bool _fadeOut = false;
        private int _fadeDelay = MAX_FADE_DELAY;
        // when the form was clicked during display, it fades out faster and hovering the cursor over the form will not stop the fadeout.
        private bool _fastFadeOut = false;

        public NotificationForm()
        {
            InitializeComponent();
        }

        public void NotificationForm_Shown(object sender, EventArgs e)
        {
            // immideatly hide the form:
            Hide();

            // create workers:
            WorkerHelper.StartNew(SpotifyPlaybackWorker, 500);
            WorkerHelper.StartNew(OpacityWorker, 10);
        }

        private void UI_Click(object sender, EventArgs e)
        {
            if (!_fastFadeOut)
            {
                _fastFadeOut = true;
                _fadeDelay = 0;
            }
        }

        private Process GetSpotifyProcess() => Process.GetProcessesByName("Spotify").FirstOrDefault(w => w.MainWindowHandle != IntPtr.Zero);

        private void SpotifyPlaybackWorker()
        {
            var p = GetSpotifyProcess();

            if (p != null)
            {
                string windowTitle = p.MainWindowTitle;
                if (windowTitle.Contains(SPOTIFY_WINDOW_TITLE_SEPERATOR))
                {
                    string[] windowTitleParts = windowTitle.Split(new [] { " - " }, StringSplitOptions.None);
                    var detectedPlaying = new SpotifyPlayInfo(windowTitleParts[0], windowTitleParts[1]);

                    if (!_isPlaying || detectedPlaying != _currentlyPlaying)
                    {
                        _isPlaying = true;
                        _currentlyPlaying = detectedPlaying;

                        Invoke(new Action(ShowNotification));
                    }
                }
                else if (windowTitle == SPOTIFY_WINDOW_TITLE_NO_PLAYBACK)
                    _isPlaying = false;
            }
            else
                _isPlaying = false;
        }

        private void ShowNotification()
        {
            // update labels and title:
            lbl_artist.Text = _currentlyPlaying.Artist;
            lbl_song.Text = _currentlyPlaying.Song;
            Text = $"{_currentlyPlaying.Artist} - {_currentlyPlaying.Song}";

            // prepare fade in
            Opacity = 0D;
            _fadeOut = false;

            // set window location to top of primary screen:
            var primaryScreen = Screen.PrimaryScreen;
            Location = new Point(primaryScreen.Bounds.X + primaryScreen.Bounds.Width / 2 - Width / 2, 50);

            Show();
        }

        private void OpacityWorker()
        {
            Invoke(new Action(UpdateOpacity));
        }

        private void UpdateOpacity()
        {
            if (Visible)
            {
                if (!_fastFadeOut && Bounds.Contains(Cursor.Position))
                {
                    Opacity = MAX_OPACITY;
                    _fadeOut = true;
                    _fadeDelay = MAX_FADE_DELAY;
                }

                if (!_fadeOut)
                {
                    Opacity += 0.05D;
                    if (Opacity > MAX_OPACITY)
                    {
                        Opacity = MAX_OPACITY;
                        _fadeOut = true;
                        _fadeDelay = MAX_FADE_DELAY;
                    }
                }
                else
                {
                    if (_fadeDelay > 0)
                        _fadeDelay--;
                    else
                    {
                        if (_fastFadeOut)
                            Opacity -= 0.05D;
                        else
                            Opacity -= 0.025D;

                        if (Opacity <= 0D)
                            HideForm();
                    }
                }
            }
        }

        private void HideForm()
        {
            Opacity = 0D;
            _fadeOut = false;
            _fastFadeOut = false;
            Hide();
        }

        private void pic_logo_Click(object sender, EventArgs e)
        {
            var p = GetSpotifyProcess();
            if (p != null)
                WindowHelper.BringToFront(p);
        }
    }
}
