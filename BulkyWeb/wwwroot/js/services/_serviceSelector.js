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
    ClearOptionsAll = async function (selectorId) {
        console.log(this.element.selector);
        if (selectorId !== undefined) {
            $(selectorId).find("option").remove();
        }
        else {
            this.element.selector.find("option").remove();
        }
    }

    CreateOptionsByCondition = async function ({ id = null, data = null, text = null, value = null, defaultOptions = true }) {

        var options = (defaultOptions == false) ? "" : this.defaultOption;
        if (data != null) {
            if (data.length > 0) {
                //key: response.arrMonth.map(x => x["strMonth"]),
                //value: response.arrMonth.map(x => x["month"])
                await $.each(data, function () {
                    options += "<option value='" + this[value] + "'>" + this[text] + "</option>";
                });
                //console.log(options);

            }
            else {
                options += "<option value='" + data[value] + "'>" + data[text] + "</option>";
            }

            if (id != null) {
                $(id).html(options);
            }
            else {
                this.element.selector.html(options);
            }
        }

    }
    SelectedByValue = function ({ id = null, value = null }) {
        //console.log("Utility_element");
        //console.log(obj);
        var options = $(id + ' option').filter(function () {
            return $(this).val() === value
        });

        options.prop("selected", true);
        //options.each(function () {
        //    if (this.value == value) {
        //        this.selected = true;
        //    }
        //    else {
        //        this.selected = false;
        //    }
        //});
    }
    async AppendOptions({ id = null, data = null }) {
        var options = "";
        await $.each(data, function () {
            options += `<option value='${this}'>${this}</option>`;
        });
        if (id != null) {
            $(id).append(options);
        }
        else {
            $(this.select).append(options);
        }
    }
    async AppendOptionsByCondition({ id = null, data = null, value = null, text = null }) {
        //console.log(Obj);
        //var array = [];
        //var keys = []
        //let i = 0;
        var options = "";
        if (data.length > 0) {
            //key: response.arrMonth.map(x => x["strMonth"]),
            //value: response.arrMonth.map(x => x["month"])
            await $.each(data, function () {
                options += "<option value='" + this[value] + "'>" + this[text] + "</option>";
            });
            $(id).append(options);
        }
    }
    Clear(id = null) {
        var options = this.options;
        if (id == null) {
            this.element.selector.html(options);
        }
        else {
            $(id).html(options);
        }
    }
    ClearAll(id = null) {
        if (id == null) {
            this.element.selector.html();
        }
        else {
            $(id).html();
        }
    }
    async UnSelect(id = null) {
        if (id == null) {
            await this.element.selector.find("option").each(function () {
                //(this.value == null || this.value == "") ? this.selected = true : this.selected = false;
                if (this.value == null || this.value == "") {
                    this.selected = true;
                    return false; //break
                }
                else {
                    this.selected = false;
                }
            });
        }
        else {
            $(id).find("option").prop("selected", false);
            //$(id + " option").each(function () {
            //    this.selected = false;
            //});
        }
    }
}