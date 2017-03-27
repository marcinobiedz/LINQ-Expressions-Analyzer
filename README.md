# LINQ Analyzer - API
**LINQ Analyzer API** in a server side part of MSc application called **LINQ Analyzer**.
The application can work alone as a API server for LINQ analysis nevertheless
it is designed to work with **LINQ Analyzer UI** which can be found under this link:
- [LINQ Analyzer UI](https://github.com/marcinobiedz/LINQ-UI)

## Requirements
To start a project in a developer version you will need a several items:
- Visual Studio 2015
- .NET Framework 4.5.2

## Configuration
To start the project you will need to set several configuration variables. Variables are to be set in a **Web.config** file
that can be found in a root of the project.

```
1. <add key="UI_URL" value="*"/>
2. <add key="DB_PATH" value="*"/>
```
### 1. Set URL
First of all you need to set the *value* attribute in a tag with **UI_URL** key, this value will indicate the
URL that will be allowed to send the requests to server. If you want to allow all domains then simply
set the value to asterisk:

`<add key="UI_URL" value="*"/>`

If you want to filter the domain type, for example:

`<add key="UI_URL" value="http://localhost:8000"/>`
### 2. Set Database
Second parameter that is required to set is **DB_PATH**, in case of this tag it tells the compiler which DB should be use.
For developer purposes it is easier to work with a smaller DB and you can set *Dev* value like this:

`<add key="DB_PATH" value="Dev"/>`

On the other hand, if you would like to test your software on bigger database you can set it by using *Prod* value:

`<add key="DB_PATH" value="Prod"/>`

## Start project
After all configurations just simply start the project in Visual Studio. All packages will be downloaded with first run.