using Microsoft.AspNetCore.Components;

namespace Blazor_Bootstrap5_Compo.Form
{
    public partial class CustomInputCheckbox
    {
        [Parameter]
        public string Id { get; set; } = "Id";
        [Parameter]
        public string Label { get; set; } = String.Empty;

    }
}
