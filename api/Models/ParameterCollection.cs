using System;
using System.Collections.Generic;

namespace api.Models
{
    public class SmhiResponse
    {
        public long Updated { get; set; }
        public Parameter Parameter { get; set; }
        public Station Station { get; set; }
        public Period Period { get; set; }
        public List<Position> Position { get; set; }
        public List<Link> Link { get; set; }
        public List<Value> value { get; set; }
    }
    public class Parameter
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }

    public class Station
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }

    }

    public class Period
    {
        public string Key { get; set; }
        public long From { get; set; }
        public long To { get; set; }
        public string Summary { get; set; }
    }

    public class Position
    {
        public long From { get; set; }
        public long To { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Type { get; set; }
    }

    public class Value
    {
        public long Date { get; set; }
        public double value { get; set; }
        public string Quality { get; set; }
        public string Depth { get; set; }
    }

}
