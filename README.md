# example dependency injection

<!-- TOC -->
* [Introduction](#introduction)
* [Dev keynotes](#dev-keynotes)
* [Fun facts](#fun-facts)
* [How this project was built](#how-this-project-was-built)
<!-- TOCEND -->

## Introduction

Purpose of this example is to show what dependency injection consists of and why its useful.

Concept of DI also named IOC ( inversion of control ) states that you don't create object instances from your classes but is the engine that take care of that.

One think how can a program work if you can't create any object, of course in fact youll'do "inversely" through the use of a service builder in which you declare concrete object mapping to abstract, interfaces. Generally these service builder manage also the lifetime scope of the object as per singleton rather than scope ( they created on request and released when no more referenced ).

Use of DI could not be compatible within a **realtime application** where the reflecting lookup done by the DI system introduce a little overhead, to benchmark the differences checkout the `benchmark` branch with `git checkout benchmark`. Follows comparision:

```sh
devel0@tuf:~/Documents/opensource/example-di$ dn run -c Release
DI BENCHMARK
  without : 00:00:00.2052394
  with    : 00:00:26.4634291
```

So why to use DI ? the most important concept related to IoC is that allow to establish *loose coupling* between the layers you architect in your application. It allow you to ensure separation of concerns, a sort of OOP encapsulation but at class/services levels instead of properies or fields. it's highly used in the [clean architecture][1] pattern.

[1]: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

## Dev keynotes

- add [package references][2]
- define [service interface1][3] and [interface2][4]
- implement [service1][5]
- implement [service2][6] using IoC to retrieve the service wanted ( the constructor will be called by the DI using approriate service instance )
- create a [host builder][7] assigning services mapping and run it

[2]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/example-di.csproj#L12-L13
[3]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Service1/IService1.cs#L3
[4]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Service2/IService2.cs#L3
[5]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Service1/Service1.cs#L6
[6]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Service2/Service2.cs#L6-L8
[7]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Program.cs#L5-L16

## Fun facts

Without changing the implementation of Service2 you can execute the application using another instance type of Service1 by [substituting in the service mapping][8].

[8]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Program.cs#L10

## How this project was built

```sh
dn new console -n example-di
cd example-di
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package Microsoft.Extensions.Hosting --version 7.0.0
```
