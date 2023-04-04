# PizzeriaApp
- There are three APIs in this application and the main Api is Pizzerias (CWRETAIL.Api.Pizzerias) the other two are supporting microservises. 
- Open the solution on Visual studio 2022. 
- Build the solution
- Please make sure to configure the solution to run all Apis same time and run the application
- Please make sure the correct endpoints are configured on the Pizzerias appsettings.
- Please use the Pizzerias api swagger for executing the endpoint:
+ Eg: following json represent the sample order and the API will calculate the correct total amount for the order.
>{
  "id": 0,
  "locationId": 1,
  "customerId": 1,
  "orderDate": "2023-04-04T13:09:16.013Z",
  "items": [
    {
      "id": 0,
      "locationMenuId": 1,
      "quantity": 2
    },
{
      "id": 0,
      "locationMenuId": 2,
      "quantity": 2
    }
  ]
}
