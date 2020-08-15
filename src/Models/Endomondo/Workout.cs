using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endomondo.Export.Models.Endomondo
{
    public class Workout
    {
        public string id { get; set; }

        public string start_time { get; set; }

        public string name { get; set; }

        public string sport { get; set; }

        public string steps { get; set; }

        public string distance_km { get; set; }

        public string duration_sec { get; set; }

        public string speed_kmh_avg { get; set; }
        public string speed_kmh_max { get; set; }

        public string route_id { get; set; }
        public string altitude_m_max { get; set; }
        public string altitude_m_min { get; set; }
        public string calories { get; set; }
        public string hydration { get; set; }
    }

    public class WorkoutList
    {
        public List<Workout> data { get; set; }
    }
}