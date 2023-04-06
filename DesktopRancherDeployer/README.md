# Rancher Desktop 

## Auto Download & Auto installer

[Rancher Desktop](https://docs.rancherdesktop.io/)

This program is reccommended to be installed to a local system first. Followed by [Rancher](https://www.rancher.com/quick-start) being installed within.

## What's This directory? 
The main attraction here is xaml for automatic install and download of rancher desktop for windows. 

[Desktop Install App Video](https://youtu.be/NkRUeoUxYOk)

This App was built using dockerfile and .NET. Clone the repo then follow steps to get started. <br>

[Containerization Instructions](https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows)<br>

#### Build the container
> 1. docker build -t rancherdesktop -f Dockerfile . <br>

#### Name the container
> 2. docker create --name rancherdesktop-core rancherdesktop

#### Get Container ID
> 3. docker container ls

##### (Optional) Stop and Remove old image builds
> 4. docker stop <IMAGE_ID> && docker rm <IMAGE_ID>

[App containerization video](https://youtu.be/VDBjJX1WcUs)