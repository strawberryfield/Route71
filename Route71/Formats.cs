using ImageMagick;

namespace Route71;

internal class Formats : Casasoft.CCDV.Formats
{
    public Formats() : base()
    {
    }

    public Formats(int dpi) : base(dpi)
    {
    }

    public MagickGeometry Poster_v => new(ToPixels(302), ToPixels(452));
    public MagickGeometry HalfPoster_o => new(Poster_v.Width, Poster_v.Height / 2 - ToPixels(4));
    private int vsize => ToPixels(190);
    public MagickGeometry InternalImage => new(vsize / 3 * 4, vsize);
}
