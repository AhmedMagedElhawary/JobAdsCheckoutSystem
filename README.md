##### This is a C# console application developed using Microsoft Visual Studio 2017, .Net Framework 4.6.1.
##### To download the framework please click: **https://go.microsoft.com/fwlink/?linkid=2099470**

#### The solution contains two projects
JobAdsCheckoutSystem <br/>
JobAdsCheckoutSystemTest <br/>

##### For successful build you will need to restore Nuget for each, Visual studio should show a pop up suggesting Nuget restore
![Screenshot](NuGet.JPG)
##### To ensure NuGet is restored, you can select each project then navigate to Project - Manage Nuget Packages.

##### The main exe should be under JobAdsCheckoutSystem project folder under **bin\Debug\JobAdsCheckoutSystem.exe**.
![Screenshot](Demo.JPG)
##### It shows a demo of the software that can be traced under Program.cs.


##### JobAdsCheckoutService offer a public function that accept CustomerID and list of products
#### The function algorithm follows three simple steps:
1- Retrieve the relevant pricing rules of this customer.<br/>
2- Apply these list of rules over the products list.<br/>
3- Return the total price.<br/>

Data of rules/products are stored under Json files.<br/>
Repository pattern was followed to isolate the data access layer from the business logic layer.<br/>
Two implantations of first discount rule was provided for BuyXGetYFree rule and only one for QuantityDiscount rule.<br/>

The system was designed to also justify the final price and map the applied rule and to handle real live complex scenarios.<br/> 


##### A copy was uploaded over GitHub repository: **https://github.com/AhmedMagedElhawary/JobAdsCheckoutSystem**
##### Continuous integration was enabled via Travis-CI to check against Unit testing/Building errors.
![Screenshot](ContinuousIntegration.JPG)

---

## Run on any platform

### Dockerizing the solution

The solution that I have created is now dockerized, making it easy for anyone to run on their machines, provided docker is supported on that OS.

Here are the steps:

- Verify that docker is installed in your machine and running via `docker -v` command
- Run `docker build -t meego-app .` to create and tag the image from the local Dockerfile
- Run `docker run --rm -dit meego-app:latest` to fire a container using the latest image built in the last step
- Once the container is running, get into it using `docker exec -it ${CONTAINER_ID} /bin/sh -c "[ -e /bin/bash ] && /bin/bash || /bin/sh"`. Just a hint container ID could be found out using `docker container ls`
- You are almost there
- Once inside the container run this command to execute the solution `cd JobAdsCheckoutSystem/bin/Release/ && mono JobAdsCheckoutSystem.exe`
- Can you believe you eyes :O ?