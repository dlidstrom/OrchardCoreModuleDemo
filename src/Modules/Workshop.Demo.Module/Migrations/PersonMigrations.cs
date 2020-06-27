using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Workshop.Demo.Module.Migrations
{
    public class PersonMigrations : DataMigration
    {
        private readonly IContentDefinitionManager contentDefinitionManager;

        public PersonMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            this.contentDefinitionManager = contentDefinitionManager;
        }

        // reflection

        public int Create()
        {
            contentDefinitionManager.AlterPartDefinition(nameof(PersonPart),
            part => part.Attachable()
            .WithField(nameof(PersonPart.Biography), field => field.OfType(nameof(TextField))
            .WithDisplayName("Biography").WithEditor("TextArea").WithSettings(new TextFieldSettings{Hint = "Person's biography"})));
            return 1;
        }

        // public int UpdateFrom1()
        // {
        //     return 2;
        // }
    }
}
