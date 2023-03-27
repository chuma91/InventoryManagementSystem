function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumberKeyDecimal(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) {
        var inputValue = $("#inputfield").val()
        if (inputValue.indexOf('.') < 1) {
            return true;
        }
        return false;
    }
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

// removing a category from the list
function removeProduct(Id) {

    $.ajax({
        type: 'POST',
        url: '/Products/RemoveProduct',
        data: { 
            Id: Id
        },
        success: function (response) {
            if (response == true) {
                Swal.fire({
                    title: "Product Removed",
                    text: "Product Removed Successfully.",
                    icon: "success",
                    cancelButtonText: "Close",
                    cancelButtonColor: '#d33'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var url = "/Products/GetAllProducts";
                        window.location.href = url;
                    }
                });
            }
            else {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to remove product, please try again",
                    icon: 'error'
                })
            }

        },
        error: function (ex) {
            Swal.fire({
                title: "Failed",
                text: "Failed to remove product, please try again",
                icon: 'error'
            })
        }
    });
}


function UpdateProduct(Id) {
    var valid = true;
   
    var ProductStatus = document.getElementById("ProductStatus").value;
    
    if (ProductStatus == "") {
        iziToast.warning({
            title: 'ProductLocation Empty',
            message: 'Please Enter ProductStatus',
            position: 'topRight'
        });
        valid = false;
    }
   
    var ProductsViewModel = {
        ProductBarCode: Id,
        ProductStatus: ProductStatus,
       
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Products/EditProduct',
            data: {
                ProductsViewModel: ProductsViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Product Updated",
                        text: "Product Updated Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Products/GetAllProducts";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to update product, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to update product, please try again",
                    icon: 'error'
                })
            }
        });
    }

}


function AddProduct() {
    var valid = true;

    var ProductName = document.getElementById("ProductName").value;
    var SuppliersID = document.getElementById("Supplier_ID").value;
    var CategoryID = document.getElementById("Category_ID").value;
    var ProductStatus = document.getElementById("ProductStatus").value;
    var ProductLocation = document.getElementById("ProductLocation").value;
    var ProductWarranty = document.getElementById("ProductWarranty").value;
    var ProductDateCaptured = document.getElementById("ProductDateCaptured").value;
    


    if (ProductName == "") {
        iziToast.warning({
            title: 'Product Name Empty',
            message: 'Please Enter Product Name',
            position: 'topRight'
        });
        valid = false;
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
    else if (ProductStatus == "") {
        iziToast.warning({
            title: 'ProductStatus Empty',
            message: 'Please Enter QuantityPerUnit',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ProductLocation == "") {
        iziToast.warning({
            title: 'ProductLocation Empty',
            message: 'Please Enter ProductLocation',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ProductWarranty == "") {
        iziToast.warning({
            title: 'ProductWarranty Empty',
            message: 'Please Enter ProductWarranty',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ProductDateCaptured == "") {
        iziToast.warning({
            title: 'ProductDateCaptured Empty',
            message: 'Please Enter ProductDateCaptured',
            position: 'topRight'
        });
        valid = false;
    }
   

    var ProductsViewModel = {
        ProductName: ProductName,
        SuppliersID: SuppliersID,
        CategoryID: CategoryID,
        ProductStatus: ProductStatus,
        Location: ProductLocation,
        ProductWarranty: ProductWarranty,
        ProductDateCaptured: ProductDateCaptured,
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Products/AddProduct',
            data: {
                ProductsViewModel: ProductsViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Product Created",
                        text: "Product Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Products/GetAllProducts";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to create product, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to create product, please try again",
                    icon: 'error'
                })
            }
        });
    }

}

