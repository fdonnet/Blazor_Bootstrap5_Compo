using Microsoft.AspNetCore.Components;

namespace Blazor_Bootstrap5_Compo.Pagination
{
    public partial class Pagination
    {
        [Parameter]
        public PaginationData MetaData { get; set; } = new PaginationData() { CurrentPage = 1, TotalCount = 0, PageSize = 25 };
        [Parameter]
        public int Spread { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        private List<PagingLink>? _links;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }
        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();

            _links.Add(new PagingLink(1, MetaData.CurrentPage != 1, '\u00AB'.ToString(), "Début"));
            _links.Add(new PagingLink(MetaData.CurrentPage - 1, MetaData.HasPrevious, '\u2039'.ToString(), "Précédent"));

            for (int i = 1; i <= MetaData.TotalPages; i++)
            {
                if (i >= MetaData.CurrentPage - Spread && i <= MetaData.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString(),"") { Active = MetaData.CurrentPage == i });
                }
            }

            _links.Add(new PagingLink(MetaData.CurrentPage + 1, MetaData.HasNext, '\u203A'.ToString(), "Suivant"));
            _links.Add(new PagingLink(MetaData.TotalPages, MetaData.CurrentPage != MetaData.TotalPages, '\u00BB'.ToString(), "Fin"));
        }
        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == MetaData.CurrentPage || !link.Enabled)
                return;
            MetaData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
