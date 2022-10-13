using Microsoft.AspNetCore.Components;
using Blazor_Bootstrap5_Compo.Helpers;

namespace Blazor_Bootstrap5_Compo.Form
{
    
    public partial class CustomInputSelect<TItem>
    {
        [Parameter]
        public string Id { get; set; } = "Id";
        [Parameter]
        public string Label { get; set; } = String.Empty;
        [Parameter]
        public IEnumerable<TItem> Items { get; set; } = null!;
        [Parameter]
        public string PropertyValueName { get; set; } = "Key";
        [Parameter]
        public string PropertyInnerTextName { get; set; } = "Value";

        public static string GetPropertyValue(TItem item, string propertyName)
        {
            return HelperDynamic<TItem>.GetPropertyValue(item, propertyName);

        }
    }

}

