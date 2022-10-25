using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
