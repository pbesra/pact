#### About

A command line tool to speed up your day to day activities.

#### Release

dotnet publish -c Release -r win-x64 --self-contained true
Compress-Archive -Path ./publish/* -DestinationPath pact.zip
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true -o ./publish

#### License

N/A
