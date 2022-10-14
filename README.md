# Blazor_Bootstrap5_Compo for WASM usage

Components : use integrated Bootstrap 5 theme. (floating label style)

![screen](https://github.com/fdonnet/Blazor_Bootstrap5_Compo/blob/main/screen.png)

## How to

A components lib for WASM (client) + an example project (standard Blazor WASM template + server) => run the server project to test the components (hosted mode by Kestrel).

Usage => (see index page of the sample client prj for src)

## Components

### General

Id and Label params are always linked to HTML generation (name and label of the compo).
You can use the compos in EditForm Blazor standard compo.

### CustomInputText

2 ways binding input text, floating label style.

##### Usage

```
<div class="col"><CustomInputText Id="compo1" Label="Input text" @bind-Value="view.ValueCompo1"></CustomInputText></div>
```

### CustomInputDate

2 ways binding Datepicker without input type="date" (floating label style). It allows you to force a specified format date (can be usefull for intranet etc). Floating label style.

It uses a string binding, so you need to TryParseExact in your ViewModel or in Automapper to convert back to DateTime etc.

Dependency to jsvanilla date picker ([web site link](https://mymth.github.io/vanillajs-datepicker/) / [github link](https://github.com/Jberivera/vanilla-datepicker)))

In your wwwroot/index.html file of your client WASM Blazor project you need to :
In head

```
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/vanillajs-datepicker@1.2.0/dist/css/datepicker-bs5.min.css">
```

At the end of body

```
<script src="https://cdn.jsdelivr.net/npm/vanillajs-datepicker@1.2.0/dist/js/datepicker.min.js">
```

You can add localisation too. (see official web site)

See Blazor_Bootstrap5_Compo/Form/CustomInputDate.razor.js for config

```
export function initDatePicker() {
    const elems = document.querySelectorAll('.datepicker_input');
    for (const elem of elems) {
        const datepicker = new Datepicker(elem, {
            format: 'dd.mm.yyyy',
            title: getDatePickerTitle(elem),
            buttonClass: 'btn',
            clearBtn: true,
            language: 'fr',
            autohide: true,
            default: '',
            todayBtn: true,
            updateOnBlur: true
        });
    }
}
```

In your parent compo or page you will need to trigger the TriggerInitDatePicker() via ref after the loading/binding. Maybe it will be better in .Net 7 with bind:after option. (see index page for sample)

##### Usage

```
<CustomInputDate @ref="CustomDatePicker" Id="compo2" Label="Date picker" @bind-Value="view.ValueCompo2"></CustomInputDate>
```

## CustomInputSelect

2 ways binding dynamic select box (floating label style).

Bind the selected value to an int (Inherits from `InputNumber<int>`).
You can pass any collection types you want for the possible choices `IEnumerable<TItem>` the `PropertyValueName` needs to be an int because we inherit `InputNumber<int>` for the binding.

##### Usage

```
<CustomInputSelect Id="select_test" Label="Custom select" Items="view.Collection"
                               TItem="ColObjectTest" @bind-Value="view.ValueCompo3" PropertyInnerTextName="Value" PropertyValueName="Id"></CustomInputSelect>
```

* TItem = specify the object type you use
* Items = collection of possible choices in your ViewModel
* PropertyInnerTextName = the property of the object you want to show
* PropertyValueName = value used for the binding (need to be an int)

## CustomMultiCheckbox

MultiCheckbox choices.
Be able to bind a collection from your ViewModel (dynamic). Restriction : the object need to implement a bool field to managed the checked (true/false).

##### Usage

```
<CustomMultiCheckbox Id="multi_checkbox" Label="Multi checkbox"
                                 TItem="ColObjectTest" PropertyValueName="Id" PropertyLabelName="Value"
                                 PropertyIsCheckedName="IsChecked" Items="@view.Collection"></CustomMultiCheckbox>
```

* TItem = specify the object type you use
* Items = collection of possible choices in your ViewModel
* PropertyLabelName = the property of the object you want to show (label)
* PropertyValueName = value used
* PropertyIsCheckedName = to manage checked true or false

# Conclusion

Have fun and don't hesitate to PR back. Pay me a coffee if you really want => bc1quu7wttgd3ywgaz4h67efqdl8454enavpxkvhpm

