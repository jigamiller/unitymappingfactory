---
layout: default
title: "UnityMappingFactory"
date: 2013-07-01 8:59
comments: true
sharing: true
footer: true
---

Adds an Extension method to the [IUnityContainer](http://msdn.microsoft.com/en-us/library/microsoft.practices.unity.iunitycontainer.aspx) which allows you to register factories that will create new objects based on data from existing objects essentially mapping from one type hierarchy to a different type hierarchy.

The goal was simplicity and readability. No need to declare individual factory classes or even interfaces! Just add the mappings right where you register the classes during the normal bootstrapping process.

## NOTE(s):

* You must register anything you are creating using the [IUnityContainer.RegisterType](http://msdn.microsoft.com/en-us/library/ee649762.aspx) method in the container (aka. the generic **TTo** input). 
* You do NOT need to register anthying that you are mapping from (aka. the generic **TFrom** input).
* You do NOT need to register any base or abstract types unless you are specifically creating them.

## Example(s):

#### Simple 1-class to 1-class mapping:

```c# 
//make sure to register the output...
container.RegisterType<IPersonViewModel, PersonViewModel>();

//define the mapping between classes...
container.RegisterFactory<IPerson, IPersonViewModel>()
	.AddDefaultMap();
```

This will map any **IPerson** instances as a parameter that will be used to create any instances of the **IPersonViewModel**.

#### Mapping between 2 different class hierarchies:

```c#
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