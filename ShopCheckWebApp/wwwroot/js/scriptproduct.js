var th = `<tr>
                    <th style="width: 3%;">Sıra</th>
                    <th style="width: 63%;">Ürün</th>
                    <th style="width: 14%;">Fiyat</th>
                    <th style="width: 10%;">Stok</th>
                    <th style="width: 10%"></th>
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

getItems()

//Sayfa açıldığında liste çağırılır. GET
function getItems() {
    var table = document.querySelector(".list");
    fetch("https://localhost:5000/api/product")
        .then(response => response.json())
        .then(product => {
            table.innerHTML = " "
            table.innerHTML = th
            for (var i in product) {
                table.innerHTML += `<tr>
                           <td> ${parseInt(i) + 1}</td>
                           <td> ${product[i].productName}</td>
                           <td> ${product[i].price}   ₺</td>
                           <td> ${product[i].stock}</td>
                           <td> <span class="btn" onclick="deleteData(${product[i].productId})" >${buttons.deleteBtn}</span>
                                 <span class="btn" onclick="onEdit(${product[i].productId})" >${buttons.updateBtn}</span>
                           </td>
                        </tr>`
                i++
            }
        })
    resetInput();
}

//Db ye veri ekleme yapılır ve sonunda liste çağırılır. POST
button.addEventListener("click", function () {
    var data = readInput()
    if (validate(data) == true && button.innerHTML == "Ekle") {
        fetch("https://localhost:5000/api/product", {
            method: 'POST',
            body: JSON.stringify({
                productName: data.productName,
                price: data.productPrice,
                stock: data.productStock
            }),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(res => { getItems(); })
    }
})

//Db den veri silme DELETE
function deleteData(id) {
    fetch(`https://localhost:5000/api/product/${id}`, {
        method: 'DELETE'
    })
        .then(res => { getItems(); })
}

//Db de verileri güncellememize yarar UPDATE
function updateData(id) {
    button.innerHTML = "Düzenle"
    if (button.innerHTML == "Düzenle") {
        button.addEventListener("click", function () {
            var datas = readInput()
            if (validate(datas) == true) {
                fetch(`https://localhost:5000/api/product/${id}`, {
                    method: 'PUT',
                    body: JSON.stringify({
                        "productName": datas.productName,
                        "price": datas.productPrice,
                        "stock": datas.productStock
                    }),
                    redirect: 'follow',
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(res => {
                    getItems()
                    id = 1
                    button.innerHTML = "Ekle"
                })
            }
        })
    }
}

//Sayfadaki text inputları okur ve data isimli bir object döner.
function readInput() {
    var data = {};
    data["productName"] = document.querySelector("#productName").value;
    data["productPrice"] = document.querySelector("#productPrice").value;
    data["productStock"] = document.querySelector("#productStock").value;
    return data;
}

//Sayfadaki text inputları silmemize yarar.
function resetInput() {
    document.getElementById("productName").value = "";
    document.getElementById("productPrice").value = "";
    document.getElementById("productStock").value = "";
}

//Düzenlenecek olan veriyi sayfadaki inputlara doldurur ve updateData yı çalıştırır
function onEdit(id) {
    fetch(`https://localhost:5000/api/product/${id}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(product => {
            document.getElementById("productName").value = product.productName
            document.getElementById("productPrice").value = product.price
            document.getElementById("productStock").value = product.stock
        })
    updateData(id)
}

//Sayfadaki inputlar doğru doldurulmuşmu diye kontrol eder.
function validate(tableData) {
    if (tableData.productName == "") { alert("İsim bilgisini giriniz!!"); return false }
    else if (tableData.productPrice == "") { alert("Fiyat bilgisini giriniz!!"); return false }
    else if (tableData.productStock == "") { alert("Stok bilgisini giriniz!!"); return false }
    else { return true }
}
