https://o7planning.org/en/11217/create-java-restful-client-with-jersey-client
        Client client = Client.create();
        WebResource webResource = client.resource("http://localhost:8080/RESTfulCRUD/rest/employees");
        // Data send to web service.
        String input = "{\"empNo\":\"E01\",\"empName\":\"New Emp1\",\"position\":\"Manager\"}";
        ClientResponse response = webResource.type("application/json").post(ClientResponse.class, input);

https://stackoverflow.com/questions/46507029/how-to-disable-https-in-visual-studio-2017-web-proj-asp-net-core-2-0?rq=1
go to your project properties
Uncheck the SSL option
Copy the App Url over to the Start browser input 

