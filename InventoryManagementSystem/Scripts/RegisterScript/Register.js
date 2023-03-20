
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function checkPhoneNumber() {
    var Phone = document.getElementById('phonenumber');
    if (Phone.value.length != 10) {
        iziToast.warning({
            title: 'Error',
            message: "Invalid Phone Number!",
            position: 'topRight'
        });
    }
}

function RegisterUser() {
    var valid = true;

    var Email = document.getElementById("emailaddress").value;
    var Password = document.getElementById("password").value;
    var FirstName = document.getElementById("firstname").value;
    var LastName = document.getElementById("lastname").value;
    var PhoneNumber = document.getElementById("phonenumber").value;
    var UserRoleId = document.getElementById("RoleId").value;

     if (FirstName == "") {
        valid = false;
        iziToast.warning({
            title: 'FirstName Empty',
            message: 'Please Enter Your First Name',
            position: 'topRight'
        });
    }
    else if (LastName == "") {
        valid = false;
        iziToast.warning({
            title: 'LastName Empty',
            message: 'Please Enter Your Last Name',
            position: 'topRight'
        });
     }
     else if (PhoneNumber == "") {
         valid = false;
         iziToast.warning({
             title: 'Phone Number Empty',
             message: 'Please Enter Your Phone Number',
             position: 'topRight'
         });
     }

     else if ($("#UserRoleId").find(':selected').text() == "Select Role") {
         iziToast.warning({
             title: 'Warning!',
             message: 'Please Select Role !',
             position: 'topRight'
         });
         return false;
     }
    else if (Email == "") {
        valid = false;
        iziToast.warning({
            title: 'Email Address Empty',
            message: 'Please Enter Your Email Address',
            position: 'topRight'
        });
    }
    else if (Password == "") {
        valid = false;
        iziToast.warning({
            title: 'Password Empty',
            message: 'Please Enter Your Password',
            position: 'topRight'
        });
     }
  

    else {
        if (valid == true) {
            var RegisterViewModel = {
                FirstName: FirstName,
                LastName: LastName,
                RoleId: document.getElementById("RoleId").value,
                EmailAddress: Email,
                Password: Password,
                PhoneNumber: PhoneNumber,
              
            };

            $.ajax({
                type: 'POST',
                url: "/Account/Register",
                data: { RegisterViewModel: RegisterViewModel },
                success: function (response) {
                    if (response == "User Registered") {
                        Swal.fire({
                            title: "User Registered",
                            text: "User Registered Successfully.",
                            icon: "success",
                            cancelButtonText: "Close",
                            cancelButtonColor: '#d33'
                        }).then((result) => {
                            if (result.isConfirmed) {

                                var url = "/Home/Dashboard";
                                window.location.href = url;
                            }
                        });
                       

                    }
                    else if (response == "User Exist") {
                        iziToast.warning({
                            title: 'User Exist',
                            message: 'User already exist, please enter a different email address',
                            position: 'topRight'
                        });
                    }
                    else {
                        iziToast.warning({
                            title: 'Error',
                            message: 'Please try again',
                            position: 'topRight'
                        });
                    }
                },
                error: function (ex) {
                    iziToast.warning({
                        title: 'Error',
                        message: 'Please try again',
                        position: 'topRight'
                    });
                }
            });
        }
    }

}