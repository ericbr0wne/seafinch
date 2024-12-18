using api.Models;
using api.DTOs;
using System;

namespace api.Mappers
{
    public static class ValueMapper
    {
        public static List<ValueDto> MapToDto(SmhiResponse smhiResponse)
        {
            return smhiResponse.value.Select(v =>
            {
                DateTime date = DateTime.MinValue;
                try
                {
                    date = DateTimeOffset.FromUnixTimeMilliseconds(v.Date).UtcDateTime;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Invalid timestamp: {v.Date}, exception: {ex.Message}");
                }

                var position = smhiResponse.Position.FirstOrDefault();
                string positionDetails = position != null
                    ? $"Lat: {position.Latitude}, Lon: {position.Longitude}"
                    : "Position not available";

                return new ValueDto
                {
                    Date = date,
                    Value = v.value,
                    Quality = v.Quality,
                    Depth = v.Depth,
                    StationName = smhiResponse.Station?.Name ?? "Station not available",
                    Position = positionDetails,
                    Name = smhiResponse.Parameter.Name,
                    Unit = smhiResponse.Parameter.Unit
                };
            }).ToList();
        }
    }
}
