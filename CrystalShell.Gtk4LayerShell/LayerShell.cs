using System.Runtime.InteropServices;
using CrystalShell.Gtk4LayerShell.Global;
using Gtk;

// ReSharper disable InconsistentNaming

namespace CrystalShell.Gtk4LayerShell;

public static class LayerShell
{
#pragma warning disable SYSLIB1054

    #region P/Invoke

    [DllImport("gtk4-layer-shell")]
    private static extern uint gtk_layer_get_major_version();

    [DllImport("gtk4-layer-shell")]
    private static extern uint gtk_layer_get_minor_version();

    [DllImport("gtk4-layer-shell")]
    private static extern uint gtk_layer_get_micro_version();

    [DllImport("gtk4-layer-shell")]
    private static extern bool gtk_layer_is_supported();

    [DllImport("gtk4-layer-shell")]
    private static extern uint gtk_layer_get_protocol_version();

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_init_for_window(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern bool gtk_layer_is_layer_window(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_namespace(IntPtr window, IntPtr name_space);

    [DllImport("gtk4-layer-shell")]
    private static extern IntPtr gtk_layer_get_namespace(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_layer(IntPtr window, Layer layer);

    [DllImport("gtk4-layer-shell")]
    private static extern Layer gtk_layer_get_layer(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_anchor(IntPtr window, Edge edge, bool anchor_to_edge);

    [DllImport("gtk4-layer-shell")]
    private static extern bool gtk_layer_get_anchor(IntPtr window, Edge edge);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_margin(IntPtr window, Edge edge, int margin_size);

    [DllImport("gtk4-layer-shell")]
    private static extern int gtk_layer_get_margin(IntPtr window, Edge edge);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_exclusive_zone(IntPtr window, int exclusive_zone);

    [DllImport("gtk4-layer-shell")]
    private static extern int gtk_layer_get_exclusive_zone(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_auto_exclusive_zone_enable(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern bool gtk_layer_auto_exclusive_zone_is_enabled(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_keyboard_mode(IntPtr window, KeyboardMode mode);

    [DllImport("gtk4-layer-shell")]
    private static extern KeyboardMode gtk_layer_get_keyboard_mode(IntPtr window);

    [DllImport("gtk4-layer-shell")]
    private static extern void gtk_layer_set_keyboard_interactivity(IntPtr window, bool interactivity);

    [DllImport("gtk4-layer-shell")]
    private static extern bool gtk_layer_get_keyboard_interactivity(IntPtr window);

    #endregion

    #region Public Methods

    /// <summary>
    ///     Gets the major version of the gtk4-layer-shell library.
    ///     获取 gtk4-layer-shell 库的主版本号。
    /// </summary>
    public static uint MajorVersion => gtk_layer_get_major_version();

    /// <summary>
    ///     Gets the minor version of the gtk4-layer-shell library.
    ///     获取 gtk4-layer-shell 库的次版本号。
    /// </summary>
    public static uint MinorVersion => gtk_layer_get_minor_version();

    /// <summary>
    ///     Gets the micro (patch) version of the gtk4-layer-shell library.
    ///     获取 gtk4-layer-shell 库的补丁版本号。
    /// </summary>
    public static uint MicroVersion => gtk_layer_get_micro_version();

    /// <summary>
    ///     Returns whether gtk4-layer-shell is supported by the current Wayland compositor.
    ///     May trigger a Wayland roundtrip.
    ///     判断当前的 Wayland 合成器是否支持 gtk4-layer-shell。
    ///     可能会触发一次 Wayland 往返操作。
    /// </summary>
    public static bool IsSupported => gtk_layer_is_supported();

    /// <summary>
    ///     Gets the version of the Layer Shell protocol supported by the compositor.
    ///     Returns 0 if unsupported.
    ///     获取合成器支持的 Layer Shell 协议版本号。
    ///     如果不支持该协议，则返回 0。
    /// </summary>
    public static uint ProtocolVersion => gtk_layer_get_protocol_version();

    /// <summary>
    ///     Initializes the given GTK window as a Layer Shell surface.
    ///     Must be called before the window is realized (i.e. before <c>Show()</c>).
    ///     初始化指定的 GTK 窗口为 Layer Shell 表面。
    ///     必须在窗口被 realize 之前调用（即调用 Show() 前）。
    /// </summary>
    /// <param name="window">
    ///     The Gtk.Window to be turned into a layer surface.
    ///     要转为 Layer Shell 表面的 Gtk 窗口。
    /// </param>
    public static void InitWindow(Window window)
    {
        gtk_layer_init_for_window(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Checks whether the given GTK window is a Layer Shell window.
    ///     检查给定的 GTK 窗口是否为 Layer Shell 类型窗口。
    /// </summary>
    /// <param name="window">
    ///     The GTK window to check.
    ///     要检查的 GTK 窗口。
    /// </param>
    /// <returns>
    ///     True if the window has been initialized as a layer surface.
    ///     如果该窗口已被初始化为 Layer Shell 表面，则返回 true。
    /// </returns>
    public static bool IsLayerWindow(Window window)
    {
        return gtk_layer_is_layer_window(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Sets the namespace of the layer surface. Default is "gtk4-layer-shell".
    ///     设置 Layer Shell 表面的命名空间。默认值为 "gtk4-layer-shell"。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="namespace">
    ///     The namespace string (e.g., "panel", "osk").
    ///     命名空间字符串（如 "panel"，"osk"）。
    /// </param>
    public static void SetNamespace(Window window, string @namespace)
    {
        gtk_layer_set_namespace(window.Handle.DangerousGetHandle(), Marshal.StringToCoTaskMemUTF8(@namespace));
    }

    /// <summary>
    ///     Gets the current namespace assigned to the layer surface.
    ///     获取当前 Layer Shell 表面所使用的命名空间。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <returns>
    ///     The namespace string, or the default if not set.
    ///     命名空间字符串，如果未设置则返回默认值。
    /// </returns>
    public static string GetNamespace(Window window)
    {
        return Marshal.PtrToStringUTF8(gtk_layer_get_namespace(window.Handle.DangerousGetHandle())) ?? string.Empty;
    }

    /// <summary>
    ///     Sets the layer type of the window (e.g., background, bottom, top, overlay).
    ///     设置窗口的图层类型（如 background、bottom、top、overlay）。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="layer">
    ///     The layer to set.
    ///     要设置的图层类型。
    /// </param>
    public static void SetLayer(Window window, Layer layer)
    {
        gtk_layer_set_layer(window.Handle.DangerousGetHandle(), layer);
    }

    /// <summary>
    ///     Gets the current layer of the given layer surface.
    ///     获取当前 Layer Shell 表面的图层类型。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <returns>
    ///     The current layer type.
    ///     当前图层类型。
    /// </returns>
    public static Layer GetLayer(Window window)
    {
        return gtk_layer_get_layer(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Sets whether the window should be anchored to the given edge.
    ///     设置是否将窗口锚定到指定边缘。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="edge">
    ///     The edge to anchor to.
    ///     要锚定的边缘。
    /// </param>
    /// <param name="anchorToEdge">
    ///     Whether to anchor to the edge.
    ///     是否锚定到边缘。
    /// </param>
    public static void SetAnchor(Window window, Edge edge, bool anchorToEdge)
    {
        gtk_layer_set_anchor(window.Handle.DangerousGetHandle(), edge, anchorToEdge);
    }

    /// <summary>
    ///     Gets whether the window is anchored to the given edge.
    ///     获取窗口是否已锚定到指定边缘。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="edge">
    ///     The edge to check.
    ///     要检查的边缘。
    /// </param>
    /// <returns>
    ///     True if the window is anchored to the specified edge.
    ///     如果已锚定到该边缘，则返回 true。
    /// </returns>
    public static bool GetAnchor(Window window, Edge edge)
    {
        return gtk_layer_get_anchor(window.Handle.DangerousGetHandle(), edge);
    }

    /// <summary>
    ///     Sets the margin for the given edge of the window.
    ///     设置窗口指定边缘的边距。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="edge">
    ///     The edge to set the margin for.
    ///     要设置边距的边缘。
    /// </param>
    /// <param name="marginSize">
    ///     The margin size in pixels.
    ///     边距大小（以像素为单位）。
    /// </param>
    public static void SetMargin(Window window, Edge edge, int marginSize)
    {
        gtk_layer_set_margin(window.Handle.DangerousGetHandle(), edge, marginSize);
    }

    /// <summary>
    ///     Gets the margin size for the specified edge.
    ///     获取指定边缘的边距大小。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="edge">
    ///     The edge to get the margin for.
    ///     要获取边距的边缘。
    /// </param>
    /// <returns>
    ///     The size of the margin in pixels.
    ///     边距大小（像素）。
    /// </returns>
    public static int GetMargin(Window window, Edge edge)
    {
        return gtk_layer_get_margin(window.Handle.DangerousGetHandle(), edge);
    }

    /// <summary>
    ///     Sets the exclusive zone for the window. Has no effect unless anchored.
    ///     设置窗口的专属区域大小。仅在锚定时有效。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="zone">
    ///     The exclusive zone size in pixels.
    ///     专属区域大小（像素）。
    /// </param>
    public static void SetExclusiveZone(Window window, int zone)
    {
        gtk_layer_set_exclusive_zone(window.Handle.DangerousGetHandle(), zone);
    }

    /// <summary>
    ///     Gets the current exclusive zone size for the window.
    ///     获取窗口当前的专属区域大小。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <returns>
    ///     The exclusive zone size in pixels.
    ///     专属区域大小（像素）。
    /// </returns>
    public static int GetExclusiveZone(Window window)
    {
        return gtk_layer_get_exclusive_zone(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Enables automatic exclusive zone sizing based on window size and margin.
    ///     启用基于窗口大小和边距的自动专属区域。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    public static void AutoExclusiveZoneEnable(Window window)
    {
        gtk_layer_auto_exclusive_zone_enable(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Checks if automatic exclusive zone sizing is enabled.
    ///     检查是否启用了自动专属区域。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <returns>
    ///     True if auto exclusive zone is enabled.
    ///     如果已启用自动专属区域，返回 true。
    /// </returns>
    public static bool AutoExclusiveZoneIsEnabled(Window window)
    {
        return gtk_layer_auto_exclusive_zone_is_enabled(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Sets how the window receives keyboard input.
    ///     设置窗口的键盘交互模式。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="mode">
    ///     The keyboard mode to use.
    ///     要使用的键盘交互模式。
    /// </param>
    public static void SetKeyboardMode(Window window, KeyboardMode mode)
    {
        gtk_layer_set_keyboard_mode(window.Handle.DangerousGetHandle(), mode);
    }

    /// <summary>
    ///     Gets the current keyboard interactivity mode of the window.
    ///     获取窗口当前的键盘交互模式。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <returns>
    ///     The current keyboard mode.
    ///     当前键盘交互模式。
    /// </returns>
    public static KeyboardMode GetKeyboardMode(Window window)
    {
        return gtk_layer_get_keyboard_mode(window.Handle.DangerousGetHandle());
    }

    /// <summary>
    ///     Sets whether the window should be interactive with the keyboard.
    ///     设置窗口是否允许与键盘交互。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <param name="interactivity">
    ///     True to enable keyboard interactivity.
    ///     是否启用键盘交互。
    /// </param>
    public static void SetKeyboardInteractivity(Window window, bool interactivity)
    {
        gtk_layer_set_keyboard_interactivity(window.Handle.DangerousGetHandle(), interactivity);
    }

    /// <summary>
    ///     Gets whether the window is interactive with the keyboard.
    ///     获取窗口是否允许键盘交互。
    /// </summary>
    /// <param name="window">
    ///     The layer surface window.
    ///     Layer Shell 表面窗口。
    /// </param>
    /// <returns>
    ///     True if the window accepts keyboard input.
    ///     如果允许键盘交互，返回 true。
    /// </returns>
    public static bool GetKeyboardInteractivity(Window window)
    {
        return gtk_layer_get_keyboard_interactivity(window.Handle.DangerousGetHandle());
    }

    #endregion

#pragma warning restore SYSLIB1054
}