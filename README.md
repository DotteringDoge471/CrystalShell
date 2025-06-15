# CrystalShell

**CrystalShell** is a development framework for creating custom desktop shells. It enables rapid development of GTK4 shells and beautiful, functional Wayland widgets using **TypeScript**, **JavaScript**, or **C#**.

Inspired by [Aylur/astal](https://github.com/Aylur/astal), CrystalShell also provides full C# bindings for Astal, bridging modern GTK and Wayland development with .NET.

## Features

- ⚙️ **C# Support for Shell Development**  
  Possibly the first shell framework to support C#. Thanks to **Gir.Core**, you can now use GTK4's GIR bindings to build modern desktop applications in C#.

- 💻 **TypeScript + JSX/Babel Support**  
  Built-in support for JSX/Babel allows you to write UI components using familiar syntax. Optional **XAML** support is also available for those who prefer the .NET ecosystem.

- 🧰 **No Bash Required**  
  CrystalShell includes service modules for networking, Bluetooth, battery, audio, and more—no shell scripting needed. Full bindings are available for **Wayland**, **Hyprland**, and **DBus** through .NET.

- 🎨 **Access to All Gtk Widgets**  
  Use any Gtk widget directly via **Gir.Core**—you’re not limited to a fixed set of components.

- 🚀 **Powered by V8, not GJS**  
  Thanks to **ClearScript 7**, CrystalShell provides a smoother development and debugging experience, powered by the V8 engine instead of GJS.

- 🔗 **Astal Integration**  
  We provide C#/JavaScript bindings for **libastal**, allowing you to integrate its libraries and services directly—ideal for filling in features not yet implemented in CrystalShell.

---

Looking to build your own Linux desktop shell? CrystalShell gives you the tools to do it your way.
