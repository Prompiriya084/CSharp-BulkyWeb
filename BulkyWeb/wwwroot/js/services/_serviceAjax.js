﻿import { SweetAlert } from "../lib/_libAlert.js"
import { Spinner } from "../lib/_libSpinner.js"
import { LibAjax } from "../lib/_libAjax.js"

export class ServiceAjax {
    #url
    #redirectUrl
    #libAjax
    #sweetAlert
    #spinner
    constructor() {
        this.#url = (window.location.host.includes("localhost")) ? "/api" : "/TestSystem/api";
        this.#redirectUrl = "identity/signin";
        this.#libAjax = new LibAjax();
        this.#sweetAlert = new SweetAlert();
        this.#spinner = new Spinner();
    }
    GetDefaultUrl() {
        return this.#url;
    }
    #GetErrorResponse(err) {
        var errorResponse;
        var errorMessage = "";
        if (err.responseJSON !== undefined) {
            //error message from mapping data to model
            if (err.responseJSON.errors !== undefined || err.responseJSON.message === undefined) {
                for (var key in err.responseJSON.errors) {
                    errorMessage += err.responseJSON.errors[key][0];
                }
            }
            else {
                errorMessage = err.responseJSON.message //error message from manual sending 
            }
        }
        else {
            errorMessage = err.responseText // internal server eror
        }
        errorResponse = {
            responseJSON: {
                message: errorMessage,
                statusText: err.statusText,
                status: err.status,
                title: (err.status == 400) ? "warning" : "error"
            }
        }
        return errorResponse;
    }
    async GetAsync({ url = null, data = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        return await new Promise((response, reject) => {
            this.#libAjax.GetAsync({
                url: this.#url + url,
                data: data,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Initial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: this.#redirectUrl
                    });
                }
                else {
                    var errorResponse;
                    errorResponse = this.#GetErrorResponse(err);
                    reject(errorResponse);
                }
            });
        });
    }
    async PostAsync({ url = null, data = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        return await new Promise((response, reject) => {
            this.#libAjax.PostAsync({
                url: this.#url + url,
                data: data,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Initial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: this.#redirectUrl
                    });
                }                
                else {
                    var errorResponse;
                    errorResponse = this.#GetErrorResponse(err);
                    reject(errorResponse);
                }
            });
        });
    }
    async PutAsync({ url = null, data = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        return await new Promise((response, reject) => {
            this.#libAjax.PutAsync({
                url: this.#url + url,
                data: data,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Initial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: this.#redirectUrl
                    });                    
                }
                else {
                    var errorResponse;
                    errorResponse = this.#GetErrorResponse(err);
                    reject(errorResponse);
                }
            });
        });
    }
    async DeleteAsync({ url = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        return await new Promise((response, reject) => {
            this.#libAjax.DeleteAsync({
                url: this.#url + url,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Initial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: this.#redirectUrl
                    });
                }
                else {
                    var errorResponse;
                    errorResponse = this.#GetErrorResponse(err);
                    reject(errorResponse);
                }
            });
        });
    }
    async PostFormAsync({ url = null, formdata = null, spinner = false }) {
        if (spinner) this.#spinner.Show();
        return await new Promise((response, reject) => {
            this.#libAjax.PostFormAsync({
                url: this.#url + url,
                formdata: formdata,
            }).then(async (res) => {
                response(res)
            }).catch(async (err) => {
                if (spinner) this.#spinner.Hide();
                if (err.status == 401) {
                    this.#sweetAlert.Initial({
                        icon: 'error',
                        title: 'Authentication fail',
                        text: "Cookies has expired. Please login again.",
                        redirect: this.#redirectUrl
                    });
                    
                }
                else {
                    var errorResponse;
                    errorResponse = this.#GetErrorResponse(err);
                    reject(errorResponse);
                }
            });
        });
    }
}