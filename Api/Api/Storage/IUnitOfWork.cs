using System;

namespace Api.Storage;

public interface IUnitOfWork : IDisposable
{
    bool Connect();
    void Migrate();
}