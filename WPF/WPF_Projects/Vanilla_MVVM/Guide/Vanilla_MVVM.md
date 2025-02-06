The Model-View-ViewModel (MVVM) pattern in WPF is a design architecture that separates the user interface (View) from the business logic and data (Model) by introducing an intermediary layer called the ViewModel. The Model represents the data and business rules, often interacting with services or databases. The ViewModel acts as a bridge between the Model and the View, exposing data and commands in a way that the View can bind to using data binding. The View is responsible only for displaying UI elements and does not contain any business logic, relying instead on data binding and commands to interact with the ViewModel. This separation improves maintainability, testability, and scalability by ensuring that the UI remains loosely coupled from the underlying logic, enabling better code reuse and unit testing. WPF’s powerful data binding, commands, and property change notifications (e.g., INotifyPropertyChanged) make MVVM an ideal pattern for building complex applications.

There is setup required here that does introduce some overheads so for the simple app i am going to build this will seem like over kill but as the app becomes larger the structure does pay divedends. Furthermore there are may MVVM frameworks available from NuGet that reduce some of the boiler plate code and make our life easier, however, I do think its a good idea to know how this works in Vanilla WPF.

# Setup

1. Create 3 folders called; Models; Views; ViewModels
2. In Models create a new **Class** and call it Person.cs. In Views Create a **UserControl** and call it TableView.xaml. In ViewModels Create a **Class** and call it TableViewModel.cs
3. Now we have the structure we need to link the View and the ViewModel, this is done so that Visual Studio knows how to render a ViewModel (e.g. what View should it display when asked to render a ViewModel). To do this we need to define a DataTemplate. We can define the data template in several places however my favourite is to do so in the app.xaml as this is one central point all Views/ViewModels can be linked. Open the App.xaml and add the following code:
   <Application x:Class="Vanilla_MVVM.App"
               xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               xmlns:local="clr-namespace:Vanilla_MVVM"
               xmlns:vm="clr-namespace:Vanilla_MVVM.ViewModels"
               xmlns:v="clr-namespace:Vanilla_MVVM.Views"
               StartupUri="MainWindow.xaml">
   <Application.Resources>
   <ResourceDictionary>
   <DataTemplate DataType="{x:Type vm:TableViewModel}">
   <v:TableView />
   </DataTemplate>
   </ResourceDictionary>
   </Application.Resources>
   </Application>

Note we had to add the vm and v namespaces so Visual Studio can find our files. Then see we added a resource dictionary with a data template that links the View and ViewModel.
