using System;
using FluentValidation;

namespace PortfolioWebApp.Application.Features.MusicAPI;

public class SongVM
{
    public string URL { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
}
