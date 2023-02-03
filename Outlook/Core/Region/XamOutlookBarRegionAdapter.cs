using System;
using System.Collections.Specialized;
using Infragistics.Windows.OutlookBar;
using Prism.Regions;

namespace Outlook.Core.Region;

public class XamOutlookBarRegionAdapter : RegionAdapterBase<XamOutlookBar>
{
    public XamOutlookBarRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
        : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, XamOutlookBar regionTarget)
    {
        if (region is null)
            throw new ArgumentNullException(nameof(region));
        if (regionTarget is null)
            throw new ArgumentNullException(nameof(regionTarget));
        region.Views.CollectionChanged += (o, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (OutlookBarGroup outlookBarGroup in e.NewItems)
                {
                    regionTarget.Groups.Add(outlookBarGroup);
                    if (regionTarget.Groups[0] == outlookBarGroup) regionTarget.SelectedGroup = outlookBarGroup;
                }
            else
                foreach (OutlookBarGroup outlookbargroup in e.OldItems)
                    regionTarget.Groups.Remove(outlookbargroup);
        };
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}