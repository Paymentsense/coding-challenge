namespace paymentsense.utility.CacheHelpers
{
    public interface ICache
    {
        T Get<T>(string key);
        bool Set<T>(string key, T data);
    }
}
