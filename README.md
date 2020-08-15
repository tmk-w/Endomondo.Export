# Endomondo Export

A simple app to download all workouts from the Endomondo in a GPX format.

## Usage
Download the **Endomondo.Export.exe**

Open Powershell or Command Prompt in a directory where **Endomondo.Export.exe**
lives.

Run command `.\Endomondo.Export.exe email password --limit X --path Y`

where:
- email - user email in Endomondo
- password- user password in Endomondo
- limit - [optional parameter] how many recent workout to download. Default value - 7
- path - [optional parameter] an EXISTING directory where all the workouts will be saved 

Example: 
`.\Endomondo.Export.exe foo@bar.com P@$$w0rd --limit 100 --path C:\gpx-files`
