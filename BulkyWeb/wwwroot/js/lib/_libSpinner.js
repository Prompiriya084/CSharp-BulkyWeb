export class Spinner {
    constructor() {
        this.spinner = document.querySelector(".loader");
    }
    Innitial() {
        window.addEventListener("load", () => {
            this.spinner.classList.add("loader-hidden");
        });
    }
    Show() {
        this.spinner.classList.remove("loader-hidden");
    }
    Hide() {
        this.spinner.classList.add("loader-hidden");
    }
}
export class MiniSpinner {
    constructor(locationQuery = null) {
        this.locationQuery = locationQuery;
        this.spinner = $('.miniSpinner');
    }
    Show(locationQuery = null) {
        if (locationQuery != null) {
            //console.log($(locationQuery));
            var str = "<div class='miniSpinner text-danger d-flex justify-content-center'>";
            str += "<div class='spinner-border' role='status'>";
            str += "<span class='visually-hidden'>Loading...</span>";
            str += "</div>"
            str += "</div>"
            $(locationQuery).prepend(str);
        }
    }
    Hide(locationQuery = null) {
        if (locationQuery != null) {
            $(locationQuery + ' .miniSpinner').remove();
        }
        else {
            //console.log(this.spinner);
            $('.miniSpinner').remove();
        }
    }
}
//export const _libMiniSpinner = new MiniSpinner();
//export const _libSpinner = new Spinner();
//_spinner.Innitial();