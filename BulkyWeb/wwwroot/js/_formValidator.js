(() => {
    'use strict'
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')
    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            //SubmitHandler
            event.preventDefault()
            event.stopPropagation()
            //if (form.checkValidity()) {
            //    var location = window.location;
            //    if (location.pathname.toLowerCase().includes("login")) {
            //        LoginSubmit();
            //    }
            //    else if (location.pathname.toLowerCase().includes("WorkCodeMaster")) {
            //        btnSubmit();
            //    }
            //}
            form.classList.add('was-validated')
        }, false)
    });
})()