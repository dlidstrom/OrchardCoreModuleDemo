using Workshop.Demo.Module.Models;
using YesSql.Indexes;

namespace Workshop.Demo.Module.Indexes
{
    public class PersonPartIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public Handedness Handedness { get; set; }
    }
}
