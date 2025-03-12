export class ServiceSelector {
    constructor(elementQuery) {
        //this.options = this.element.selector.find("option")
        this.defaultOption = "<option value='' selected>---- Open this select menu ----</option>";
    }
    Initial = async function (elementId = null) {
        if(elementId != null) $(elementId).html(this.defaultOption);
    }
    CreateOptions = async function ({ elementId = null, data = null }) {
        var options = (defaultOptions == false) ? "" : this.defaultOption;
        if (elementId != null) {
            await $.each(data, function () {
                options += `<option value='${this}'>${this}</option>`;
            });
            $(elementId).append(options)
        }
    }
    ClearOptions = async function (elementId = null) {
        if (selectorId !== null) {
            $(elementId).find("option").remove();
        }
    }
}