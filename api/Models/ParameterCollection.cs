using System;
using System.Collections.Generic;

namespace api.Models
{
    public class Parameter
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }

    public class Period
    {
        public string Key { get; set; }
        public long From { get; set; }
        public long To { get; set; }
        public string Summary { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Type { get; set; }
    }

    public class StationData
    {
        public long Date { get; set; }
        public double Value { get; set; }
        public string Quality { get; set; }
        public string Depth { get; set; }
    }

    public class Position
    {
        public long From { get; set; }
        public long To { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Station
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }

        // The "position" array corresponds to List<Position>
        public List<Position> Position { get; set; }

        // The "value" array corresponds to List<StationData>
        public List<StationData> Value { get; set; }
    }

    // Represents the full SmhiResponse in the JSON
    public class SmhiResponse
    {
        public long Updated { get; set; }
        public Parameter Parameter { get; set; }
        public Period Period { get; set; }

        // The "station" is a single object, so it should be a single Station object
        public Station Station { get; set; }

        // The "link" array corresponds to List<Link>
        public List<Link> Link { get; set; }
    }
}
