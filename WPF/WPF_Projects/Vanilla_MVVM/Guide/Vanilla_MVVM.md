The Model-View-ViewModel (MVVM) pattern in WPF is a design architecture that separates the user interface (View) from the business logic and data (Model) by introducing an intermediary layer called the ViewModel. The Model represents the data and business rules, often interacting with services or databases. The ViewModel acts as a bridge between the Model and the View, exposing data and commands in a way that the View can bind to using data binding. The View is responsible only for displaying UI elements and does not contain any business logic, relying instead on data binding and commands to interact with the ViewModel. This separation improves maintainability, testability, and scalability by ensuring that the UI remains loosely coupled from the underlying logic, enabling better code reuse and unit testing. WPF’s powerful data binding, commands, and property change notifications (e.g., INotifyPropertyChanged) make MVVM an ideal pattern for building complex applications.

There is setup required here that does introduce some overheads so for the simple app i am going to build this will seem like over kill but as the app becomes larger the structure does pay divedends. Furthermore there are may MVVM frameworks available from NuGet that reduce some of the boiler plate code and make our life easier, however, I do think its a good idea to know how this works in Vanilla WPF.

# Setup

The complete code is available however I will define the steps here if u want to do it yourself.

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

Note we had to add the vm and v namespaces so Visual Studio can find our files. Then see we added a resource dictionary with a data template that links the View and ViewModel. In order for a view to access data from the ViewModel the Views **DataContext** must be set to the corresponding ViewModel, however linking the Views/ViewModels with the data template automatically sets the DataContext for us. In MVVM we do not use the code behind, we essentially use the ViewModel as the code behind.

# Adding the code

1.  First we need to set the data context for the MainWindow as we have not set up a data template or ViewModel for this. To do this add the line **DataContext = this;** after the initalize component function call. Furthemore we need to create the TableViewModel and bind this to a property that the View will receive updates from. To do this add the public declaration **public TableViewModel DisplayViewModel { get; set; }**. Now after setting the Data Context we need to create the TableViewModel with the line **DisplayViewModel = new TableViewModel();** so our MainWindow.cs file should look like this:
    public partial class MainWindow : Window
    {
    public TableViewModel DisplayViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DisplayViewModel = new TableViewModel();
        }

    }

2.  Hop over to MainWindow.xaml, in here we need to embed the TableView into this window. To do this we use the content control UI element, this exposes a property called Content where we can bind ViewModels to it and because of the DataTemplate we set up earlier WPF knows how to render the ViewModel. Add the following code to the xaml file:
    <Grid>
    <Grid.RowDefinitions>
    <RowDefinition Height="*" />
    <RowDefinition Height="*" />
    <RowDefinition Height="*" />
    </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>

        <ContentControl
            Grid.Row="1"
            Grid.Column="1"
            Content="{Binding DisplayViewModel}" />

    </Grid>

See this has some row and column definitions to provide us some structure, we are then defining a content control element, binding it to the DisplayViewModel and then places it in row 1 col 1 of the Grid element. Now we can work on the TableView and when we run the app it will be displayed as it is embed within the MainWindow. 3. Now we need to add something in the TableView, the DataGrid is a UI element perfect for making tables but first lets create a data structure in our Models. Go into our Person.cs class and add two properties, an int Id and a string Name. 4. Now in the TableViewModel we need to create some People and a collection to hold multiple instances. To do this we need to define a public property of type Obersvable collection. This type implements the INotifyPropertyChanged interface which is how the ViewModel can update the View however dont worry about this now or do some reading on it as it is very well documented. For our case this type allows us to add to the collection and this will then updated the UI, however if we replace the entire collection this update will not be sent.
Next lets created several Person objects and add them to the People collection, like so:

