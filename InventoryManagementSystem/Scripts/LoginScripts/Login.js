function UserLogin() {
    var valid = true;
    var Email = document.getElementById("emailaddress").value;
    var Password = document.getElementById("password").value;
    if (Email == "") {
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
            var LoginViewModel = {
                EmailAddress: Email,
                Password: Password,
                RememberLogin: true,
            };

            $.ajax({
                type: 'POST',
                url: "/Account/Login",
                data: { LoginViewModel: LoginViewModel },
                success: function (response) {
                    if (response == "User Found") {
                        var url = "/Home/Dashboard";
                        window.location.href = url;

                    }
                    else if (response == "IncorrectPassword") {
                        iziToast.warning({
                            title: 'Incorrect Password',
                            message: 'Password Is Incorrect, Please try again',
                            position: 'topRight'
                        });
                    }
                    else {
                        iziToast.warning({
                            title: 'User Does Not Exist',
                            message: 'Please click the register link and create an account',
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