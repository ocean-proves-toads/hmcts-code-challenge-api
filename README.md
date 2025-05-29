# Getting Started

This is my .NET Web Api for the HMCTS Code Challenge Task Management App

## Set up

Clone the Repository
change directory to `TasksApi`
run `dotnet run` 

### Documentation

There is a swagger interface for documentation and testing the api

once the server is running open [http://localhost:5021/swagger/index.html](http://localhost:5021/swagger/index.html) in your browser

### `GET /api/MojTasks`

Lists all the tasks

### `POST /api/MojTasks`

Add a task the tasks

### `GET /api/MojTasks{id}`

Retrieved the tasks with id

### `PUT /api/MojTasks{id}`

Updates the details for task with id

### `DELETE /api/MojTasks{id}`

Deleted the task with id

## Task Schema

MojTask\
taskId:	        integer($int32)\
taskDescription:	string, maxLength: 2000, nullable: true\
taskStatus:  	string minLength: 1, required \
taskDueDate:	string($date), required (eg. 2025-05-25)\




