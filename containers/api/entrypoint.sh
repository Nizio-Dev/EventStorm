#!/bin/bash
echo "XD"
set -e
run_cmd="dotnet run --verbose --project
./src/EventStorm.API/EventStorm.API.csproj"
until dotnet-ef database update --verbose --project
./src/EventStorm.API/EventStorm.API.csproj ; do
>&2 echo "SQL Server is starting up"
sleep 1
done
>&2 echo "SQL Server is up - executing command"
exec $run_cmd