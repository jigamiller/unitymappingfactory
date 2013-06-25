UnityMappingFactory
====================

Adds an Extension method to the [IUnityContainer](http://msdn.microsoft.com/en-us/library/microsoft.practices.unity.iunitycontainer.aspx) which allows you to register factories that will create new objects based on data from existing objects essentially mapping from one class hierarchy to a different class hierarchy.

The goal was simplicity and readability. No need to declare individual factory classes or interfaces! Just add the mappings right where you register the classes during the bootstrapping process.

You must register anything you are creating (_container.RegisterType_) in the container (_aka._ the generic **TTo** input). 

You do NOT need to register anthying that you are mapping from (_aka._ the generic **TFrom** input).

### Simple 1-class to 1-class mapping:

```csharp 
//make sure to register the output...
container.RegisterType<IPersonViewModel, PersonViewModel>();

//define the mapping between classes...
container.RegisterFactory<IPerson, IPersonViewModel>()
	.AddDefaultMap();
```

This will map any **IContainer** instances as a parameter that will be used to create any instances of the **IContainerViewModel**.

### Mapping between 2 different class hierarchies:

```csharp
//make sure to register the output...
container.RegisterType<IImageWidgetViewModel, ImageWidgetViewModel>();
container.RegisterType<ITextWidgetViewModel, TextWidgetViewModel>();

//define the mapping between different class hierarchies...
container.RegisterFactory<IWidget, IWidgetViewModel>()
	.AddMap<IImageWidget, IImageWidgetViewModel>()
	.AddMap<ITextWidget, ITextWidgetViewModel>();
```
This will provide the following 2 mappings:

1. The **IImageWidget** instances will be a parameter that will be used to create any instances of the **IImageWidgetViewModel**.

2. The **ITextWidget** instances will be a parameter that will be used to create any instances of the **ITextWidgetViewModel**.


## Details

Calling the **RegisterFactory** method actually creates an instance of a **MappingFactory** clas and registers the instance of that class for the lifetime of the container. The class maintains a Dictionary of mappings that were added and utilizes the [IUnityContainer.Resolve()](http://msdn.microsoft.com/en-us/library/ff660794.aspx) method to create the requested object passing in the original object using the [DependencyOverride](http://msdn.microsoft.com/en-us/library/ff660920.aspx) parameter.

## GitHub

This is [on GitHub](https://github.com/jigamiller/unity-mappingfactory) with (hopefully) some additional information on the wiki.
