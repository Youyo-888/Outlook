using System;
using System.Collections.Specialized;
using Infragistics.Windows.Ribbon;
using Prism.Regions;

namespace Outlook.Core.Region;

public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
{
    public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, XamRibbon regionTarget)
    {
        if (region == null) throw new ArgumentNullException(nameof(region));
        if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

        region.Views.CollectionChanged += (s, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (object view in e.NewItems)
                    AddViewToRegion(view, regionTarget);
            else if (e.Action == NotifyCollectionChangedAction.Remove)
                foreach (object view in e.OldItems)
                    RemoveViewFromRegion(view, regionTarget);
        };
    }

    private void RemoveViewFromRegion(object view, XamRibbon regionTarget)
    {
        if (view is RibbonTabItem ribbonTabItem) regionTarget.Tabs.Remove(ribbonTabItem);
    }

    private void AddViewToRegion(object view, XamRibbon regionTarget)
    {
        if (view is RibbonTabItem ribbonTabItem) regionTarget.Tabs.Add(ribbonTabItem);
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}