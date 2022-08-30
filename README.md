# Automation Framework for API testing

### Framework for testing API Services with RestSharp and C# HTTP Client

## About The Project
This project for build for test the API testing using RestSharp with C#.Net language intergration with SpecFlow. The test cases are being read from the specFlow feature file.

### Built With
The Framework built with below main packages
* [SpecFlow](https://specflow.org/)
* [RestSharp](http://restsharp.org)
* [NUnit](https://nunit.org)

<!-- GETTING STARTED -->
## Getting Started

This is instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

* Visual Studio
* Create a Unit Test Project .net framework
* SpecFlow installed in Visual Studio

### Installation
* Install Packages from Nuget Manager
1. RestSharp
2. SpecFlow
3. Nunit


### Build Solution
* Build => Build Solution

![image](https://user-images.githubusercontent.com/14870031/187355007-863e5a6f-8bb3-4337-a872-ce536d50ce81.png)


### Run Tests

### Run Tests with Visual Studio, go through the following instructons
- Go to the Test tab in the visual studio menu 
- Select the "Configure Run Settings"

![image](https://user-images.githubusercontent.com/14870031/187338890-9a8535ce-f1a3-4fe8-8c3e-c3e4eb0dd61e.png)


- Select the run settings file from the folder 
- And navigates to the run settings file attached in the solution https://github.com/suranjith87/api_poc/blob/master/API_POC/AutomatedUITest.runsettings
- Once you select the file Click on the Run All button on Test Explorer

![image](https://user-images.githubusercontent.com/14870031/187343873-91ccd3d6-6f38-426d-aed9-6399b5385d10.png)

### Run Tests with Command Prompt/Windows PowerShell
* Open Folder in File Explorer: ..\API_POC\API_POC\bin\Debug\net6.0
* Open Command Prompt/Windows PowerShell
* Run "dotnet vstest API_POC.dll /Settings:AutomatedUITest.runsettings /Logger:trx"
 ![image](https://user-images.githubusercontent.com/14870031/187357162-b5b961fb-7457-4593-ac68-f9b83612ac95.png)