public class TableViewModel
{
public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
public TableViewModel()
{
var Person1 = new Person { Id = 1, Name = "Bob" };
var Person2 = new Person { Id = 2, Name = "Rob" };
var Person3 = new Person { Id = 3, Name = "Tod" };

        People.Add(Person1);
        People.Add(Person2);
        People.Add(Person3);
    }

} 5. Now we have our data sorted we need to display it, this is done through binding. As mentioned earlier we will want a DataGrid but in order to have this show data we need to bind the property on the DataGrid **ItemSource** to the People property on the ViewModel. This is done with the following code:
**<DataGrid AutoGenerateColumns="True" ItemsSource="{Binding People}" />** 6. Now we should be able to run the program and see our table being diplayed in the center of the screen.

This is a quick example of how Data Binding is used to link the View and the ViewModel, it also shows how we can embed Views in one another. The View/ViewModel pairing allows us to conceptually think of the two files as a single component where the ViewModel consists of behvaiour and the View of statically define structure/layout with selected properties able to change dynamically through binding.

# INotifyPropertyChanged interface

I excluded this from the previous example as it can complicate things however it is a key part of how WPF operates and without it the UI would not be able to receive updates from the ViewModels. We were able to get around using this by using a special type known as an ObservableCollection, this is completely fine and should be used where approriate. However it is beneficial to know how to implement this INotifyPropertyChanged interface as you might need to.
Lets say we have the example where we want to completely replace the People collection with a set of new people, in this case the View would not receive the updated collection. This is because the INotify event is only fired when the collection is modified not replaced so we will have to raise this event if the collection is replaced entirely.
In order to keep things simple and seperated we will define a new View and ViewModel to show case this interface.

1. Create a new View (UserControl) and call it TableViewV2, Create a new ViewModel (class) and call it TableViewModelV2.
2. Go into App.xaml to update the data template to link the ViewModel and View. Do this by defining a new DataTemplate element within the Resource dictionary.
3. Go into MainWindow.cs expose a public property for the new ViewModel, create it and set it to this property.
4. Go into MainWindow.xaml and add a content control element in whatever row and col you like. Then bind the Content property of this to the new DisplayViewModel.
5. Now we are going to leave the View the same so copy the code over from the first View we did.
6. Now we need to show this INotifyPropertyChanged thing actually is doing what Im saying it does. Therefore we are going to add people to the collection as we did before and then overwrite this with a whole new collection but first lets see how we implement this interface.

public class TableViewModelV2 : INotifyPropertyChanged
{
private List<Person> \_People;
public List<Person> People
{
get { return \_People; }
set { \_People = value; OnPropertyChanged(nameof(People)); }
}
public TableViewModelV2()
{
People = new List<Person>();

        var Person1 = new Person { Id = 1, Name = "Bob" };
        var Person2 = new Person { Id = 2, Name = "Rob" };
        var Person3 = new Person { Id = 3, Name = "Tod" };

        People.Add(Person1);
        People.Add(Person2);
        People.Add(Person3);

        People = NewPeople();
    }

    private List<Person> NewPeople()
    {
        People = new List<Person>();

        var Person1 = new Person { Id = 4, Name = "Bob2" };
        var Person2 = new Person { Id = 5, Name = "Rob2" };
        var Person3 = new Person { Id = 6, Name = "Tod2" };

        People.Add(Person1);
        People.Add(Person2);
        People.Add(Person3);

        return People;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

}

See we implent the interface at the class level, this enforces us to define the PropertyChanged event, we then add a helper function that raises this event for us. Dont worry too much about the syntax as this is boiler plate that can be copied into whatever file you need. See we have had to define a private backing field for the People collection, this is because we need to edit the getter and setter of the public property. The getter simpler gets the value stored in the backing field, the setter sets the new value in the backing field and then raises the property changed event by calling our helper funciton.

Notice our constructor looks the same however we are using the List type which doesnt raise the event, we add the same people as before but then at the end we overwrite the whole collection with the NewPeople function we have defined. If we run this code we should now see two tables, the first one we did in the last section and the new one with the overwritten values.
