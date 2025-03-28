﻿import { ServiceAjax } from "../services/_serviceAjax.js"
import { SweetAlert } from "../lib/_libAlert.js"
const serviceAjax = new ServiceAjax();
const libSweetAlert = new SweetAlert();
$(document).ready(async () => {
    $("button[type=submit]").on("click", async () => {
        let email = $("#inpEmail").val();
        let password = $("#inpPassword").val()
        serviceAjax.PostAsync({
            url: "/identity/signin",
            data: {
                email: email,
                password: password
            }
        }).then(async (res) => {
            libSweetAlert.Initial({
                icon: "success",
                title: "Sucess",
            });
        }).catch(async (err) => {
            libSweetAlert.Initial({
                icon: err.responseJSON.title,
                title: err.responseJSON.statusText,
                text: err.responseJSON.message
            });

        })
    });
});