# readme.md

## About
This example shows how to run the console application through the `docker` and communicate with it:
  * Console application can read/write the host machine files. It is convenient way for passing big data into the application and getting the result of it handling.
  * Initializing the environment variable for console application process. This is way for passing a little bit of data into the application (URL, port, token, etc.).
  * Passing data as the console application arguments.

## Build the docker-image
Run the command in PowerShell:
```
docker build -t console-example .
```

## Run the container on Windows OS
Run the commands:
```
$inputDir = $(pwd).Path + "\input:/app/input"
$outputDir = $(pwd).Path + "\output:/app/output"
docker run -it --rm --name console-example -e "MESSAGE=Hello World."  -v $inputDir -v $outputDir console-example input-data.txt, output-data.txt
```

## Result
The result:
```
Arg #0: input-data.txt
Arg #1: output-data.txt
Environment variable value: Hello World.
Your name: Jack
```
Also pay attention that the `.\output\output-data.txt` file was created on the host machine.

**NOTE**  
If the `.\input` and `.\output` directories are not exist 
on the host machine then it will be created by `docker`.