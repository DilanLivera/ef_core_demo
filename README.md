# EF Core Demo

## How to run

1. Build the docker image by the `docker build -t web_api .` command. You can confirm the image
   exists
   by running the `docker image ls` command. You should see a repository named **web_api** in the
   list. If you see the following error when

2. Run the `docker-compose up` command to run the application. If you get the following error, this
   could mean the web_api image is not available. To build the image, please refer to the first
   step.

    ```powershell
    [+] Running 1/1
     ✘ web_api Error                                                                                                                                                 4.3s
    Error response from daemon: pull access denied for web_api, repository does not exist or may require 'docker login': denied: requested access to the resource is denied
    d
    ```
3. Wait for the SQL Server to start. If you try retrieving the data from the db before the SQL
   Server starts, you will get the following exception.

   ```text
   Microsoft.Data.SqlClient.SqlException (0x80131904): A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 40 - Could not open a connection to SQL Server: Could not open a connection to SQL Server)
   ```

4. Run the `POST` `/weatherforecast` request in the
   _Web.Api/WeatherForecasts/POST_weatherforecasts.http_ file to seed the DB with weather forecast
   data.

5. Run the `GET` `/weatherforecast` request in the
   _Web.Api/WeatherForecasts/GET_weatherforecasts.http_ file to get the weather forecasts.
