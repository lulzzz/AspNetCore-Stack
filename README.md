## Custom Role Based Authentication for Asp.Net Core 2.0 WebApi with EFCore 2 

Used Mysql as database, but you can use MsSql too. Token based authentication. Endpoints:

* `POST /Login` Send Username & Password as body, returns token string
* `POST /Register` Send Username & Password as body, returns token string
* `POST /ChangePassword` Send Password & OldPassword as body
