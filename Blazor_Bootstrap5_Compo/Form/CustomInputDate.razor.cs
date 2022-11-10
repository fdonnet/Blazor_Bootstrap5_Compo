using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor_Bootstrap5_Compo.Form
{
    /// <summary>
    /// To use this component you need to :
    /// <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/vanillajs-datepicker@1.2.0/dist/css/datepicker-bs5.min.css"> in head of index.html
    /// and <script src="https://cdn.jsdelivr.net/npm/vanillajs-datepicker@1.2.0/dist/js/datepicker.min.js"></script> at the bottom of body in index.html
    /// you need to call TriggerInitDatePicker from your parent compo/page to init the calendar after your data have been loaded in page
    /// It will be easier with .NET 7 via bind:after option
    /// 
    /// </summary>
    public partial class CustomInputDate : IAsyncDisposable
    {
        [Parameter]
        public string Id { get; set; } = "Id";
        [Parameter]
        public string Label { get; set; } = String.Empty;

        [Inject]
        public IJSRuntime MyJs { get; set; } = null!;

        private IJSObjectReference? _module;

        public async Task TriggerInitDatePicker()
        {
            _module ??= await MyJs.InvokeAsync<IJSObjectReference>("import", "./_content/Blazor_Bootstrap5_Compo/Form/CustomInputDate.razor.js");

                await _module.InvokeVoidAsync("initDatePicker");
        }

        public async Task FocusOut()
        {
            if (_module is not null)
                await _module.InvokeVoidAsync("triggerChangeEvent",Id);
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
        }

        

    }
}
