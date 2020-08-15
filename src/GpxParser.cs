using Endomondo.Export.Models.Gpx;
using System;
using System.Collections.Generic;

namespace Endomondo.Export
{
    public class GpxParser : IGpxParser
    {
        public Gpx Parse(string activity, string workoutId)
        {
            var result = new Gpx
            {
                version = "1.1",
                creator = "https://github.com/tmk-w/Endomondo.Export",
            };

            var lines = activity.Split('\n');

            string[] info = lines[1].Split(';');
            if (info.Length >= 9)
            {
                var metaData = new Metadata
                {
                    time = DateTime.ParseExact(info[6], "yyyy-MM-dd HH:mm:ss UTC", System.Globalization.CultureInfo.InvariantCulture),
                };

                var trk = new Trk
                {
                    name = $"{Enum.GetName(typeof(Constants.SportType), int.Parse(info[5]))}_{workoutId}",
                    type = Enum.GetName(typeof(Constants.SportType), int.Parse(info[5])),
                    trkseg = new Trkseg { trkpt = new List<Trkpt>() }
                };

                for (int i = 2; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(';');
                    if (values.Length >= 9)
                    {
                        trk.trkseg.trkpt.Add(new Trkpt
                        {
                            time = DateTime.ParseExact(values[0], "yyyy-MM-dd HH:mm:ss UTC", System.Globalization.CultureInfo.InvariantCulture),
                            lat = values[2],
                            lon = values[3],
                            ele = values[6],
                        });
                    }
                }

                result.metadata = metaData;
                result.trk = trk;
            }

            return result;
        }
    }

    public interface IGpxParser
    {
        Gpx Parse(string activity, string workoutId);
    }
}
