The simplest way to create a WPF application is by using the code behind to directly interact with UI elements. To show this it is best to explain the breakdown of a WPF application.

# Intro to WPF

A default WPF application comes with the following file structure:
![alt text](Guide/SolutionExplorer.png)

In WPF files are usually paired together with a xaml file representing UI elements and configuration and a C# file used to program behavior. The C# file is often reffered to as the code behind.

## App.xaml/.cs

the .xaml file is used to store configuration read by Visual Studio when running the application. The .cs file defines a partial class where we can write logic to control the start behaviour of the application. It is a partial class as Visual Studio compiles it together with the .xaml file to create a single class. As such these two files can have access to one another. In the xaml there is a line **StartupUri="MainWindow.xaml"** this essentially defines the entry point of the application as MainWindow.xaml.

## AssemblyInfo.cs

This file is used to modify assembly information but this is only needed in more complex scenarios.

## Dependencies

This is where all NuGet packages will be shown as well Analyzers and Frameworks. This section should never need to be edited in the explorer, any time a package is added it will be shown here.

## MainWindow.xaml/.cs

This is the first place where application code lives, opening the xaml shows some default code setting up the window properties and including needed namespaces for the app to work. Opening the .cs shows a partial class with a constructor that calls the InitializeComponent function. This is read by Visual Studio and is required to correctly load the window. It is a function gained from inheriting from the provided Window class.

# Hello World

1. Open up the MainWindow.xaml file and paste the following code then run the application:
   <Grid>
   <TextBlock Text="Hello World" FontSize="50" HorizontalAlignment="Center"  VerticalAlignment="Center"/>
   </Grid>

   This should have opened a window display hello world. This is using a UI element known as a TextBlock, we have edited properties on this text box directly in the xaml. However we may want to change sommething dynamically and in order to do this we would need to change it from the .cs file.

2. To do this we need to give this UI element a name, this is simlpy a propety on the Textblock so we can add the following code within the TextBlocks defintion: **x:Name="MyTextBlock"**. Now we can hop over to the .cs file and reference this element directly.
3. Go into the .cs file and add the following in the constructor just after InitializeComponent **MyTextBlock.Text = "Bonjour le monde";** Now run the application and you should see the new text on the screen.
   Note that we are setting the text twice as we did not remove the setting from the xaml. The InitializeComponent creates and renders the xaml, setting the text to hello world. Then the code we added is run which changes the text.
4. There are loads of UI elements however all of them follow the same structure as the TextBlock. Elements can be broken down into two main groups, display elements and structural elements. The most notable structural element is the <Grid>. You can add rows and columns and edit sizes to achieve the layout you want, however it is possible to do this from the code behind so layout and behaviour can be dynamic.

## Notes

- This method of interacting directly between the xaml and the code behind is the quickest way to get a WPF app up and running however for larger application it is highly reccomend following the MVVM pattern. This is because it keeps a cleaner seperation of display code and logic, furthemore it is much more easily testable and promotes a clear convention making it easier for other developers to follow.
