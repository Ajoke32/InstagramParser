using ProfileParser.Entities;

namespace ProfileParser.Data;

public interface ISaveDataStrategy
{
    public void Save(List<User> users);
}