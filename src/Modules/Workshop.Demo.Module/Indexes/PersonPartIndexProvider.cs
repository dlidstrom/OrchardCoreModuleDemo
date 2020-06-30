using OrchardCore.ContentManagement;
using Workshop.Demo.Module.Models;
using YesSql.Indexes;

namespace Workshop.Demo.Module.Indexes
{
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
