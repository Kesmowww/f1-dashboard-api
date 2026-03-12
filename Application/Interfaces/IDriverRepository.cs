using Domain.Entities;

namespace Application.Interfaces;

public interface IDriverRepository
{
    /*
     * This is the method who will fetch the data from the repository
     * It's like an contract for don't work directly with the repository
     */
    Task<List<Driver>> GetDriverStandingsAsync();
}