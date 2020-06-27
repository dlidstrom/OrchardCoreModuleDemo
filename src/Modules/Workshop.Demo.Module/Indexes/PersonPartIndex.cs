using OrchardCore.ContentManagement;
using YesSql.Indexes;

namespace Workshop.Demo.Module.Indexes
{
    public class PersonPartIndex : MapIndex
    {
        public string ContentItemId { get; set; }
        public Handedness Handedness { get; set; }
    }

    public class PersonPartIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<PersonPartIndex>().Map(x =>
            {
                var personPart = x.As<PersonPart>();
                if (personPart == null)
                {
                    return null;
                }

                return new PersonPartIndex
                {
                    ContentItemId = x.ContentItemId,
                    Handedness = personPart.Handedness
                };
            });
        }
    }
}
