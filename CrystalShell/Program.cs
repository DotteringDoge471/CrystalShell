using Gio;
using Gtk;
using Application = Adw.Application;

var application = Application.New("org.crystalshell.main", ApplicationFlags.FlagsNone);
application.OnActivate += (sender, args) =>
{
    var label = Label.New("Hello world");
    var window = ApplicationWindow.New((Application)sender);
    window.Title = "Window";
    window.SetDefaultSize(300, 300);
    window.SetChild(label);
    window.Show();
};
return application.RunWithSynchronizationContext(null);