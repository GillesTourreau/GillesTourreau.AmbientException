# GillesTourreau.AmbientException
Example and helper class to detect ongoing .NET exceptions.

This repository is related to my article on my blog:
- [Detect ongoing .NET exceptions](https://gilles.tourreau.fr/detect-ongoing-net-exceptions)

And also some of my answers on stackoverflow:
- [Detect exception context in .NET Standard 2.1](https://stackoverflow.com/questions/70913110/detect-exception-context-in-net-standard-2-1)

## ExceptionHelper
This class contains the `IsExceptionOnGoing()` method and allows for determining if an exception is ongoing.

The source code of this helper class works in .NET Standard, .NET Framework or .NET Core framework targets.