namespace WesternApparel.Core.Common
{
    public class BaseLayoutViewModel
    {
        public BaseLayoutViewModel( )
        { }

        public BaseLayoutViewModel( string title )
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}