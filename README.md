# ShopsRUs Retail Store Discounts

This project provides a solution for calculating discounts, generating total costs, and creating invoices for customers at ShopsRUs.

## Table of Contents

-   Prerequisites
-   Getting Started
    -   Running the Application
    -   Running Unit Tests
    -   Generating Code Coverage Reports
-   UML Class Diagram

## Prerequisites

Before you begin, ensure you have the following installed:

-   [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
-   [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
-   [NuGet](https://www.nuget.org/)

## Getting Started

Follow these steps to set up and run the project:

### Running the Application

1.  Clone the repository: 
    
    `git clone https://github.com/metehanbdm/ShopsRUsRetailStoreDiscounts.git` 
    
2.  Navigate to the project directory: 
    
    `cd shopsrus-retail-discounts` 
    
3.  Open the project in Visual Studio or Visual Studio Code.
    
4.  Build and run the project.
    

### Running Unit Tests

1.  To run unit tests, navigate to the project directory: 
    
    `cd shopsrus-retail-discounts.Tests` 
    
2.  Run the following command to execute unit tests: 
    
    `dotnet test` 
    

### Generating Code Coverage Reports

To generate code coverage reports, follow these steps:

1.  Ensure you have the [ReportGenerator](https://github.com/danielpalme/ReportGenerator) tool installed: 
    
    `dotnet tool install -g dotnet-reportgenerator-globaltool` 
    
2.  Run the tests with coverage: 
    
    `dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov` 
    
3.  Generate the code coverage report: 
    
    `reportgenerator -reports:coverage.info -targetdir:coverage-report` 
    
4.  Open the generated HTML report located in the `coverage-report` directory: 
    
    `open coverage-report/index.htm` 
    

## UML Class Diagram

![image](https://github.com/metehanbdm/ShopsRUsRetailStoreDiscounts/assets/40835036/74639f8d-e282-4e6e-b303-2325964e56c5)

In this diagram:

-   `Customer` represents the customer information, including attributes like `Id`, `Name`, `IsEmployee`, `IsAffiliate`, and `JoinDate`. These attributes define the customer's status and join date.
    
-   `InvoiceItem` represents individual items on an invoice, including attributes like `Description`, `Price`, and `IsGrocery`. These attributes describe each item's details.
    
-   `Discount` represents discount information, including attributes like `Id`, `Name`, and `Percentage`. These attributes define different types of discounts available.
    
-   `Invoice` represents an invoice that combines a `Customer` with a list of `InvoiceItem` objects. It has attributes such as `Id`, `Customer`, and `Items`.
    

The relationships are depicted as follows:

-   `Invoice` has an association relationship with `Customer`, indicating that an invoice is associated with a customer.
    
-   `Invoice` has an aggregation relationship with `InvoiceItem`, showing that an invoice is composed of multiple invoice items.
