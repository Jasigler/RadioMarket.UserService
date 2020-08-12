 <h3 align="center">RadioMarket User Service API</h3>

  <p align="center">
    User/Auth microservice for my e-commerce auction project. 
</p>

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contact](#contact)




<!-- ABOUT THE PROJECT -->
## About The Project

This is a very simple user/auth microservice for my larger radiomarket e-commerce auction project. It is very much in an MVP state, and should probably not be used in production.
In its current state, it can add/store basic user information (email, name, etc.), and a password hash via [NeoKushan's .Net Core port of BCrypt](https://github.com/neoKushan/BCrypt.Net-Core).
As the scope of this project grows, so to will this API.

### Built With

* ASP .NET Core 3.1
* Entity Framework Core
* Npgsql (EF Core extension)
* Postgres 12
* BCrypt


## Getting Started

Prior to setup, you will need the [.Net Core 3.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1) for your specific platform. .NET Core runtimes are currently available for Windows, OSX, Linux, and certain BSD distros. If you intend to deploy this to IIS, you will also need the hosting bundle (found on the same site).

In addition to .NET Core, you will need a local Postgres instance. These instructions assume that you will be creating a new docker container, but you can skip step 1 if you are using an existing container/instance. It may be helpful to install [pgAdmin](https://www.pgadmin.org/), the graphical manager for Postgres. 

If you are on windows 10, I highly recommend using the WSL2 docker engine as the overall performance is greatly improved over the hyper-v engine by utilizing an actual local linux kernel. The WSL2 setup instructions are [here](https://docs.microsoft.com/en-us/windows/wsl/install-win10), and theWSL2 docker instructions are [here](https://docs.docker.com/docker-for-windows/wsl/)


### Installation

1. Create a postgres container (linux)
```sh
docker run --name radiomarket -e POSTGRES_PASSWORD="YourPWD" -d postgres
```

2. Clone the repo
```sh
git clone git@github.com:Jasigler/RadioMarket.UserService.git
```

3. Run The DB migration scripts
```sh
cd ./Database
```

4. Build the solution
```sh
cd RadioMarket.UserService\Radiomarket.UserService && dotnet build
```

5. Run the solution
```sh
dotnet run
```

## Usage
Examples of requests and their responses are shown in Postman. 
The default ports are:
  Https: 1780
  Http: 1770
  
In addition to the appropriate response code, the API will return an enum value that corresponds with the request result.
 
 ```js
 {
   Ok, 
   EmailInUse,
   BadPassword,
   EmailDoesntExist
 }
 ```



###### Add a new user (200):
![Add User 200](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Add_User_200.PNG)

##### Adding a new user with exisiting email address (400):
![](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Add_User_Email_Taken.PNG)

###### Verify a user (200):
![Verify User 200](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Verify_User_200.PNG)

##### Verify a user with bad password (400):
![Verify User Bad Pwd](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Verify_User_BadPassword.PNG)

##### Verify a user with bad email (400):
![Verify User Bad Pwd](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Verify_User_BadEmail.PNG)

##### Get user data (200):
![Get User 200](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Get_UserInfo.PNG)

##### Get user data with bad userId (400):
![User Doesnt Exist](https://github.com/Jasigler/RadioMarket.UserService/blob/master/Images/Get_Userinfo_NotExist.PNG)



## Roadmap

This is an ongoing project.
See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a list of proposed features (and known issues).



## Contact

[@that_sigler](https://twitter.com/that_sigler) - jason.sigler@outlook.com

Project Link: [https://github.com/jasigler/RadioMarket.UserService](https://github.com/jasigler/RadioMarket.UserService)


