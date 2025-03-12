import { ServiceAjax } from "../services/_serviceAjax.js"
import { ServiceElement } from "../services/_serviceElement.js"
const serviceAjax = new ServiceAjax();
const serviceElement = new ServiceElement();
const productData = () => {
    return {
        name: $("#inpProductName").val(),
        price: $("#inpProductPrice").val(),
        category: $("#sltCategory option:selected").val()
    }
}
$(document).ready(async () => {
    await GetProducts();
    await GetProductsByDate("20250310");
    await serviceElement.selector.Initial("#sltCategory");
    $("#btnAddProduct").on("click", () => {
        var data = productData();
        console.log(data);
    });
})

async function GetProducts() {
    await serviceAjax.GetAsync({
        url: "/Product/GetAll",
    }).then(async (res) => {

    }).catch(async (err) => {
        console.log(err)
    })
}
async function GetProductsByDate(date) {
    await serviceAjax.GetAsync({
        url: "/Product/GetAllById",
        data: { date: date }
    }).then(async (res) => {

    }).catch(async (err) => {
        console.log(err)
    })
}
async function GetProductById(id) {
    await serviceAjax.GetAsync({
        url: "/Product/GetById",
        data: { id: id }
    }).then(async (res) => {

    }).catch(async (err) => {
        console.log(err)
    })
}
async function AddProduct() {
    await serviceAjax.GetAsync({
        url: "/Product/GetById",
        data: { id: id }
    }).then(async (res) => {

    }).catch(async (err) => {
        console.log(err)
    })
}
async function UpdateProductById(id, data) {
    await serviceAjax.PutAsync({
        url: `/Product/Update/${id}`,
        data: data
    }).then(async (res) => {

    }).catch(async (err) => {

    });
    
}
async function DeleteProductById(id) {
    await serviceAjax.DeleteAsync({
        url: `/Product/Delete/${id}`,
    }).then(async (res) => {

    }).catch(async (err) => {
        console.log(err)
    });
}