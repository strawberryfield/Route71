using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route71;

internal class Images : Casasoft.CCDV.Images
{
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dpi">Resolution of images</param>
    public Images(int dpi) : base(dpi)
    {
        fmt = new Formats(dpi);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <remarks>
    /// The resolution is set to the default 300 DPI
    /// </remarks>
    public Images() : this(300)
    {

    }

    /// <summary>
    /// Construcot
    /// </summary>
    /// <param name="f">
    /// Instance of <see cref="Casasoft.CCDV.Formats"/> class used to set the
    /// resolution of the images
    /// </param>
    public Images(Casasoft.CCDV.IFormats f) : base(f)
    {
        fmt = new Formats(f.DPI);
    }

    public MagickImage Poster_v(MagickColor c) => new(c, ((Formats)fmt).Poster_v.Width, ((Formats)fmt).Poster_v.Height);
    public MagickImage HalfPoster_o(MagickColor c) => new(c, ((Formats)fmt).HalfPoster_o.Width, ((Formats)fmt).HalfPoster_o.Height);
    public MagickImage Poster_v() => Poster_v(MagickColors.White);
    public MagickImage HalfPoster_o() => HalfPoster_o(MagickColors.White);
    public MagickImage InternalImage(MagickColor c) => new(c, ((Formats)fmt).InternalImage.Width, ((Formats)fmt).InternalImage.Height);
    public MagickImage InternalImage() => InternalImage(MagickColors.White);


}
