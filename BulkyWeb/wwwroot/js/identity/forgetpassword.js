import { ServiceAjax } from "../services/_serviceAjax.js";
import { SweetAlert } from "../lib/_libAlert.js";
const _serviceAjax = new ServiceAjax();
const _libSweetAlert = new SweetAlert();
$(document).ready(async () => {

    $("button[type=submit]").on("click", async () => {
        let email = $("#inpEmail").val();
        await _serviceAjax.PostAsync({
            url: "/identity/forgetpassword",
            data: email
        }).then(async (res) => {
            console.log(res);
            _libSweetAlert.Initial({
                icon: "success",
                title: "Sucess",
            });
        }).catch(async (err) => {
            console.log(err);
            _libSweetAlert.Initial({
                icon: err.responseJSON.title,
                title: err.responseJSON.statusText,
                text: err.responseJSON.message
            });
        })
    });
});