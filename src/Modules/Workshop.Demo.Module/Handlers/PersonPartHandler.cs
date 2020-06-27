using System.Threading.Tasks;
using OrchardCore.ContentManagement.Handlers;

namespace Workshop.Demo.Module.Handlers
{
    // see DefaultContentManager.cs row 541
    public class PersonPartHandler : ContentPartHandler<PersonPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, PersonPart instance)
        {
            context.ContentItem.DisplayText = instance.Name;
            return Task.CompletedTask;
        }
    }
}
