using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using LivongoShowAndTell2.Network;
using System.Threading.Tasks;
using Android.Views;
using System.Collections.Generic;
using Android.Content;

namespace LivongoShowAndTell2.Droid
{
    [Activity(Label = "LivongoShowAndTell2", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        RecyclerView Recycler;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            this.Recycler = FindViewById<RecyclerView>(Resource.Id.recycler);
        }

        protected override void OnResume()
        {
            base.OnResume();
            GetConfig();
        }

        async Task GetConfig()
        {
            var svc = new ConfigService();
            var config = await svc.GetConfig();
            SetupAdapter(config);
        }

        void SetupAdapter(Config c)
        {
            var linear = new LinearLayoutManager(this);
            linear.Orientation = (int)Orientation.Vertical;
            this.Recycler.SetLayoutManager(linear);

            var adapter = new RecyclerAdapter(this, c);
            this.Recycler.SetAdapter(adapter);
        }

        class RecyclerAdapter : RecyclerView.Adapter
        {
            Context Context;
            Config Config;
            List<ConfigDisplayRow> Items;

            public RecyclerAdapter(Context con, Config c)
            {
                this.Context = con;
                this.Config = c;
                this.Items = ConfigUtil.ConvertToDisplay(this.Config);

            }

            public override int ItemCount => this.Items.Count;

            public override int GetItemViewType(int position)
            {
                return this.Items[position].RType == RowType.TITLE ? 0 : 1;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                var inflater = LayoutInflater.From(this.Context);
                if(viewType == 0)
                {
                    var titleLayout = inflater.Inflate(Resource.Layout.RowTitle, parent, false);
                    return new TitleViewHolder(titleLayout);
                }

                var detailLayout = inflater.Inflate(Resource.Layout.RowDetail, parent, false);
                return new DetailViewHolder(detailLayout);
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var item = this.Items[position];
                (holder as IBindable).Bind(item.Name);
            }

            class TitleViewHolder : RecyclerView.ViewHolder, IBindable
            {

                readonly TextView Title;
                public TitleViewHolder(View itemView) : base(itemView)
                {
                    this.Title = itemView.FindViewById<TextView>(Resource.Id.title);
                }

                public void Bind(string s)
                {
                    this.Title.Text = s;
                }
            }

            class DetailViewHolder : RecyclerView.ViewHolder, IBindable
            {
                readonly TextView Description;
                public DetailViewHolder(View itemView) : base(itemView)
                {
                    this.Description = itemView.FindViewById<TextView>(Resource.Id.description);
                }

                public void Bind(string s)
                {
                    this.Description.Text = s;
                }
            }
        }
    }
}

