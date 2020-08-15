# Endomondo Export

A simple app to download all workouts from the Endomondo in GPX format.

## Usage
Download the .zip and extract it.

Run Powershell or Command Prompt and go to directory where files have been extracted.

Use `.\Endomondo.Export.exe email password --limit X --path Y`

where:
- email - user email in Endomondo
- password- user password in Endomondo
- limit - [optional parameter] how many recent workout to download. Default value - 7
- path - [optional parameter] an EXISTING directory where all the workouts will be saved 

Example: 
`.\Endomondo.Export.exe foo@bar.com P@$$w0rd --limit 100 --path C:\gpx-files`
