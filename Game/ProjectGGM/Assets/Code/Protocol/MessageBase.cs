namespace GGM.Application.Protocol
{
    public interface IReqBase
    {
        public string GetEndpoint();
        public string ToQuerystring();
    }
}