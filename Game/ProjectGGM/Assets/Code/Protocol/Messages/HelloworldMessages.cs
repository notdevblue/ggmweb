using System;

namespace GGM.Application.Protocol
{
    [Serializable]
    public class ReqHelloworld_Hello : IReqBase
    {
        public string Name { get; set; } = string.Empty;
        public string GetEndpoint() => "helloworld/hello";

        public string ToQuerystring() => $"?name={Name}";
    }

    [Serializable]
    public class ResHelloworld_Hello
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ServerTime { get; set; } = default;
        public string Message { get; set; } = string.Empty;
    }
}