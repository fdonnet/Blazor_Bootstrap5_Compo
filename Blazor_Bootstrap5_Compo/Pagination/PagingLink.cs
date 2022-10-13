namespace Blazor_Bootstrap5_Compo.Pagination
{
    public class PagingLink
    {
        public string Text { get; set; }
        public string AriaLabel { get; set; }

        public int Page { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        
        public PagingLink(int page, bool enabled, string text,string ariaLabel)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
            AriaLabel = ariaLabel;
        }
    }
}
