using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Response
{
    public class BankResponse<T> : IBankResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IBankResponse<T>
    {
        string Description { get; set; }
        StatusCode StatusCode { get; set; }
        T Data { get; set; }
    }
}
