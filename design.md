---
layout: default
title: "Design Considerations"
date: 2013-07-01 8:59
comments: true
sharing: true
footer: true
---

Primarily this extension was developed to statisfy the dynamic creation of controls that have dependencies utilizing [Dependency Injection (DI)](http://en.wikipedia.org/wiki/Dependency_injection) with an eye towards constructor injection; however, there were a few additional constraints in mind (mostly due to a pretty strict policy regarding the [MVVM pattern](http://en.wikipedia.org/wiki/Model_View_ViewModel)):

* Every View must have a corresponding ViewModel
* The ViewModel knows nothing about the View
* Domain and/or Entity classes will have a corresponding ViewModel
* Domain and/or Entity classes cannot be registered in Unity
* All mapping must take place in the Unity setup/bootstrapping
* Mappings must be human readable and easy to understand for junior developers

I realize that under the hood - the MappingFactory is actually implementing the [Service Locator](http://en.wikipedia.org/wiki/Service_locator_pattern) pattern (vs. true DI) which may be considered by some as an anti-pattern ([Mark Seemann - Service Locator is an Anti-Pattern](http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/)); however, this extension abstracts out the Service Locator piece down to its most basic logic. This means first and foremost that it should allow you to plug-in a better solution if one is available. Also, it maintains a clear separation of concerns within the code (important to anyone following the [Single Responsibility Principle (SRP)](http://en.wikipedia.org/wiki/Single_responsibility_principle).

Please feel free to comment openly. I welcome any feedback! You can also comment on the [StackOverflow post](http://stackoverflow.com/questions/9627303/ioc-di-containers-factories-and-runtime-type-creation) where this is discussed or send me a <a href="https://twitter.com/share" class="twitter-share-button" data-via="jigamiller" data-count="none">Tweet</a><script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script>