
// IButton button = new WindowsButton();

IButton button = CreateButton("MacOS");
Console.WriteLine($"Button Name: {button.Name}");
button.Click();

// var guiFactory = new WindowsFactory();
// var button2 = guiFactory.CreateButton();

return;


// Factory method
IButton CreateButton(string os)
{
    return os switch
    {
        "Windows" => new WindowsButton(),
        "MacOS" => new MacOSButton(),
        _ => throw new ArgumentException("Invalid OS")
    };
}

// Abstract Factory
// interface IGUIFactory
// {
//     IButton CreateButton();
//     IWindow CreateWindow();
// }


class WindowsFactory : IGUIFactory
{}

// x-window system
interface IButton
{
    string Name { get; set; }
    void Click();
}

class WindowsButton : IButton
{
    public string Name { get; set; } = "Windows Button";

    public void Click()
    {
        Console.WriteLine("Windows Button Clicked");
    }
}

class MacOSButton : IButton
{
    public string Name { get; set; } = "MacOS Button";

    public void Click()
    {
        Console.WriteLine("MacOS Button Clicked");
    }
}