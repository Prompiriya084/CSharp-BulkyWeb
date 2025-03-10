import { ServiceAjax } from "../services/_serviceAjax.js"
const serviceAjax = new ServiceAjax();
$(document).ready(async () => {
    $("button[type=submit]").on("click", async () => {
        console.log("submit!!!!");
        serviceAjax.PostAsync({
            url: "/identity/signin",
            data: {
                email: $("#inpEmail").val(),
                password: $("#inpPassowrd").val()
            }
        }).then(async (res) => {
            console.log(res);
        }).catch(async (err) => {
            console.log(err);
        })
    });
});