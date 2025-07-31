using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWebApp.Application;
using PortfolioWebApp.Application.Features.MusicAPI;
using PortfolioWebApp.Application.Features.MusicAPI.Queries;
using PortfolioWebApp.Domain.Models;
using PortfolioWebApp.Domain.Models.Singletons;

namespace PortfolioWebApp.UnitTest.Features;

[TestClass]
public sealed class MusicAPI
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly MusicData _musicData;
    public MusicAPI()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        var serviceProvider = DependencyInjection.AddServices(services).BuildServiceProvider();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
        _mapper = serviceProvider.GetRequiredService<IMapper>();
        _musicData = serviceProvider.GetRequiredService<MusicData>();
    }

    [TestMethod]
    public async Task GetSong()
    {
        Assert.IsInstanceOfType<Song>(await _musicData.GetSong());
    }

    [TestMethod]
    [DoNotParallelize]
    public async Task GetNextSongQuery()
    {
        SongVM songVM = await _mediator.Send(new GetNextSongQuery());
        Assert.IsInstanceOfType<SongVM>(songVM);
        Assert.AreEqual((await _musicData.GetSong()).URL, songVM.URL);
    }

    [TestMethod]
    [DoNotParallelize]
    public async Task GetRandomSongQuery()
    {
        SongVM songVM = await _mediator.Send(new GetRandomSongQuery());
        Assert.IsInstanceOfType<SongVM>(songVM);
        Assert.AreEqual((await _musicData.GetSong()).URL, songVM.URL);
    }
}
