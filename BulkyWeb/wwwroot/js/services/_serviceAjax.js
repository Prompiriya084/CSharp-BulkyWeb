import { SweetAlert } from "../lib/_libAlert.js"
import { Spinner } from "../lib/_libSpinner.js"
import { LibAjax } from "../lib/_libAjax.js"

export class ServiceAjax {
    #url
    #libAjax
    #sweetAlert
    #spinner
    constructor() {
        this.#url = (window.location.host.includes("localhost")) ? "/api" : "/TestSystem/api";
        this.#libAjax = new LibAjax();
        this.#sweetAlert = new SweetAlert();
        this.#spinner = new Spinner();
    }
    GetDefaultUrl() {
        return this.#url;
    }
    async GetAsync({ url = null, data = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        //console.log(this.ajaxUrl + url);
        return await new Promise((response, reject) => {
            this.#libAjax.GetAsync({
                url: this.#url + url,
                data: data,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Innitial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: "Identity/login"
                    });
                }
                else {
                    if (err.responseJSON.errors !== undefined || err.responseJSON.message === undefined) {
                        var errorMessage = "";
                        for (var key in err.responseJSON.errors) {
                            errorMessage += result.responseJSON.errors[key][0];
                        }
                        var errorResponse = {
                            responseJSON: {
                                message: errorMessage,
                                statusText: err.statusText,
                                title: (err.status == 400) ? "warning" : "error"
                            }
                        }
                        reject(errorResponse);
                    }
                    else {
                        reject(err);
                    }
                }
            });
        });
    }
    async PostAsync({ url = null, data = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        //console.log(this.ajaxUrl + url);
        return await new Promise((response, reject) => {
            this.#libAjax.PostAsync({
                url: this.#url + url,
                data: data,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Innitial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: "Identity/login"
                    });
                    //oAlertNoLoading('error', res.statusText, "Cookies has expied. Please login again.", 'Identity/login');
                }
                
                else {
                    
                    if (err.responseText !== undefined) {
                        reject(err);
                    }
                    else if (err.responseJSON.errors !== undefined || err.responseJSON.message === undefined) {
                        var errorMessage = "";
                        for (var key in err.responseJSON.errors) {
                            errorMessage += result.responseJSON.errors[key][0];
                        }
                        var errorResponse = {
                            responseJSON: {
                                message: errorMessage,
                                statusText: err.statusText,
                                title: (err.status == 400) ? "warning" : "error"
                            }
                        }
                        reject(errorResponse);
                    }
                    else {
                        reject(err);
                    }
                    reject(err);
                }
            });
        });
    }
    async PutAsync({ url = null, data = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        //console.log(this.ajaxUrl + url);
        return await new Promise((response, reject) => {
            this.#libAjax.PutAsync({
                url: this.#url + url,
                data: data,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Innitial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: "Identity/login"
                    });
                    //oAlertNoLoading('error', res.statusText, "Cookies has expied. Please login again.", 'Identity/login');
                }
                else {
                    if (err.responseJSON.errors !== undefined || err.responseJSON.message === undefined) {
                        var errorMessage = "";
                        for (var key in err.responseJSON.errors) {
                            errorMessage += result.responseJSON.errors[key][0];
                        }
                        var errorResponse = {
                            responseJSON: {
                                message: errorMessage,
                                statusText: err.statusText,
                                title: (err.status == 400) ? "warning" : "error"
                            }
                        }
                        reject(errorResponse);
                    }
                    else {
                        reject(err);
                    }
                }
            });
        });
    }
    async DeleteAsync({ url = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        //console.log(this.ajaxUrl + url);
        return await new Promise((response, reject) => {
            this.#libAjax.DeleteAsync({
                url: this.#url + url,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Innitial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: "Identity/login"
                    });
                    //oAlertNoLoading('error', res.statusText, "Cookies has expied. Please login again.", 'Identity/login');
                }
                else {
                    if (err.responseJSON.errors !== undefined || err.responseJSON.message === undefined) {
                        var errorMessage = "";
                        for (var key in err.responseJSON.errors) {
                            errorMessage += result.responseJSON.errors[key][0];
                        }
                        var errorResponse = {
                            responseJSON: {
                                message: errorMessage,
                                statusText: err.statusText,
                                title: (err.status == 400) ? "warning" : "error"
                            }
                        }
                        reject(errorResponse);
                    }
                    else {
                        reject(err);
                    }
                }
            });
        });
    }
    async PostFormAsync({ url = null, formdata = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        //console.log(this.ajaxUrl + url);
        return await new Promise((response, reject) => {
            this.#libAjax.PostFormAsync({
                url: this.#url + url,
                formdata: formdata,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Innitial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: "Identity/login"
                    });
                    //oAlertNoLoading('error', res.statusText, "Cookies has expied. Please login again.", 'Identity/login');
                }
                else {
                    if (err.responseJSON.errors !== undefined || err.responseJSON.message === undefined) {
                        var errorMessage = "";
                        for (var key in err.responseJSON.errors) {
                            errorMessage += result.responseJSON.errors[key][0];
                        }
                        var errorResponse = {
                            responseJSON: {
                                message: errorMessage,
                                statusText: err.statusText,
                                title: (err.status == 400) ? "warning" : "error"
                            }
                        }
                        reject(errorResponse);
                    }
                    else {
                        reject(err);
                    }
                }
            });
        });
    }

}