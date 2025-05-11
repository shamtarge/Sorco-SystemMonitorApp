# Sorco-SystemMonitorApp
A cross-platform C# console application for real-time system resource monitoring. It supports extensible plugin architecture and logs CPU, RAM, and Disk usage at a configurable interval.

---

## 🚀 Features

- ✅ Real-time monitoring of CPU, RAM, and Disk usage
- ✅ Cross-platform support (Windows, Linux, macOS)
- ✅ Plugin-based architecture
- ✅ Built-in file logging plugin
- ✅ Clean architecture and dependency injection-ready

---

## 🏗 Architecture

- **Factory Pattern** for platform detection
- **Interface + Abstract class** for monitoring logic
- **Plugin interface** (`IMonitorPlugin`) to extend functionality
- **Modular structure** for maintainability and testability

---

## 🔧 Requirements

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual Studio 2019 or later

---

## Run

>>dotnet run


