using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using Workshop.Demo.Module.Indexes;

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
            .WithDisplayName("Biography").WithEditor("TextArea").WithSettings(new TextFieldSettings { Hint = "Person's biography" })));
            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.CreateMapIndexTable(
                nameof(PersonPartIndex),
                table => table
                    .Column<string>(nameof(PersonPartIndex.ContentItemId), x => x.WithLength(26))
                    .Column<int>(nameof(PersonPartIndex.Handedness)));
            SchemaBuilder.AlterTable(nameof(PersonPartIndex), table => table
                .CreateIndex($"IDX_{nameof(PersonPartIndex)}_{nameof(PersonPartIndex.Handedness)}", nameof(PersonPartIndex.Handedness)));
            return 2;
        }
    }
}
