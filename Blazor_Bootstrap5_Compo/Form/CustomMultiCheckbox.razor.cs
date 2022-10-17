using Microsoft.AspNetCore.Components;
using Blazor_Bootstrap5_Compo.Helpers;

namespace Blazor_Bootstrap5_Compo.Form
{
    public partial class CustomMultiCheckbox<TItem>
    {
        [Parameter]
        public IEnumerable<TItem> Items { get; set; } = null!;

        [Parameter]
        public string Id { get; set; } = "Id";
        [Parameter]
        public string Label { get; set; } = "Label";

        [Parameter]
        public string PropertyValueName { get; set; } = "Key";
        [Parameter]
        public string PropertyLabelName { get; set; } = "Label";
        [Parameter]
        public string PropertyIsCheckedName { get; set; } = "Checked";


        private bool GetIsChecked(TItem item)
        {
            return HelperDynamic<TItem>.GetPropertyBoolValue(item, PropertyIsCheckedName);
        }

        private static string GetPropertyValue(TItem item, string propertyName)
        {
            return HelperDynamic<TItem>.GetPropertyValue(item, propertyName);
        }

        private void OnChangeChecked(TItem item, bool currentIsChecked)
        {
            HelperDynamic<TItem>.SetPropertyBoolValue(item, PropertyIsCheckedName, !currentIsChecked);
        }
    }

    public class CustomCheckBoxEventArgs : EventArgs
    {
        public object Item { get; set; } = null!;
        public bool CurrentIsChecked { get; set; }
    }



}
