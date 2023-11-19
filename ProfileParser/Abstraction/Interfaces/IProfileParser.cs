using ProfileParser.Data;

namespace ProfileParser.Abstraction.Interfaces;

public interface IProfileParser
{
    public Task Parse();

    public Task Save(ISaveDataStrategy dataSaver);
}