﻿# dotnet-prune

Removes all empty directories recursively, starting in the current working directory.

**To install**
```
dotnet tool install dotnet-prune
```

**To use**
```
dotnet prune [directory]

Arguments:
    directory     The directory to begin pruning at.
                  Defaults to the current working directory if not provided.
```