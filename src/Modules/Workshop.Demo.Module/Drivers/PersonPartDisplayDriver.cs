using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Workshop.Demo.Module.Models;
using Workshop.Demo.Module.ViewModels;

namespace Workshop.Demo.Module.Drivers
{
    // Local zones
    // for Content:5 (part, weight)
    // see Content.Edit.cshtml in OC source (Model.{Content, Actions, Parts, Sidebar})
    public class PersonPartDisplayDriver : ContentPartDisplayDriver<PersonPart>
    {
        public override IDisplayResult Display(PersonPart part, BuildPartDisplayContext context)
        {
            return Initialize<PersonPartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
                .Location("Detail", "Content:5")
                .Location("Summary", "Content:5");
        }

        public override IDisplayResult Edit(PersonPart part, BuildPartEditorContext context)
        {
            return Initialize<PersonPartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel))
               .Location("Content:5");
        }

        public override async Task<IDisplayResult> UpdateAsync(PersonPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new PersonPartViewModel();
            await updater.TryUpdateModelAsync(viewModel, Prefix);
            part.BirthDateUtc = viewModel.BirthDateUtc;
            part.Name = viewModel.Name;
            part.Handedness = viewModel.Handedness;
            return Edit(part, context);
        }

        private void PopulateViewModel(PersonPart part, PersonPartViewModel viewModel)
        {
            viewModel.BirthDateUtc = part.BirthDateUtc;
            viewModel.Name = part.Name;
            viewModel.Handedness = part.Handedness;
        }
    }
}
