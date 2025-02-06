<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1554)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XAF - How to show filter dialog before a List View

This example displays a pop-up filter dialog before the application starts to load List View data. This approach can be useful when the List View contains large amount of data.

The filter dialog allows users to create filters and saves them in a data source.

![Filter for ListView](filter-for-listview.png)

## Implementation Details

1. Extend the Application Model with an additional property.
    * Implement an interface that expose the [AdditionalCriteria](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/Module.cs#L40) property. This property stores the applied filter criteria. 
    * Override the [ExtendModelInterfaces](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders)) method of your base Module to extend the Application Model with the declared interface and the `AdditionalCriteria` property.
2. Create the [ViewFilterObject](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/BusinessObjects/ViewFilterObject.cs) class. Instances of this class store user filters.
3. Create the non-persistent [ViewFilterObject](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/BusinessObjects/ViewFilterObject.cs) class. An object of this class contains a list of user filters (`ViewFilterObject` objects) and the currently applied filter. The `ViewFilterContainer`'s Detail View serves as the filter dialog.  
4. Implement [ShowFilterDialogController](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/Controllers/ShowFilterDialogController.cs) to display the filter dialog. When a user selects a filter and clicks the **OK** button, the controller assigns the corresponding filter criteria to the `AdditionalCriteria` Application Model property.
5. Implement [NewViewFilterObjectController](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/Controllers/NewViewFilterObjectController.cs) to initialize a new instance of the `ViewFilterObject` class when a user clicks the **New** button in the `ViewFilterObject` lookup List View.

## Files to Review

* [Module.cs](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/Module.cs) (EFCore Solution) / [Module.cs](CS/XPO/DialogBeforeListView/DialogBeforeListView.Module/Module.cs) (XPO Solution)
* [ViewFilterObject.cs](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/BusinessObjects/ViewFilterObject.cs) (EFCore Solution) / [ViewFilterObject.cs](CS/XPO/DialogBeforeListView/DialogBeforeListView.Module/BusinessObjects/ViewFilterObject.cs) (XPO Solution)
* [ViewFilterContainer.cs](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/BusinessObjects/ViewFilterContainer.cs) (EFCore Solution) / [ViewFilterContainer.cs](CS/XPO/DialogBeforeListView/DialogBeforeListView.Module/BusinessObjects/ViewFilterContainer.cs) (XPO Solution)
* [ShowFilterDialogController.cs](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/Controllers/ShowFilterDialogController.cs) (EFCore Solution) / [ShowFilterDialogController.cs](CS/XPO/DialogBeforeListView/DialogBeforeListView.Module/Controllers/ShowFilterDialogController.cs) (XPO Solution)
* [NewViewFilterObjectController.cs](CS/EFCore/DialogBeforeListViewEF/DialogBeforeListViewEF.Module/Controllers/NewViewFilterObjectController.cs) (EFCore Solution) / [NewViewFilterObjectController.cs](CS/XPO/DialogBeforeListView/DialogBeforeListView.Module/Controllers/NewViewFilterObjectController.cs) (XPO Solution)

## Documentation

- [Non-Persistent Objects](https://docs.devexpress.com/eXpressAppFramework/116516/business-model-design-orm/non-persistent-objects)
- [Data Types Supported by built-in Editors](https://docs.devexpress.com/eXpressAppFramework/113014/business-model-design-orm/data-types-supported-by-built-in-editors)
- [How to: Extend and Access the Application Model Nodes from Controllers](https://docs.devexpress.com/eXpressAppFramework/112785/ui-construction/application-model-ui-settings-storage/customize-application-model-in-code/how-to-extend-the-application-model-nodes-from-controllers)
- [ShowNavigationItemController class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ShowNavigationItemController)
- [DialogController class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.DialogController)
- [Lookup List View](https://docs.devexpress.com/eXpressAppFramework/400501/ui-construction/controllers-and-actions/actions/access-actions-in-different-ui-areas/lookup-list-view).

## More Examples

- [How to Extend the Application Model](https://github.com/DevExpress-Examples/xaf-how-to-extend-the-application-model)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-show-filter-dialog-before-listview&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-show-filter-dialog-before-listview&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
