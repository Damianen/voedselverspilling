using voedselverspilling.DomainServices;
using voedselverspilling.Domain.Models;

namespace voedselverspilling.GraphQL.Mutation {

public class Mutation(IPackageRepository packageRepository)
{
    public async Task<Package> AddPackage(Package package)
    {
        return await packageRepository.AddAsync(package);
    }

    public async Task<Package> PublishPackage(Package package)
    {
        return await packageRepository.UpdateAsync(package);
    }
}

}
