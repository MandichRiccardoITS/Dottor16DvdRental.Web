namespace Dottor16DvdRental.Web.Components.Pages.Actors;

public partial class Index
{
    public void DetailedActor(int ActorId)
    {
        Navigation.NavigateTo($"/actors/{ActorId}");
    }
}
