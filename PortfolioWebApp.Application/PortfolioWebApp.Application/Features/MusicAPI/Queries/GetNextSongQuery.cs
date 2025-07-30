using AutoMapper;
using MediatR;
using PortfolioWebApp.Domain.Models;
using PortfolioWebApp.Domain.Models.Singletons;

namespace PortfolioWebApp.Application.Features.MusicAPI.Queries;

public record GetNextSongQuery : IRequest<SongVM>;

public class GetNextSongHandler : IRequestHandler<GetNextSongQuery, SongVM>
{

    private readonly MusicData _musicData;
    private readonly IMapper _mapper;

    public GetNextSongHandler(MusicData musicData, IMapper mapper)
    {
        _musicData = musicData;
        _mapper = mapper;
    }

    public async Task<SongVM> Handle(GetNextSongQuery request, CancellationToken token) => _mapper.Map<Song, SongVM>(await _musicData.NextSong());
}
