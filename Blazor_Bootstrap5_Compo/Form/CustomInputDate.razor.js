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


export function getDatePickerTitle(elem) {
    // From the label or the aria-label
    const label = elem.nextElementSibling;
    let titleText = '';
    if (label && label.tagName === 'LABEL') {
        titleText = label.textContent;
    } else {
        titleText = elem.getAttribute('aria-label') || '';
    }
    return titleText;
}

export function triggerValueChange(elemName) {
    var myElement = document.getElementById('elemName');
    var event = new Event('change');
    myElement.dispatchEvent(event);
}
