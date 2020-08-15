using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Endomondo.Export.Models.Gpx
{
    [XmlRoot(ElementName = "trkpt", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Trkpt
    {
        public string ele { get; set; }
        public DateTime time { get; set; }
        [XmlAttribute("lat")]
        public string lat { get; set; }
        [XmlAttribute("lon")]
        public string lon { get; set; }
    }

    [XmlRoot(ElementName = "trkseg", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Trkseg
    {
        [XmlElement("trkpt")] 
        public List<Trkpt> trkpt { get; set; }
    }

    [XmlRoot(ElementName = "trk", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Trk
    {
        public string name { get; set; }

        public string type { get; set; }

        public Trkseg trkseg { get; set; }
    }

    [XmlRoot(ElementName = "gpx", Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Gpx
    {
        [XmlAttribute]
        public string creator { get; set; }

        [XmlAttribute]
        public string version { get; set; }

        public Metadata metadata { get; set; }

        public Trk trk { get; set; }
    }

    public class Metadata
    {
        public DateTime time { get; set; }
    }
}