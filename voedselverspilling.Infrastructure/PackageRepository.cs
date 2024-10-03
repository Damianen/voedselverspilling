namespace voedselverspilling.Models {

public class PackageRepository : IRepository<Package>
{
    private static List<Package> packages = new();
    public static IEnumerable<Package> Packages => packages;

    public void Add(Package item)
    {
        packages.Add(item);
    }

    public void Remove(Package item)
    {
        packages.Remove(item);
    }

    public void Update(int id, Package item)
    {
        // TODO add this mehtod
    }
}

}
