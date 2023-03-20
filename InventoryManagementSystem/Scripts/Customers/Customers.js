
function UpdateCustomer(Id) {
    var valid = true;
    
    var CustomerName = document.getElementById("CustomerName").value;
    var CustomerEmail = document.getElementById("CustomerEmail").value;
    var CustomerTelephoneNumber = document.getElementById("CustomerTelephoneNumber").value;
    var CustomerAddress = document.getElementById("CustomerAdress").value;

    if (CustomerName == "") {
        iziToast.warning({
            title: 'Customer Name Empty',
            message: 'Please Enter Customer Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (CustomerEmail == "") {
        iziToast.warning({
            title: 'Customer Email Empty',
            message: 'Customer Email Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (CustomerAddress == "") {
        iziToast.warning({
            title: 'Customer Address Empty',
            message: 'Customer Email Name',
            position: 'topRight'
        });
        valid = false;
    }

    else if (CustomerTelephoneNumber == "") {
        iziToast.warning({
            title: 'Customer Telephone Number Empty',
            message: 'Customer Email Name',
            position: 'topRight'
        });
        valid = false;
    };


    var CustomersViewModel = {
        CustomerID: Id,
        CustomerName: CustomerName,
        CustomerEmail: CustomerEmail,
        CustomerTelephoneNumber: CustomerTelephoneNumber,
        CustomerAddress: CustomerAddress,
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Customer/EditCustomer',
            data: {
                CustomersViewModel: CustomersViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Customer Updated",
                        text: "Customer Updated Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Customer/GetAllCustomers";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to update customer, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to update customer, please try again",
                    icon: 'error'
                })
            }
        });
    }

}
function AddCustomer() {
    var valid = true;


    var CustomerName = document.getElementById("CustomerName").value;
    var CustomerEmail = document.getElementById("CustomerEmail").value;
    var CustomerTelephoneNumber = document.getElementById("CustomerTelephoneNumber").value;
    var CustomerAddress = document.getElementById("CustomerAddress").value

    if (CustomerName == "") {
        iziToast.warning({
            title: 'Customer Name Empty',
            message: 'Please Enter Customer Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (CustomerTelephoneNumber == "") {
        iziToast.warning({
            title: 'Customer Telephone Number Empty',
            message: 'Customer Telephone Number',
            position: 'topRight'
        });
        valid = false;
    }

    else if (CustomerEmail == "") {
        iziToast.warning({
            title: 'Customer Email Empty',
            message: 'Customer Email Name',
            position: 'topRight'
        });
        valid = false;
    };


    var CustomersViewModel = {

        CustomerName: CustomerName,
        CustomerEmail: CustomerEmail,
        CustomerTelephoneNumber: CustomerTelephoneNumber,
        CustomerAddress: CustomerAddress,

    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Customer/AddCustomer',
            data: {
                CustomersViewModel: CustomersViewModel
            },
            success: function (response) {
                if (response == true) {

                    Swal.fire({
                        title: "Customer Created",
                        text: "Customer Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Customer/GetAllCustomers";
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

function RemoveCustomer(Id) {

    $.ajax({
        type: 'POST',
        url: '/Customer/RemoveCustomer',
        data: {
            Id: Id
        },
        success: function (response) {
            if (response == true) {
                Swal.fire({
                    title: "Customer Removed",
                    text: "Customer Removed Successfully.",
                    icon: "success",
                    cancelButtonText: "Close",
                    cancelButtonColor: '#d33'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var url = "/Customer/GetAllCustomers";
                        window.location.href = url;
                    }
                });
            }
            else {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to remove customer, please try again",
                    icon: 'error'
                })
            }

        },
        error: function (ex) {
            Swal.fire({
                title: "Failed",
                text: "Failed to remove customer, please try again",
                icon: 'error'
            })
        }
    });
}
