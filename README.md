# example dependency injection

<!-- TOC -->
* [Introduction](#introduction)
* [Dev keynotes](#dev-keynotes)
* [Fun facts](#fun-facts)
* [How this project was built](#how-this-project-was-built)
<!-- TOCEND -->

## Introduction

Purpose of this example is to show what dependency injection consists of and why its useful.

DI sometimes referred as IOC ( inversion of control ) states that isn't you responsible to create class instances but the service provider take care of that.

One think how can a program work if you can't create any object, of course in fact youll'do "inversely" through the use of a service builder in which you declare concrete object mapping to abstract, interfaces. Generally these service builder manage also the lifetime scope of the object as per singleton rather than scope ( they created on request and released when no more referenced ).

Use DI has some effects about the performance in object create, to benchmark the differences checkout the `benchmark` branch with `git checkout benchmark`. Follows comparision using about 800k calls of Service1 instantiation without DI ( direct service class instantiation ) and with ( using DI ) :

```sh
devel0@tuf:~/Documents/opensource/example-di$ dn run -c Release
DI BENCHMARK
  without : 00:00:00.2052394
  with    : 00:00:26.4634291
```

IoC allow to establish *loose coupling* between the layers you architect in your application. It allow you to ensure separation of concerns, enabling a sort of OOP encapsulation but at class/services rather than at methods or properties level.

DI is also used in the [clean architecture][1] pattern where there are benefits about the level of abstraction and modularity the application can achieve.

[1]: https://yoan-thirion.gitbook.io/knowledge-base/software-craftsmanship/code-katas/clean-architecture

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

## Execution

```sh
$ dotnet run
0.8722451498981519 + 0.7761152910999208 = 1.6483604409980728 ( matches )
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /home/devel0/Documents/opensource/example-di
0.8369665338633472 + 0.22125008465598472 = 1.058216618519332 ( matches )
0.9576765265593807 + 0.7209286927062147 = 1.6786052192655956 ( matches )
0.12588186914263888 + 0.1914292963073334 = 0.3173111654499723 ( matches )
```

## Fun facts

Without changing the implementation of Service2 you can execute the application using another instance type of Service1 by [substituting in the service mapping][8].

[8]: https://github.com/devel0/example-dependency-injection/blob/02038d482563e8944ee163a78007c99c20536e3a/Program.cs#L10

```sh
$ dotnet run
0.8001468290359208 + 0.212695476319962 = 1.0128423053558828 ( NOT matches )
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /home/devel0/Documents/opensource/example-di
0.8244152948560144 + 0.14512889210099444 = 0.9695441869570088 ( NOT matches )
0.6328938769401693 + 0.5873820115870374 = 1.2202758885272067 ( NOT matches )
0.9464424297386741 + 0.14904111339171255 = 1.0954835431303866 ( NOT matches )
0.19357539247737165 + 0.8354667215111734 = 1.029042113988545 ( NOT matches )
```

## How this project was built

```sh
dn new console -n example-di
cd example-di
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package Microsoft.Extensions.Hosting --version 7.0.0
```
