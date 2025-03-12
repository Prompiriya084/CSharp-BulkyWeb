export class ServiceForm {
    constructor() {
        this.file1 = $("#inpfile1").prop("files")[0];
        this.file2 = $("#inpfile2").prop("files")[0];
        this.file3 = $("#inpfile3").prop("files")[0];
    }
    GetFormData = async function () {
        var formData = new FormData();
        formData.append("file1", this.file1);
        formData.append("file2", this.file2);
        formData.append("file3", this.file3);

        return formData;
    }
}