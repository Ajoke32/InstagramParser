using ProfileParser.Entities;

namespace ProfileParser.Interfaces;

public interface ISaveDataStrategy
{
    public void Save(List<User> users);

    public Task SaveAsync(List<User> users);
}