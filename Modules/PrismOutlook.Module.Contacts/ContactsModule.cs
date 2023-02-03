using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Module.Contacts.Menus;

namespace PrismOutlook.Module.Contacts;

public class ContactsModule : IModule
{
    private readonly IRegionManager _iRegionManager;

    public ContactsModule(IRegionManager iRegionManager)
    {
        _iRegionManager = iRegionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        _iRegionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(ContactsGroup));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}