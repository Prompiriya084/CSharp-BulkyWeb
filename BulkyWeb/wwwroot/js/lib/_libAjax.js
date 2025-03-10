

export class LibAjax {
    //#url
    #ajaxHeader //private
    constructor() {
        //this.#url = (window.location.host.includes("localhost")) ? "/api" : "/TestSystem/api";
        this.#ajaxHeader = {
            RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        };
    }
    async GetAsync({ url = null, data = null }) {
        return await
            $.ajax({
                type: "Get",
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                headers: this.#ajaxHeader,
                data: data,
                success: function (result) {
                    //response(result);
                },
                error: function (result) {
                    //console.log(res);
                    //reject(result)
                }
            });

    }
    async PostAsync({ url = null, data = null }) {
        return await $.ajax({
            type: "Post",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: this.#ajaxHeader,
            data: (JSON.stringify(data)),
            success: function (result) {
                //response(result);
            },
            error: function (result) {
                //reject(result);
                //console.log(result);
            }
        });
    }
    async PutAsync({ url = null, data = null }) {
        //return await new Promise((response, reject) => {
        //    $.ajax({
        //        type: "Put",
        //        url: url,
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        headers: this.#ajaxHeader,
        //        data: (JSON.stringify(data)),
        //        success: function (result) {
        //            response(result);
        //        },
        //        error: function (result) {
        //            reject(result);
        //        }
        //    });
        //});
        return await $.ajax({
            type: "Put",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: this.#ajaxHeader,
            data: (JSON.stringify(data)),
            success: function (result) {
                //response(result);
            },
            error: function (result) {
                //reject(result);
            }
        });
    }
    async DeleteAsync({ url = null }) {
        return await $.ajax({
            type: "Delete",
            url: url + `/${data}`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            headers: this.#ajaxHeader,
            success: function (result) {
                //response(result);
            },
            error: function (result) {
                //reject(result);
            }
        });
    }
    async PostFormAsync({ url = null, formdata = null }) {
        return await $.ajax({
            method: "Post",
            url: url,
            processData: false,
            contentType: false,
            cache: false,
            headers: this.#ajaxHeader,
            data: formdata,
            dataType: "json",
            enctype: 'multipart/form-data',
            success: function (result) {
                //response(result);
            },
            error: function (result) {
                //reject(result);
            }
        });
    }
}
//export const _libAjax = new LabAjax();