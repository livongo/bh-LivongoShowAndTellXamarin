using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using LivongoShowAndTell2.iOS.Main;
using LivongoShowAndTell2.Network;
using UIKit;

namespace LivongoShowAndTell2.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            GetConfig();
        }

        async Task GetConfig()
        {
            var svc = new ConfigService();
            var config = await svc.GetConfig();
            SetupSource(config);
        }

        void SetupSource(Config c)
        {

            this.TableView.RegisterNibForCellReuse(TitleTableVIewCEll.Nib, TitleTableVIewCEll.Key);
            this.TableView.RegisterNibForCellReuse(DetailTableViewCell.Nib, DetailTableViewCell.Key);

            this.TableView.TableFooterView = new UIView();
            this.TableView.EstimatedRowHeight = UITableView.AutomaticDimension;

            var source = new TableSource(c);
            this.TableView.Source = source;
        }

        class TableSource : UITableViewSource
        {

            Config Config;
            List<ConfigDisplayRow> Items;

            public TableSource(Config c)
            {
                this.Config = c;
                this.Items = ConfigUtil.ConvertToDisplay(this.Config);
            }

            public override nint NumberOfSections(UITableView tableView) => 1;
            public override nint RowsInSection(UITableView tableview, nint section) => this.Items.Count;

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var item = this.Items[indexPath.Row];
                if(item.RType == RowType.TITLE)
                {
                    var titleCell = tableView.DequeueReusableCell(TitleTableVIewCEll.Key) as TitleTableVIewCEll;
                    (titleCell as IBindable).Bind(item.Name);
                    return titleCell;
                }

                var detailCell = tableView.DequeueReusableCell(DetailTableViewCell.Key) as DetailTableViewCell;
                (detailCell as IBindable).Bind(item.Name);
                return detailCell;
            }
        }
    }
}
