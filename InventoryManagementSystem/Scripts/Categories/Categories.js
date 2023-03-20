// removing a category from the list
function removeCategory(Id) {

    $.ajax({
        type: 'POST',
        url: '/Categories/RemoveCategory',
        data: {
            Id: Id
        },
        success: function (response) {
            if (response == true) {
                Swal.fire({
                    title: "Category Removed",
                    text: "Category Removed Successfully.",
                    icon: "success",
                    cancelButtonText: "Close",
                    cancelButtonColor: '#d33'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var url = "/Categories/GetAllCategories";
                        window.location.href = url;
                    }
                });
            }
            else {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to remove category, please try again",
                    icon: 'error'
                })
            }
           
        },
        error: function (ex) {
            Swal.fire({
                title: "Failed",
                text: "Failed to remove category, please try again",
                icon: 'error'
            })
        }
    });
}


function UpdateCategory(Id) {
    var valid = true;

    var CategoryName = document.getElementById("CategoryName").value;
    var Description = document.getElementById("Description").value;
    if (CategoryName == "") {
        iziToast.warning({
            title: 'Category Name Empty',
            message: 'Please Enter Category Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (Description == "") {        
        iziToast.warning({
            title: 'Description Empty',
            message: 'Please Enter Description',
            position: 'topRight'
        });
        valid = false;
    }

    var CategoriesViewModel = {
        CategoryID: Id,
        CategoryName: document.getElementById("CategoryName").value,
        Description: document.getElementById("Description").value,
    };
    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Categories/EditCategory',
            data: {
                CategoriesViewModel: CategoriesViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Category Updated",
                        text: "Category Updated Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Categories/GetAllCategories";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to update category, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to update category, please try again",
                    icon: 'error'
                })
            }
        });
    }
    
}


function AddCategory() {
    var valid = true;

    var CategoryName = document.getElementById("CategoryName").value;
    var Description = document.getElementById("Description").value;
    if (CategoryName == "") {
        iziToast.warning({
            title: 'Category Name Empty',
            message: 'Please Enter Category Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (Description == "") {
        iziToast.warning({
            title: 'Description Empty',
            message: 'Please Enter Description',
            position: 'topRight'
        });
        valid = false;
    }
    var CategoriesViewModel = {
        CategoryName: document.getElementById("CategoryName").value,
        Description: document.getElementById("Description").value,
    };
    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Categories/AddCategory',
            data: {
                CategoriesViewModel: CategoriesViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Category Created",
                        text: "Category Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Categories/GetAllCategories";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to create category, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to create category, please try again",
                    icon: 'error'
                })
            }
        });
    }
    
}