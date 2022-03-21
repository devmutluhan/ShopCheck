var th = `<tr>
                    <th style="width: 35%;">Müşteri Bilgileri</th>
                    <th style="width: 35%;">Ürün Adı</th>
                    <th style="width: 10%;">Taksit Türü</th>
                    <th style="width: 10%;">Toplam Fiyat</th>
                    <th style="width: 10%"> </th>
                </tr>`
var buttons = {
    deleteBtn: `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
    <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
    </svg>`,
    updateBtn: `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-clockwise" viewBox="0 0 16 16">
        <path fill-rule="evenodd" d="M8 3a5 5 0 1 0 4.546 2.914.5.5 0 0 1 .908-.417A6 6 0 1 1 8 2v1z" />
        <path d="M8 4.466V.534a.25.25 0 0 1 .41-.192l2.36 1.966c.12.1.12.284 0 .384L8.41 4.658A.25.25 0 0 1 8 4.466z" />
        </svg>`
}
var button = document.getElementById("addButton")

getProduct()
getInstallment()
getItems()

//Sayfa açıldığında liste çağırılır. GET
function getItems() {
    var table = document.querySelector(".list");
    fetch("https://localhost:5000/api/sales")
        .then(response => response.json())
        .then(sales => {
            table.innerHTML = th
            for (var i in sales) {
                table.innerHTML += `<tr>
                           <td> ${sales[i].name + " " + sales[i].surName + " " + sales[i].phone}</td>
                           <td> ${sales[i].productName}</td>
                           <td> ${sales[i].type}</td>
                           <td> ${sales[i].price + " "} ₺ </td>
                           <td> <span class="btn" onclick="deleteData(${sales[i].salesId})">${buttons.deleteBtn}</span>
                                <span class="btn" onclick="updateData(${sales[i].salesId})">${buttons.updateBtn}</span>
                           </td>
                        </tr>`
                i++
            }
        })
}

//Satışlardaki güncellemeleri yapar. UPDATE
function updateData(id) {
    button.innerHTML = "Düzenle"
    if (button.innerHTML == "Düzenle") {
        button.addEventListener("click", function () {
            var data = readData();
            fetch(`https://localhost:5000/api/sales/${id}`, {
                method: 'PUT',
                body: JSON.stringify({
                    "customerId": queryString().slice(queryString().search("=") + 1),
                    "productId": data.ProductId,
                    "installmentId": data.InstallmentId,
                    "salesDate": data.SalesDate
                }),
                redirect: 'follow',
                headers: { "Content-type": "application/json; charset=UTF-8" }
            }).then(res => {
                getItems();
                id = 1;
                button.innerHTML = "Ekle"
                resetData();
            })
        })
    }
}

//Sayfadaki text inputları okur ve data isimli bir object döner.
function readData() {
    var data = {};
    data["ProductId"] = document.getElementById("urunSec").options[document.getElementById("urunSec").selectedIndex].id;
    data["InstallmentId"] = document.getElementById("taksitSec").options[document.getElementById("taksitSec").selectedIndex].id;
    data["SalesDate"] = document.getElementById("salesDate").value;
    return data;
}

//Sayfadaki text inputları sıfırlar
function resetData() {
    document.getElementById("urunSec").selectedIndex = 0
    document.getElementById("taksitSec").selectedIndex = 0
}

//Db den veri silme DELETE
function deleteData(id) {
    fetch(`https://localhost:5000/api/sales/${id}`, {
        method: 'DELETE'
    })
        .then(res => { getItems(); })
}

//Db ye veri ekleme yapılır ve sonunda liste çağırılır. POST
button.addEventListener("click", function () {
    if (button.innerHTML == "Ekle") {
        var Id = queryString().slice(queryString().search("=") + 1);
        if (Id == "") {
            alert("Müşteri girişi yapılmadı.")
        }
        else {
            var input = readData()
            var data = JSON.stringify({
                "customerId": Id,
                "productId": input.ProductId,
                "installmentId": input.InstallmentId,
                "salesDate": input.SalesDate
            });

            fetch("https://localhost:5000/api/sales", {
                method: 'POST',
                body: data,
                headers: { "Content-type": "application/json; charset=UTF-8" }
            }).then(res => { getItems(); resetData(); })
        }
    }
})

//Urlde bulunan CustomerId yi almamızı sağlar. 
function queryString() {
    var qs = location.search.substring(1, location.search.length).replace(/(%20|\+)/g, " ");
    if (arguments.length == 0 || qs == "") return qs; else qs = "&" + qs + "&";
    return qs.substring(qs.indexOf("=", qs.indexOf("&" + arguments[0] + "=") + 1) + 1, qs.indexOf("&", qs.indexOf("&" + arguments[0] + "=") + 1));
}

//Ürünleri, ürün seçiniz inputuna listeler
function getProduct() {
    var uruns = document.getElementById("urunSec");
    fetch("https://localhost:5000/api/product")
        .then(response => response.json())
        .then(data => {
            for (product of data) {
                uruns.innerHTML += `<option id="${product.productId}" > ${product.productName} </option> `
            }
        })
}

//Taksit seçeneklerini, taksit seçeneği seçiniz inputuna listeler
function getInstallment() {
    var taksit = document.getElementById("taksitSec");
    fetch("https://localhost:5000/api/installment")
        .then(response => response.json())
        .then(data => {
            for (installment of data) {
                taksit.innerHTML += `<option id="${installment.installmentId}"> ${installment.type} </option> `
            }
        })
}
