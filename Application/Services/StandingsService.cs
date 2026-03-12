using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class StandingsService(IDriverRepository driverRepository)
{
    
    public async Task<List<Driver>> GetDriverStandingsAsync() => await driverRepository.GetDriverStandingsAsync();
}