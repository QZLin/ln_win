# ln_win

A small Windows utility for creating hard links, directory junctions, and symbolic links from a simple WinForms interface.

## Features

- Create a hard link for files or a junction for directories
- Create symbolic links for files and folders
- Option to use a relative target path when creating symbolic links
- Force overwrite existing link targets when needed
- Drag files/folders directly into the input boxes
- Accept a startup path argument to pre-populate the working directory

## What this project does

This app makes it easy to create links in a target folder without using the command line manually. It supports the common Windows link types:

- SYMLINK: symbolic link
- JUNCTION: directory junction
- HARDLINK: hard link

The main logic lives in `Main.cs`, and the UI is defined in `Main.Designer.cs`.

## Requirements

- Windows 10 or newer
- .NET 10 SDK / Windows App SDK-compatible toolchain for building WinForms apps
- Visual Studio 2022 or `dotnet` command-line build tools

## Build

```bash
dotnet build ln_win.csproj
```

## Run

```bash
dotnet run --project ln_win.csproj
```

Or open the generated solution/project in Visual Studio and run it directly.

## Usage

1. Enter the target file or folder in the first field, or drag it in.
2. Enter the destination work directory in the second field.
3. Choose the link type:
   - `SYMLINK` for symbolic links
   - leave it unchecked for `JUNCTION` or `HARDLINK`
4. Optionally enable `Relative` to create the link target relative to the work directory.
5. Click the action or press Enter to create the link.

## Notes

- A file target and work directory must both exist.
- `Force recreate` only works when the existing path is already a reparse point or link.
- The app uses Windows-specific APIs and is intended for Windows environments only.

## Project files

- `Main.cs` — link creation logic and event handlers
- `Main.Designer.cs` — WinForms UI layout
- `ln_win.csproj` — project configuration
- `ln_win.ico` — application icon
