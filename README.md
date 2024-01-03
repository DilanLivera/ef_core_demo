# EF Core Demo

## How to run

1. Build the docker image by the `docker build -t web_api .` command. You can confirm the image
   exists
   by running the `docker image ls` command. You should see a repository named **web_api** in the
   list. If you see the following error when

2. Run the `docker-compose up` command to run the application. If you get the following error,
   this could mean the web_api image is not available. To build the image, please refer to the first
   step.

    ```powershell
    [+] Running 1/1
     ✘ web_api Error                                                                                                                                                 4.3s
    Error response from daemon: pull access denied for web_api, repository does not exist or may require 'docker login': denied: requested access to the resource is denied
    d
    ```

> [!NOTE]
> Please wait for the SQL Server to start. Even though the web API is set to start after
> the SQL server starts(Please refer to the docker-compose file's **web_api** service section),
> the web API still start before the SQL server finishes. If you try retrieving the data from the db
> before the SQL Server starts, you will get the following exception. You will see a lot of logs
> from the SQL server after it starts. Please wait to see these logs before you try to seed the DB.
>   ```text
>   Microsoft.Data.SqlClient.SqlException (0x80131904): A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 40 - Could not open a connection to SQL Server: Could not open a connection to SQL Server)
>   ```

3. Run the `POST` `/weatherforecast` request in the
   _Web.Api/WeatherForecasts/POST_weatherforecasts.http_ file to seed the DB with weather forecast
   data.

4. Run the `GET` `/weatherforecast` request in the
   _Web.Api/WeatherForecasts/GET_weatherforecasts.http_ file to get the weather forecasts.
