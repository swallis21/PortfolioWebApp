using AutoMapper;
using PortfolioWebApp.Application.Features.MusicAPI;
using PortfolioWebApp.Domain.Models;

namespace PortfolioWebApp.Application.Configuration;

public class AutoMapperConfig : Profile
{
    public static Action<IMapperConfigurationExpression> MapperConfig { get
        {
            return new Action<IMapperConfigurationExpression>(cfg =>
            {
                cfg.CreateMap<Song, SongVM>().ReverseMap();
            });
        }
    }
}
