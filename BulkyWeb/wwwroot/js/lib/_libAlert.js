export class SweetAlert {
    constructor() {

    }
    Initial = function ({ icon = null,
        title = null,
        text = null,
        html = null,
        position = 'center',
        showConfirmButton = true,
        reload = false,
        redirect = null }) {

        swal.fire({
            icon: icon,
            position: position,
            title: title,
            text: (text != null) ? text : "",
            html: html,
            showConfirmButton: showConfirmButton,
            timer: 3500,
            timerProgressBar: true,
        }).then(function () {
            if (reload) {
                window.location.reload();
            }
            else if (redirect != null) {
                window.location.href = "../" + redirect;
            }
        });
    }
    Confirm = async function ({ icon = null, title = null, text = null, html = null, redirect = null }) {
        //var result = false;
        return await swal.fire({
            icon: 'question',
            title: title,
            text: (text != null) ? text : "",
            html: (html != null) ? html : "",
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes',
            cancelButtonText: 'No',
        }).then(function (result) {
            return result.value;
        });
    }
}
export class ToastAlert {
    constructor() {
    }
    Initial = async function ({
        icon = null,
        title = null,
        reload = false,
        redirect = null,
        customClass = false
    }) {
        const Toast = Swal.mixin({
            toast: true,
            width: 400,
            position: "top-end",
            iconColor: (!customClass) ? customClass : 'white',
            showConfirmButton: false,
            timer: 4000,
            timerProgressBar: true,
            customClass: (!customClass) ? customClass : {
                popup: 'colored-toast',
            },
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        })
        Toast.fire({
            icon: icon,
            title: title,
        }).then(() => {
            if (reload) {
                window.location.reload();
            }
            else if (redirect != null) {
                window.location.href = "../" + redirect;
            }
        });
    }
}
//export const _libSweetAlert = new SweetAlert();
//export const _libToastAlert = new ToastAlert();