namespace SpotifyNotification
{
    /// <summary>
    /// Info about currently playing song/artist.
    /// </summary>
    internal struct SpotifyPlayInfo
    {
        public readonly string Song;
        public readonly string Artist;

        public SpotifyPlayInfo(string song, string artist)
        {
            Song = song;
            Artist = artist;
        }

        #region Equality

        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == typeof(SpotifyPlayInfo) ? (SpotifyPlayInfo)obj == this : false;
        }

        public static bool operator ==(SpotifyPlayInfo left, SpotifyPlayInfo right)
        {
            return left.Artist == right.Artist && left.Song == right.Song;
        }

        public static bool operator !=(SpotifyPlayInfo left, SpotifyPlayInfo right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Song.GetHashCode() ^ Artist.GetHashCode();
        }

        #endregion
    }
}
