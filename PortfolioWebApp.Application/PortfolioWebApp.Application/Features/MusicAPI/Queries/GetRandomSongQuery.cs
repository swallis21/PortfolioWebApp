using AutoMapper;
using MediatR;
using PortfolioWebApp.Domain.Models;
using PortfolioWebApp.Domain.Models.Singletons;

namespace PortfolioWebApp.Application.Features.MusicAPI.Queries;

public record GetRandomSongQuery : IRequest<SongVM>;

public class GetRandomSongHandler : IRequestHandler<GetRandomSongQuery, SongVM>
{

    private readonly MusicData _musicData;
    private readonly IMapper _mapper;

    public GetRandomSongHandler(MusicData musicData, IMapper mapper)
    {
        _musicData = musicData;
        _mapper = mapper;
    }

    public async Task<SongVM> Handle(GetRandomSongQuery request, CancellationToken token) => _mapper.Map<Song, SongVM>(await _musicData.RandomSong());
}
