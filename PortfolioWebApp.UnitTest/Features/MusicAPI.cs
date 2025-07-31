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
    public MusicAPI()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        var serviceProvider = DependencyInjection.AddServices(services).BuildServiceProvider();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
        _mapper = serviceProvider.GetRequiredService<IMapper>();
    }

    [TestMethod]
    public async Task GetSong()
    {
        MusicData data = new MusicData();
        Assert.IsInstanceOfType<Song>(await data.GetSong());
    }

    [TestMethod]
    public async Task GetNextSongQuery()
    {
        MusicData data = new MusicData();
        SongVM songVM = await _mediator.Send(new GetNextSongQuery());
        Assert.IsInstanceOfType<SongVM>(songVM);
        Assert.AreEqual((await data.GetSong()).URL, songVM.URL);
    }

    [TestMethod]
    public async Task GetRandomSongQuery()
    {
        MusicData data = new MusicData();
        SongVM songVM = await _mediator.Send(new GetRandomSongQuery());
        Assert.IsInstanceOfType<SongVM>(songVM);
        Assert.AreEqual((await data.GetSong()).URL, songVM.URL);
    }
}
