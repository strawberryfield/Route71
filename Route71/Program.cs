﻿// This file is generated by Casasoft Contemporary Carte de Visite Tools
// https://github.com/strawberryfield/Contemporary_CDV

using ImageMagick;
using Route71;

#region texts
string desc = "Route 71 fanzine builder";
string longDesc = @"Route 71 fanzine builder";
#endregion

#region command line
CommandLineClass par = new("page", desc)
{
    Usage = "[options]* inputfile+",
    LongDesc = longDesc
};
if (par.Parse(args)) return;
#endregion

EngineClass engine = new(par);
for (int i = 0; i < par.FilesList.Count; i += 2)
{
    MagickImage final = engine.GetResult(false, i);
    engine.fmt.SetImageParameters(final, par.Extension);
    final.Write($"{par.OutputName}-{i / 2 + 1,3:D3}.{par.Extension}");
}