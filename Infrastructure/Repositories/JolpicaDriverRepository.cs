using System.Text.Json;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class JolpicaDriverRepository(HttpClient httpClient): IDriverRepository
{
    //This the url to fetch the data from jolpica
    private const string Url = 
        "http://api.jolpi.ca/ergast/f1/current/driverStandings.json";

    public async Task<List<Driver>> GetDriverStandingsAsync()
    {
        //Create the url to the api jolpica
        var response = await httpClient.GetStringAsync(Url);
        
        //Get the reponse from the url on the json
        var json = JsonDocument.Parse(response);
        
        //Read the json and take the data from the standings
        var standings = json
                .RootElement
                .GetProperty("MRData")
                .GetProperty("StandingsTable")
                .GetProperty("StandingsLists")[0]
                .GetProperty("DriverStandings")
                .EnumerateArray();
        
        //Create my driver list
        var drivers = new List<Driver>();
        
        //Add the data to the driver list
        foreach (var item in standings)
        {
            
            // Some driver have not a position (DNS, DSQ)
            var positionText = item.GetProperty("positionText").GetString();
            var position = int.TryParse(positionText, out var p) ? p : 0;
            
            //For each item in the standings list
            drivers.Add(new Driver
            {
                //We add the data to the driver
                Position   = position,
                Points     = double.Parse(item.GetProperty("points").GetString()!),
                Wins       = int.Parse(item.GetProperty("wins").GetString()!),
                FirstName  = item.GetProperty("Driver").GetProperty("givenName").GetString()!,
                LastName   = item.GetProperty("Driver").GetProperty("familyName").GetString()!,
                DriverId   = item.GetProperty("Driver").GetProperty("driverId").GetString()!,
                Nationality= item.GetProperty("Driver").GetProperty("nationality").GetString()!,
                Team       = item.GetProperty("Constructors")[0].GetProperty("name").GetString()!,
            });
        }
        
        //Return the driver list
        return drivers;
        
    }
}