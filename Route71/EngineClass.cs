﻿// This file is generated by Casasoft Contemporary Carte de Visite Tools
// https://github.com/strawberryfield/Contemporary_CDV

using Casasoft.CCDV;
using Casasoft.CCDV.Engines;
using Casasoft.CCDV.JSON;
using ImageMagick;
using System.Drawing;
using System.Text.Json;

namespace Route71
{
    internal class EngineClass : BaseEngine
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EngineClass() : base()
        {
            parameters = new ParametersClass();
            ScriptingClass = new ScriptingClass();
            AdjustFormatsImages();
            SplitTag();
        }

        private void AdjustFormatsImages()
        {
            fmt = new Formats(Dpi);
            img = new Images(fmt);
        }

        private string[] titles;
        private void SplitTag()
        {
            titles = Tag.Split(';');
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="par">Command line options</param>
        public EngineClass(ICommandLine par) : base(par)
        {
            CommandLineClass p = (CommandLineClass)par;
            // Add here custom parameters initialization

            ScriptingClass = new ScriptingClass();
            Script = p.Script;

            parameters = new ParametersClass();
            AdjustFormatsImages();
            SplitTag();
        }

        #region json
        /// <summary>
        /// Returns the parameters in json format
        /// </summary>
        /// <returns></returns>
        public override string GetJsonParams()
        {
            GetBaseJsonParams();
            ParametersClass p = (ParametersClass)parameters;
            // Add here custom parameters initialization

            return JsonSerializer.Serialize(p);
        }

        /// <summary>
        /// Sets the parameters from json formatted string
        /// </summary>
        /// <param name="json"></param>
        public override void SetJsonParams(string json)
        {
            ParametersClass? p = JsonSerializer.Deserialize<ParametersClass>(json);
            parameters = p;
            SetBaseJsonParams();
            // Add here custom parameters initialization
        }
        #endregion

        /// <summary>
        /// Does the dirty work
        /// </summary>
        /// <param name="quiet"></param>
        /// <returns></returns>
        public override MagickImage GetResult(bool quiet) => GetResult(quiet, 0);

        public MagickImage GetResult(bool quiet, int i)
        {
            _ = base.GetResult(quiet);
            Formats f = (Formats)fmt;
            Images im = (Images)img;

            MagickImage final = im.Poster_v();

            MagickImage img1 = Get(FilesList[i], quiet);
            MagickImage img2;
            string name1 = FilesList[i];
            img1 = HalfCard(img1, titles[i]);

            string name2 = string.Empty;
            i++;
            if (i < FilesList.Count)
            {
                img2 = Get(FilesList[i], quiet);
                name2 = titles[i];
            }
            else
            {
                img2 = im.InternalImage();
            }
            img2 = HalfCard(img2, name2);
            img2.Rotate(180);

            final.Composite(img1, Gravity.Northwest);
            final.Composite(img2, Gravity.Southeast);

            return final;
        }

        private MagickImage HalfCard(MagickImage image, string desc)
        {
            image.Trim();
            image.BorderColor = BorderColor;
            image.Border(1);
            MagickImage half = ((Images)img).HalfPoster_o();
            half.Composite(image, Gravity.Northeast, fmt.ToPixels(6), fmt.ToPixels(6));

            IExifProfile? exif = image.GetExifProfile();
            if (exif != null)
            {
                string GPSLongitudeRef = (string)exif.Values.Single(x => x.Tag == ExifTag.GPSLongitudeRef).GetValue();
                string GPSLatitudeRef = (string)exif.Values.Single(x => x.Tag == ExifTag.GPSLatitudeRef).GetValue();
                Rational[] GPSLongitude = (Rational[])exif.Values.Single(x => x.Tag == ExifTag.GPSLongitude).GetValue();
                Rational[] GPSLatitude = (Rational[])exif.Values.Single(x => x.Tag == ExifTag.GPSLatitude).GetValue();
                string gps = $"{FormatCoords(GPSLatitude)} {GPSLatitudeRef}   -   {FormatCoords(GPSLongitude)} {GPSLongitudeRef}";

                Drawables d = new Drawables();
                d.FontPointSize(fmt.ToPixels(43) / 10)
                    .Font("TravelingTypewriter.otf")
                    .FillColor(MagickColors.DarkRed)
                    .Gravity(Gravity.Southeast)
                    .Text(fmt.ToPixels(6), fmt.ToPixels(6), gps)
                    .Draw(half);

                d = new Drawables();
                d.FontPointSize(fmt.ToPixels(53) / 10)
                    .Font("TravelingTypewriter.otf")
                    .FillColor(MagickColors.Black)
                    .Gravity(Gravity.Southeast)
                    .Text(fmt.ToPixels(6), fmt.ToPixels(13), desc)
                    .Draw(half);
            }
            // For test only
            //half.BorderColor = BorderColor;
            //half.Border(1);

            return half;
        }

        private string FormatCoords(Rational[] c) => $"{c[0].ToDouble()}° {c[1].ToDouble()}' {Math.Round(c[2].ToDouble(), 0)}\"";

        private MagickImage Get(string filename, bool quiet)
        {
            if (!quiet) Console.WriteLine($"Processing: {filename}");
            MagickImage image = Utils.ResizeAndFill(Utils.GetImage(filename), ((Formats)fmt).InternalImage, MagickColors.White, Gravity.Northeast);

            return image;
        }
    }
}