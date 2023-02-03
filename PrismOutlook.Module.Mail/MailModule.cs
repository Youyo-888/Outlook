using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Module.Mail.Menus;
using PrismOutlook.Module.Mail.Views;

namespace PrismOutlook.Module.Mail;

public class MailModule : IModule
{
    private readonly RegionManager _regionManager;

    public MailModule(RegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));
        _regionManager.RegisterViewWithRegion(RegionNames.RibbonGroupRegion, typeof(HomeTab));
        _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}