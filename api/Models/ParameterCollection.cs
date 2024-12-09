using System.Collections.Generic;

namespace api.Models
{
    public record OceanographyLink(
        string Href,
        string Rel,
        string Type
    );

    public record StationSet(
        string Key,
        long Updated,
        string Title,
        string Summary,
        List<OceanographyLink> Link
    );

    public record Station(
        string Key,
        long Updated,
        string Title,
        string Summary,
        List<OceanographyLink> Link,
        int Id,
        string Name,
        double Latitude,
        double Longitude,
        bool Active,
        long From,
        long To,
        bool Mobile
    );

    public record OceanographyParameter(
        string Key,
        string Title,
        string Summary,
        string Unit,
        List<OceanographyLink> Link,
        List<StationSet> StationSet,
        List<Station> Station
    );
}
