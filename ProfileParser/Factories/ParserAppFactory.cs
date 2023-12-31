﻿using ProfileParser.Interfaces.Factories;
using ProfileParser.Interfaces.Parsers;
using ProfileParser.Options;

namespace ProfileParser.Factories;

public class ParserAppFactory:IParserAppFactory
{
    public IParserApp CreateInstance<T>(ApplicationOptions options) where T : IParserApp
    {
        var instance = Activator.CreateInstance(typeof(T),options);
        if (instance == null)
        {
            throw new Exception("App type is not defined");
        }
        return (T)instance;
    }
}