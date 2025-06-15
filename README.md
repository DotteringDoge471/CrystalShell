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

## Supported Desktops

**CrystalShell** only works on **Wayland**, and specifically on Wayland compositors that support the **Layer Shell** protocol.

### ✅ Supported Compositors

- **wlroots-based compositors**  
  e.g. [Sway](https://swaywm.org/), Hyprland, Wayfire

- **Smithay-based compositors**  
  e.g. [COSMIC](https://github.com/pop-os/cosmic)

- **Mir-based compositors**  
  Some may not enable the protocol by default. You can enable it using:  
  `--add-wayland-extension zwlr_layer_shell_v1`

- **KDE Plasma on Wayland**

### ❌ Not Supported

- **GNOME on Wayland** (does not implement Layer Shell)
- **Any X11-based desktop environment**

## Libraries and Services

CrystalShell provides a wide range of services and bindings for building fully functional desktop shells. All modules support both **C#** and **JavaScript** unless otherwise noted.

### 🧩 Core Libraries

- **Hyprland Bindings** – Integrate with Hyprland compositor (C#/JavaScript)
- **Wayfire Config Manager** – Manage Wayfire configuration files (C#/JavaScript)
- **DBus Library** – High-level DBus bindings (C#/JavaScript)
- **Astal4 Compatibility Layer** – Use `libastal` with GTK4 in CrystalShell (C#/JavaScript)
- **SocketIO Library** – Real-time communication via Socket.IO (C#/JavaScript)
- **Cryptography Library** – Hashing, encryption, and secure storage (C#/JavaScript)
- **MonoPosix Bindings** – Access POSIX-level APIs (C#/JavaScript)

### 🧱 Shell & System Services

- **SystemTray Service** – System tray icon and status support (C#/JavaScript)
- **Greetd Service** – Integration with greetd-based display managers (C#/JavaScript)
- **Notifications Service** – Notification handling and display (C#/JavaScript)
- **Applications Service** – Application discovery and launching (C#/JavaScript)
- **Battery Service** – Battery status and power monitoring (C#/JavaScript)
- **Bluetooth Service** – Manage Bluetooth devices and state (C#/JavaScript)
- **Network Service** – Monitor and control networking (C#/JavaScript)
- **NetIOService** – Lightweight embedded HTTP server (C#/JavaScript)
- **PamService** – Pluggable authentication module integration (C#/JavaScript)
- **MPRIS Service** – Media control via MPRIS (C#/JavaScript)
- **PipeWire Service** – Audio/video interface via WirePlumber (C#/JavaScript)
- **ScreenCopy Service** – Capture screen frames (C#/JavaScript)
- **Cava Service** – Audio visualizer support via CAVA (C#/JavaScript)
- **PowerProfiles Service** – Manage CPU power profiles (C#/JavaScript)
- **Gaming Service** – Game mode and performance tuning (C#/JavaScript)
- **DiscordRPC Service** – Integration with Discord Rich Presence (C#/JavaScript)
- **FileSystems Service** – Access mount points and disk info (C#/JavaScript)
- **Screenshot Service** – Take screenshots (C#/JavaScript)
- **Clipboard Service** – Manage clipboard content (C#/JavaScript)
- **DConf Service** – Read/write GNOME DConf settings (C#/JavaScript)
- **NHyprPm Service** – `hyprpm` Wrapper (C#/JavaScript)

### 🛠 Scripting & UI Support

- **Utils** – Helper functions and utilities (C#/JavaScript)
- **BabelNTypes Support** – TypeScript + Babel support for JS developers
- **XAML GTK Support** – Write UI in XAML when using .NET (C# only)

### 🧩 .NET Runtime Integration

Includes access to **all .NET runtime types** for maximum flexibility.

## Project Structure

- **CrystalShell** – The core framework for building custom desktop shells  
- **CrystalShell.Gtk4LayerShell** – C# bindings for the `gtk4-layer-shell` library
