using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// https://www.youtube.com/watch?v=URw86vBWeGE

namespace MvSysClient
{
    [Serializable()]
    class MovieList : ISerializable {
        public Dictionary<String, Movie> Movies { get; set; }

        public MovieList(SerializationInfo info, StreamingContext context) {
            Movies = new Dictionary<String, Movie>();
        }
        public MovieList(SerializationInfo info, StreamingContext context, Dictionary<String, Movie> ml) {
            Movies = ml;

            foreach (KeyValuePair<String, Movie> m in Movies) {
                info.GetValue(m.Key, m.Key.GetType());
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            foreach(KeyValuePair<String, Movie> m in Movies) {
                info.AddValue(m.Key, m.Value);
            }
        }
    }
}
