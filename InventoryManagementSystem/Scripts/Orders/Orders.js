


function AddOrder() {
    var valid = true;


    var ProductName = document.getElementById("ProductName").value;
    var Customer_ID = document.getElementById("Customer_ID").value;
    var Supplier_ID = document.getElementById("Supplier_ID").value;
    var Category_ID = document.getElementById("Category_ID").value;
    var PaymentRecieved = document.getElementById("PaymentRecieved").value;
    var DateSold = document.getElementById("DateSold").value;

    if (ProductName == "") {
        iziToast.warning({
            title: ' Product Name Empty',
            message: 'Please Enter product Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if ($("#Customer_ID").find(':selected').text() == "Select Customer") {
        iziToast.warning({
            title: 'Warning!',
            message: 'Please Select Customer !',
            position: 'topRight'
        });
        return false;
    }
    else if ($("#Supplier_ID").find(':selected').text() == "Select Supplier") {
        iziToast.warning({
            title: 'Warning!',
            message: 'Please Select Supplier !',
            position: 'topRight'
        });
        return false;
    }
    else if ($("#Category_ID").find(':selected').text() == "Select Category") {
        iziToast.warning({
            title: 'Warning!',
            message: 'Please Select Category !',
            position: 'topRight'
        });
        return false;
    }
    else if (PaymentRecieved == "") {
        iziToast.warning({
            title: 'Warning',
            message: 'Please Select Payment Received',
            position: 'topRight'
        });
        valid = false;
    }
    else if (DateSold == "") {
        iziToast.warning({
            title: 'Warning',
            message: 'Please Enter Sold Date',
            position: 'topRight'
        });
        valid = false;
    }

    var OrdersViewModel = {
        ProductName: ProductName,
        CustomerID: Customer_ID,
        SupplierID: Supplier_ID,
        CategoryID: Category_ID,
        DateSold: DateSold,
        PaymentRecieved:PaymentRecieved
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Orders/AddOrder',
            data: {
                OrdersViewModel: OrdersViewModel
            },
            success: function (response) {
                if (response == true) {
                    alert("Its Hitting");
                    Swal.fire({
                        title: "Order Created",
                        text: "Order Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Orders/GetAllOrders";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to create order, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to create order, please try again",
                    icon: 'error'
                })
            }
        });
    }

}