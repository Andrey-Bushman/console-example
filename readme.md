# readme.md
This project code sources are hosted on [GitHub](https://github.com/Andrey-Bushman/console-example.git).
## About
This example shows how to run the console application through the `docker` and communicate with it:
  1. Console application can read/write the host machine files. It is convenient way for passing big data into the application and getting the result of it handling.
  2. Initializing the environment variable of console application process. This is way for passing a little bit of data into the application (URL, port, token, etc.).
  3. Passing data as the console application arguments.

## Build the docker-image
Run the command in PowerShell:
```
git clone https://github.com/Andrey-Bushman/console-example.git
cd console-example
docker build -t console-example .
```

## Run the container on Windows OS
Run the commands on PowerShell terminal:
```
$inputDir = $(pwd).Path + "\input:/app/input"
$outputDir = $(pwd).Path + "\output:/app/output"
docker run -it --rm --name console-example -e "MESSAGE=Hello World."  -v $inputDir -v $outputDir console-example input-data.txt, output-data.txt
```
### What do these commands?
  1. Our container works in *interactive mode* (look at the `-it` parameter). It allows as to pass a name (or any other text) 
  when the application asks us through the console.
  1. Our docker-container will be deleted when its console application finished (look at the `--rm` parameter).
  1. Here we created the docker-container with *the same* name like its docker-image: *console-example* 
  (look at the `--name` parameter value).
  1. Also we created the `MESSAGE` environment variable in the container and initialized it by the *Hello World.* value 
  (look at the `-e` parameter value).
  1. We passed the *input-data.txt* and *output-data.txt* strings as *arguments* of our console application that 
  will be launched inside of our docker-container.
  1. Addidional, througt the `$inputDir` and `$outputDir` we mapped two local directories on two docker-container 
  directories on PowerShell console (look at the `-v` parameters values).

## Result
The result:
```
Arg #0: input-data.txt
Arg #1: output-data.txt
Environment variable value: Hello World.
Your name: Jack
Result file: ./output/output-data.txt
```
Pay attention the `./output/output-data.txt` file was created on the host machine.

**NOTE**  
If the `.\input` and `.\output` directories are not exist 
on the host machine then it will be created by `docker`.