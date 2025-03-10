window.addEventListener("load", () => {
    const loader = document.querySelector(".loader");
    loader.classList.add("loader-hidden");
    //const preloader = document.querySelector(".preloader");
    //preloader.classList.add("preloader-hidden");
});
//$(document).ready(function () {
//    //$('input[type=date]').datepicker({ format: "dd/MM/yyyy" });
//    var path = window.location.href;
    
//    $('.sb-sidenav-menu-nested .nav-link').each(function () {
//        if (this.href === path) {
//            //console.log(this.href, path);
//            //$(this).css("color", "rgba(200, 0, 0, 0.68)");
//            $(this).toggleClass("active");
//            $(this).parent("nav").parent(".collapse").prev(".nav-link").toggleClass("active");
//            $(this).parent("nav").parent(".collapse").parent("nav").parent(".collapse").prev(".nav-link").toggleClass("active")
//            //console.log($(this).parent("nav").parent(".collapse").prev("a"));
//        }
//    });
//});

//async function logout() {
//    Swal.fire({
//        icon: "warning",
//        title: "Do you want to logout?",
//        text: "",
//        showCancelButton: true,
//        confirmButtonColor: "#3085d6",
//        cancelButtonColor: "#d33",
//        confirmButtonText: "Yes, logout!"
//    }).then(async function (result) {
//        //console.log(window.location.host.includes("localhost") ? "/Identity/logout" : "/JDM/Identity/logout");
//        if (result.isConfirmed) {
//            await _libAjax.PostAsync({
//                url: window.location.host.includes("localhost") ? "/Identity/logout" : "/JDM/Identity/logout", // /JDM/Identity/logout
//                //url: "/Identity/logout",
//                data: null
//            }).then(function (response) {
//                //console.log(response);
//                window.location.href = window.location.host.includes("localhost") ? "" : "/JDM" + response;
//            });
//        }
//    });
//}
