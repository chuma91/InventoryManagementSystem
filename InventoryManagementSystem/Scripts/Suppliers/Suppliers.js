//function isNumberKey(evt) {
//    var charCode = (evt.which) ? evt.which : event.keyCode
//    if (charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
//        return false;

//    return true;
//}

// removing a category from the list
function removeSupplier(Id) {

    $.ajax({
        type: 'POST',
        url: '/Suppliers/RemoveSupplier',
        data: {
            Id: Id
        },
        success: function (response) {
            if (response == true) {
                Swal.fire({
                    title: "Supplier Removed",
                    text: "Supplier Removed Successfully.",
                    icon: "success",
                    cancelButtonText: "Close",
                    cancelButtonColor: '#d33'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var url = "/Suppliers/GetAllSuppliers";
                        window.location.href = url;
                    }
                });
            }
            else {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to remove supplier, please try again",
                    icon: 'error'
                })
            }

        },
        error: function (ex) {
            Swal.fire({
                title: "Failed",
                text: "Failed to remove supplier, please try again",
                icon: 'error'
            })
        }
    });
}


function UpdateSupplier(Id) {
    var valid = true;

    var SupplierName = document.getElementById("SupplierName").value;
    var SupplierEmail = document.getElementById("SupplierEmail").value;
    var SupplierTelephoneNumber = document.getElementById("SupplierTelephoneNumber").value;

    if (SupplierName == "") {
        iziToast.warning({
            title: 'Supplier Name Empty',
            message: 'Please Enter Supplier Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (SupplierEmail == "") {
        iziToast.warning({
            title: 'Supplier Email Empty',
            message: 'Supplier Email Name',
            position: 'topRight'
        });
        valid = false;
    };


    var SupplierViewModel = {
        SupplierID: Id,
        SupplierName: SupplierName,
        SuppplierEmail: SupplierEmail,
        TelephoneNumber: SupplierTelephoneNumber,

    };
    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Suppliers/EditSupplier',
            data: {
                SupplierViewModel: SupplierViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Supplier Updated",
                        text: "Supplier Updated Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Suppliers/GetAllSuppliers";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to update supplier, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to update supplier, please try again",
                    icon: 'error'
                })
            }
        });
    }

}


function AddSupplier() {
    var valid = true;


    var SupplierName = document.getElementById("Supplier_Name").value;
    var SupplierEmail = document.getElementById("Supplier_Email").value;
    var SupplierTelephoneNumber = document.getElementById("Supplier_Telephone_Number").value;
   

    if (SupplierName == "") {
        iziToast.warning({
            title: 'Supplier Name Empty',
            message: 'Please Enter Supplier Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (SupplierEmail == "") {
        iziToast.warning({
            title: 'Supplier Email Empty',
            message: 'Supplier Email Name',
            position: 'topRight'
        });
        valid = false;
    };
  

    var SupplierViewModel = {
        SupplierName: SupplierName,
        SuppplierEmail: SupplierEmail,
        TelephoneNumber: SupplierTelephoneNumber,
       
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Suppliers/AddSupplier',
            data: {
                SupplierViewModel: SupplierViewModel
            },
            success: function (response) {
                if (response == true) {
                    alert("Its Hitting");
                    Swal.fire({
                        title: "Supplier Created",
                        text: "Supplier Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Suppliers/GetAllSuppliers";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to create supplier, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to create supplier, please try again",
                    icon: 'error'
                })
            }
        });
    }

}