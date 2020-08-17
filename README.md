# Endomondo Export

A simple app to download all workouts from the Endomondo in a GPX format.

## Usage
Download the **Endomondo.Export.exe**

Open Powershell or Command Prompt in a directory where **Endomondo.Export.exe**
lives.

Run command `.\Endomondo.Export.exe email password --limit X --path Y`

where:
- email `<string>` [required] [positional] <br/> 
Specifies the user email in Endomondo.
- password `<string>` [required] [positional] <br/> 
Specifies the user password in Endomondo.
- limit `<int>` [optional] <br/> 
Specifies how many recent workout to download. The default limit is 7.
- path `<string>` [optional] <br/>
Specifies a path to an existing directory where all the workouts will be saved. The default location is the current directory. 

Example: 
`.\Endomondo.Export.exe foo@bar.com P@$$w0rd --limit 100 --path C:\gpx-files`
